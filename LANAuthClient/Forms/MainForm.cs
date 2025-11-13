using LANAuthClient.Services;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LANAuthClient.Forms
{
    public partial class MainForm : Form
    {
        private string userCode;
        private string fullName;
        private MonitorService _monitorService;
        private UdpAlertSender _alertSender;
        private Timer _heartbeatTimer;
        private TcpClientService _tcpService;

        public MainForm(string code)
        {
            InitializeComponent();

            // Lưu userCode từ login
            userCode = code;

            Console.WriteLine($"\n>>> MainForm Constructor:");
            Console.WriteLine($"    Initial UserCode: {userCode}");

            // Khởi tạo services
            _monitorService = new MonitorService();
            _alertSender = new UdpAlertSender();
            _tcpService = new TcpClientService();

            // Setup monitoring events
            _monitorService.OnUrlDetected += OnUrlDetected;
            _monitorService.OnMonitoringStatusChanged += OnMonitoringChanged;

            // Setup heartbeat timer
            _heartbeatTimer = new Timer();
            _heartbeatTimer.Interval = 30000; // 30 giây
            _heartbeatTimer.Tick += SendHeartbeat;
        }

        private void LoadUserInfo()
        {
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5555))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"GET_USER_INFO|{userCode}";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[2048];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (response.StartsWith("USER_INFO|"))
                    {
                        string[] parts = response.Split('|');
                        fullName = parts[1];
                        string userCodeFromServer = parts[2];
                        string email = parts[3];

                        // CẬP NHẬT: Đảm bảo userCode và fullName được set đúng
                        userCode = userCodeFromServer;

                        // Cập nhật UI
                        nameResult.Text = fullName ?? "Chưa cập nhật";
                        employeeCodeResult.Text = userCodeFromServer;
                        labelEmail.Text = email ?? "Chưa có email";

                        // LOG để debug
                        Console.WriteLine($"✓ User info loaded:");
                        Console.WriteLine($"  - UserCode: {userCode}");
                        Console.WriteLine($"  - FullName: {fullName}");
                        Console.WriteLine($"  - Email: {email}");
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy thông tin người dùng!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();

            // DEBUG: Log userCode để biết client đang dùng code nào
            Console.WriteLine("===========================================");
            Console.WriteLine($">>> CLIENT INFO:");
            Console.WriteLine($"    UserCode: {userCode}");
            Console.WriteLine($"    FullName: {fullName ?? "(loading...)"}");
            Console.WriteLine("===========================================\n");

            // Bắt đầu giám sát
            _monitorService.StartMonitoring();

            // Bắt đầu gửi heartbeat
            _heartbeatTimer.Start();

            // Cập nhật trạng thái
            UpdateMonitoringStatus();
            UpdateTime();

            // Timer cập nhật thời gian
            Timer timeTimer = new Timer();
            timeTimer.Interval = 1000;
            timeTimer.Tick += (s, ev) => UpdateTime();
            timeTimer.Start();
        }

        private void OnUrlDetected(string url)
        {
            // Update UI thread-safe
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnUrlDetected), url);
                return;
            }

            Console.WriteLine($"Detected URL: {url}");

            // Kiểm tra với server xem URL có bị cấm không
            CheckBannedUrl(url);
        }

        private void CheckBannedUrl(string url)
        {
            try
            {
                bool isBanned = _tcpService.CheckBannedUrl(url);

                if (isBanned)
                {
                    // QUAN TRỌNG: Đảm bảo dùng đúng userCode và fullName của user đang login
                    string currentUserCode = userCode;
                    string currentFullName = fullName ?? "Unknown User";

                    Console.WriteLine($"\n!!! VIOLATION DETECTED !!!");
                    Console.WriteLine($"  User: {currentFullName}");
                    Console.WriteLine($"  Code: {currentUserCode}");
                    Console.WriteLine($"  URL: {url}");
                    Console.WriteLine($"  Time: {DateTime.Now:HH:mm:ss}");

                    // Gửi cảnh báo vi phạm với thông tin CHÍNH XÁC
                    _alertSender.SendViolationAlert(currentUserCode, currentFullName, url);

                    // Hiển thị cảnh báo cho user
                    MessageBox.Show(
                        $"Cảnh báo: Bạn đang truy cập website bị cấm!\n\n" +
                        $"Website: {url}\n" +
                        $"User: {currentFullName} ({currentUserCode})\n\n" +
                        $"Vi phạm này đã được ghi nhận.",
                        "Cảnh báo Vi phạm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking URL: " + ex.Message);
            }
        }

        private void OnMonitoringChanged(bool isMonitoring)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(OnMonitoringChanged), isMonitoring);
                return;
            }

            UpdateMonitoringStatus();
        }

        private void UpdateMonitoringStatus()
        {
            if (_monitorService != null && _monitorService.IsMonitoring)
            {
                label1.Text = "Đang hoạt động";
                label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label1.Text = "Tạm dừng";
                label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void UpdateTime()
        {
            if (TimeMain != null)
            {
                TimeMain.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            }
        }

        private void SendHeartbeat(object sender, EventArgs e)
        {
            try
            {
                // Đảm bảo dùng userCode hiện tại
                if (!string.IsNullOrEmpty(userCode))
                {
                    _alertSender.SendHeartbeat(userCode);
                    Console.WriteLine($"[Heartbeat] Sent for user: {userCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending heartbeat: " + ex.Message);
            }
        }

        private void updateInfo_Click(object sender, EventArgs e)
        {
            UpdateInfo updateInfo = new UpdateInfo();
            updateInfo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void nameResult_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void ButtonMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonExitMain_Click(object sender, EventArgs e)
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Cleanup
            _monitorService?.StopMonitoring();
            _heartbeatTimer?.Stop();
            _alertSender?.Dispose();
        }
    }
}