using LANAuthServer.Data;
using LANAuthServer.Forms;
using LANAuthServer.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LANAuthServer.forms
{
    public partial class BannedSitesForm : Form
    {
        private readonly UserService _userService = new UserService();
        private readonly BannedWebService _bannedWebService = new BannedWebService();
        private readonly ViolationRepository _violationRepo = new ViolationRepository();
        private Timer _refreshTimer;
        private Timer _notificationTimer;

        public BannedSitesForm()
        {
            InitializeComponent();

            // Setup auto-refresh timer
            _refreshTimer = new Timer();
            _refreshTimer.Interval = 5000; // 5 giây
            _refreshTimer.Tick += RefreshTimer_Tick;

            // Setup notification clear timer
            _notificationTimer = new Timer();
            _notificationTimer.Interval = 10000; // 10 giây
            _notificationTimer.Tick += NotificationTimer_Tick;
        }

        private void BannedSitesForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("\n=== BannedSitesForm Loading ===");

            try
            {
                LoadDashboardData();
                LoadViolationsList();
                LoadEmployees();
                RefreshBannedWebList();

                // Đăng ký event từ UDP Receiver
                RegisterUdpEvents();

                // Bắt đầu auto-refresh
                _refreshTimer.Start();

                Console.WriteLine("=== Form Loaded Successfully ===\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error loading form: {ex.Message}");
                MessageBox.Show(
                    $"Lỗi khi tải form: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void RegisterUdpEvents()
        {
            try
            {
                if (Program.UdpReceiverInstance != null)
                {
                    // Unregister trước để tránh đăng ký nhiều lần
                    Program.UdpReceiverInstance.OnViolationReceived -= OnViolationReceived;
                    Program.UdpReceiverInstance.OnHeartbeatReceived -= OnHeartbeatReceived;

                    // Register events
                    Program.UdpReceiverInstance.OnViolationReceived += OnViolationReceived;
                    Program.UdpReceiverInstance.OnHeartbeatReceived += OnHeartbeatReceived;

                    Console.WriteLine("✓ UDP Events registered successfully");
                }
                else
                {
                    Console.WriteLine("✗ UdpReceiverInstance is null!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error registering UDP events: {ex.Message}");
            }
        }

        private void OnViolationReceived(string message)
        {
            Console.WriteLine($">>> OnViolationReceived called with: {message}");

            // Update UI thread-safe
            if (InvokeRequired)
            {
                Console.WriteLine("  Invoking on UI thread...");
                try
                {
                    Invoke(new Action<string>(OnViolationReceived), message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  Error invoking: {ex.Message}");
                }
                return;
            }

            Console.WriteLine("  Updating UI...");

            try
            {
                // Hiển thị thông báo
                ShowNotification($"⚠️ VI PHẠM: {message}");

                // Refresh violations list
                LoadViolationsList();

                // Refresh dashboard
                LoadDashboardData();

                FlashForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ✗ Error handling violation: {ex.Message}");
                Console.WriteLine($"  Stack: {ex.StackTrace}");
            }
        }

        private void OnHeartbeatReceived(string userCode)
        {
            // Update UI thread-safe
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnHeartbeatReceived), userCode);
                return;
            }

            // Refresh dashboard và employee list để cập nhật số liệu online
            LoadDashboardData();

            Console.WriteLine($"Heartbeat received from {userCode} - Dashboard updated");
        }

        private void ShowNotification(string message)
        {
            if (textBoxNonfication != null)
            {
                textBoxNonfication.Text = message;
                textBoxNonfication.BackColor = System.Drawing.Color.LightCoral;
                textBoxNonfication.ForeColor = System.Drawing.Color.White;

                // Start timer để clear notification
                _notificationTimer.Stop();
                _notificationTimer.Start();
            }
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            if (textBoxNonfication != null)
            {
                textBoxNonfication.Text = "Không có thông báo mới";
                textBoxNonfication.BackColor = System.Drawing.SystemColors.Window;
                textBoxNonfication.ForeColor = System.Drawing.SystemColors.WindowText;
            }
            _notificationTimer.Stop();
        }

        private void FlashForm()
        {
            // Flash taskbar
            if (!this.Focused)
            {
                FlashWindow(this.Handle, true);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Auto refresh data mỗi 5 giây
            try
            {
                LoadDashboardData();
                LoadViolationsList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in auto-refresh: " + ex.Message);
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                // Load thống kê
                var users = _userService.GetUsers();
                int totalUsers = users.Count;
                int onlineUsers = users.Count(u => u.IsOnline());
                int todayViolations = _violationRepo.GetViolationCountToday();
                int totalBannedWebs = _bannedWebService.GetAllBannedWebsites().Count;

                // Cập nhật labels
                if (labelTotalEmployee != null) labelTotalEmployee.Text = totalUsers.ToString();
                if (LabelTotalEmployeeOnline != null) LabelTotalEmployeeOnline.Text = onlineUsers.ToString();
                if (LabelTotalViolate != null) LabelTotalViolate.Text = todayViolations.ToString();
                if (LabelTotalWebBan != null) LabelTotalWebBan.Text = totalBannedWebs.ToString();

                // Cập nhật biểu đồ
                UpdateChart(totalUsers, onlineUsers, todayViolations, totalBannedWebs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading dashboard: " + ex.Message);
            }
        }

        private void UpdateChart(int totalUsers, int onlineUsers, int todayViolations, int totalBannedWebs)
        {
            try
            {
                if (chart1 == null) return;

                chart1.Series.Clear();
                Series series = new Series("Statistics");
                series.ChartType = SeriesChartType.Column;

                series.Points.AddXY("Tổng nhân viên", totalUsers);
                series.Points.AddXY("Nhân viên online", onlineUsers);
                series.Points.AddXY("Vi phạm hôm nay", todayViolations);
                series.Points.AddXY("Website cấm", totalBannedWebs);

                chart1.Series.Add(series);
                series.IsValueShownAsLabel = true;

                // Màu cho các cột
                series.Points[0].Color = System.Drawing.Color.SteelBlue;
                series.Points[1].Color = System.Drawing.Color.Green;
                series.Points[2].Color = System.Drawing.Color.OrangeRed;
                series.Points[3].Color = System.Drawing.Color.DarkRed;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating chart: " + ex.Message);
            }
        }

        private void LoadViolationsList()
        {
            try
            {
                Console.WriteLine("\n>>> Loading Violations List...");

                var violations = _violationRepo.GetAllViolations();
                Console.WriteLine($"  Found {violations.Count} violations");

                if (dataGridView1 == null)
                {
                    Console.WriteLine("  ✗ dataGridView1 is NULL!");
                    return;
                }

                // Clear existing data
                dataGridView1.Rows.Clear();

                // Setup columns nếu chưa có
                if (dataGridView1.Columns.Count == 0)
                {
                    Console.WriteLine("  Setting up columns...");
                    dataGridView1.Columns.Add("FullName", "Nhân Viên");
                    dataGridView1.Columns.Add("Url", "Website");
                    dataGridView1.Columns.Add("ViolationTime", "Thời gian");
                    dataGridView1.Columns.Add("Status", "Trạng thái");

                    // Set column widths
                    dataGridView1.Columns["FullName"].Width = 200;
                    dataGridView1.Columns["Url"].Width = 250;
                    dataGridView1.Columns["ViolationTime"].Width = 180;
                    dataGridView1.Columns["Status"].Width = 150;
                }

                // Add data
                foreach (var v in violations)
                {
                    int rowIndex = dataGridView1.Rows.Add(
                        v.FullName ?? "Unknown",
                        v.Url ?? "",
                        v.ViolationTime.ToString("dd/MM/yyyy HH:mm:ss"),
                        v.GetStatusText()
                    );

                    // Highlight vi phạm mới (trong 5 phút)
                    if ((DateTime.Now - v.ViolationTime).TotalMinutes < 5)
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor =
                            System.Drawing.Color.LightYellow;
                    }

                    Console.WriteLine($"  Added row {rowIndex}: {v.FullName} - {v.Url}");
                }

                // Update label
                if (LabelTotalListViolate != null)
                {
                    LabelTotalListViolate.Text = $"{violations.Count} vi phạm";
                }

                // Set styling
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                Console.WriteLine($"  ✓ Loaded {violations.Count} violations successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ✗ Error loading violations: {ex.Message}");
                Console.WriteLine($"  Stack: {ex.StackTrace}");

                MessageBox.Show(
                    $"Lỗi khi tải danh sách vi phạm:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadEmployees()
        {
            try
            {
                var users = _userService.GetUsers();

                if (dataGridView2 == null) return;

                dataGridView2.Rows.Clear();

                if (dataGridView2.Columns.Count == 0)
                {
                    dataGridView2.Columns.Add("FullName", "Nhân viên");
                    dataGridView2.Columns.Add("UserCode", "Mã nhân viên");
                    dataGridView2.Columns.Add("Email", "Email");
                    dataGridView2.Columns.Add("Status", "Trạng thái");

                    // Set column widths
                    dataGridView2.Columns["FullName"].Width = 200;
                    dataGridView2.Columns["UserCode"].Width = 150;
                    dataGridView2.Columns["Email"].Width = 200;
                    dataGridView2.Columns["Status"].Width = 120;
                }

                foreach (var u in users)
                {
                    bool isOnline = u.IsOnline();
                    string statusText = isOnline ? "Online" : "Offline";

                    int rowIndex = dataGridView2.Rows.Add(
                        u.fullName ?? "(Chưa có tên)",
                        u.userCode ?? "N/A",
                        u.email ?? "Không có email",
                        statusText
                    );

                    // Highlight online users with green
                    if (isOnline)
                    {
                        dataGridView2.Rows[rowIndex].DefaultCellStyle.BackColor =
                            System.Drawing.Color.LightGreen;
                        dataGridView2.Rows[rowIndex].DefaultCellStyle.ForeColor =
                            System.Drawing.Color.DarkGreen;
                        dataGridView2.Rows[rowIndex].DefaultCellStyle.Font =
                            new System.Drawing.Font(dataGridView2.Font, System.Drawing.FontStyle.Bold);
                    }
                    else
                    {
                        dataGridView2.Rows[rowIndex].DefaultCellStyle.ForeColor =
                            System.Drawing.Color.Gray;
                    }
                }

                if (LabelTotalEmployeeList != null)
                {
                    int onlineCount = users.Count(u => u.IsOnline());
                    LabelTotalEmployeeList.Text = $"{users.Count} nhân viên ({onlineCount} online)";
                }

                dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ReadOnly = true;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading employees: " + ex.Message);
            }
        }

        private void RefreshBannedWebList()
        {
            try
            {
                var bannedList = _bannedWebService.GetAllBannedWebsites();

                if (dataGridView3 == null) return;

                dataGridView3.Rows.Clear();

                if (dataGridView3.Columns.Count == 0)
                {
                    dataGridView3.Columns.Add("URL", "URL");
                    dataGridView3.Columns.Add("Description", "Mô tả");
                    dataGridView3.Columns.Add("CreatedAt", "Ngày tạo");
                }

                foreach (var item in bannedList)
                {
                    dataGridView3.Rows.Add(item.Url, item.Reason, item.CreatedAt.ToString("g"));
                }

                if (LabelTotalWebBannedList != null)
                {
                    LabelTotalWebBannedList.Text = $"{bannedList.Count} web bị cấm";
                }

                dataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading banned websites: " + ex.Message);
            }
        }

        // Event handlers
        private void chart1_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNonfication != null)
            {
                textBoxNonfication.Height = 40;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tabPage4_Click(object sender, EventArgs e) { }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            registerForm registerForm = new registerForm();
            registerForm.ShowDialog();
            LoadEmployees();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteEmployeeForm deleteEmployeeForm = new DeleteEmployeeForm();
            deleteEmployeeForm.ShowDialog();
            LoadEmployees();
        }

        private void ButtonWebBan_Click(object sender, EventArgs e)
        {
            AddWebForm addWebForm = new AddWebForm();
            addWebForm.ShowDialog();
            RefreshBannedWebList();
        }

        private void ButtonDeleteWeb_Click(object sender, EventArgs e)
        {
            DeleteWebForm deleteWebForm = new DeleteWebForm();
            deleteWebForm.ShowDialog();
            RefreshBannedWebList();
        }

        private void buttonExitForm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void ButtonRefeshData_Click(object sender, EventArgs e)
        {
            RefreshBannedWebList();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Cleanup
            _refreshTimer?.Stop();
            _notificationTimer?.Stop();

            // Unregister events
            if (Program.UdpReceiverInstance != null)
            {
                Program.UdpReceiverInstance.OnViolationReceived -= OnViolationReceived;
                Program.UdpReceiverInstance.OnHeartbeatReceived -= OnHeartbeatReceived;
            }
        }
    }
}