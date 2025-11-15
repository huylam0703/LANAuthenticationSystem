using LANAuthClient.Data;
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
        private ConfigManager _configManager;

        public MainForm(string code)
        {
            InitializeComponent();

            userCode = code;
            _configManager = new ConfigManager();
            var (serverIp, serverPort) = _configManager.LoadServerAddress();

            // Khởi tạo các service
            _monitorService = new MonitorService();
            _alertSender = new UdpAlertSender(serverIp, 5556);
            _tcpService = new TcpClientService(serverIp, serverPort);

            // Đăng ký sự kiện giám sát
            _monitorService.OnUrlDetected += OnUrlDetected;
            _monitorService.OnMonitoringStatusChanged += OnMonitoringChanged;

            // Thiết lập timer heartbeat - gửi tín hiệu mỗi 30 giây
            _heartbeatTimer = new Timer();
            _heartbeatTimer.Interval = 30000;
            _heartbeatTimer.Tick += SendHeartbeat;
        }

        /// <summary>
        /// Tải thông tin người dùng từ server
        /// </summary>
        private void LoadUserInfo()
        {
            try
            {
                using (TcpClient client = new TcpClient("192.168.100.190", 5555))
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

                        userCode = userCodeFromServer;

                        // Cập nhật giao diện
                        nameResult.Text = fullName ?? "Chưa cập nhật";
                        employeeCodeResult.Text = userCodeFromServer;
                        labelEmail.Text = email ?? "Chưa có email";
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

            // Bắt đầu giám sát và heartbeat
            _monitorService.StartMonitoring();
            _heartbeatTimer.Start();

            UpdateMonitoringStatus();
            UpdateTime();

            // Timer cập nhật thời gian mỗi giây
            Timer timeTimer = new Timer();
            timeTimer.Interval = 1000;
            timeTimer.Tick += (s, ev) => UpdateTime();
            timeTimer.Start();
        }

        /// <summary>
        /// Xử lý khi phát hiện URL mới
        /// </summary>
        private void OnUrlDetected(string url)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnUrlDetected), url);
                return;
            }

            CheckBannedUrl(url);
        }

        /// <summary>
        /// Kiểm tra URL có bị cấm không và gửi cảnh báo nếu cần
        /// </summary>
        private void CheckBannedUrl(string url)
        {
            try
            {
                bool isBanned = _tcpService.CheckBannedUrl(url);

                if (isBanned)
                {
                    string currentUserCode = userCode;
                    string currentFullName = fullName ?? "Unknown User";

                    // Gửi cảnh báo vi phạm đến server
                    _alertSender.SendViolationAlert(currentUserCode, currentFullName, url);

                    // Hiển thị cảnh báo cho người dùng
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
            catch (Exception)
            {
                // Bỏ qua lỗi kiểm tra
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

        /// <summary>
        /// Cập nhật hiển thị trạng thái giám sát
        /// </summary>
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

        /// <summary>
        /// Cập nhật hiển thị thời gian
        /// </summary>
        private void UpdateTime()
        {
            if (TimeMain != null)
            {
                TimeMain.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            }
        }

        /// <summary>
        /// Gửi tín hiệu heartbeat đến server
        /// </summary>
        private void SendHeartbeat(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(userCode))
                {
                    _alertSender.SendHeartbeat(userCode);
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi gửi heartbeat
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

        /// <summary>
        /// Dọn dẹp tài nguyên khi đóng form
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            _monitorService?.StopMonitoring();
            _heartbeatTimer?.Stop();
            _alertSender?.Dispose();
        }
    }
}