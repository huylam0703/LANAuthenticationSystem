using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LANAuthClient.Services
{
    internal class MonitorService
    {
        private bool _isMonitoring = false;
        private Thread _monitorThread;
        private string _currentUrl = "";
        private readonly UdpAlertSender _alertSender;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public event Action<string> OnUrlDetected;
        public event Action<bool> OnMonitoringStatusChanged;

        public MonitorService()
        {
            _alertSender = new UdpAlertSender();
        }

        /// <summary>
        /// Bắt đầu giám sát hoạt động trình duyệt của người dùng
        /// </summary>
        public void StartMonitoring()
        {
            if (_isMonitoring) return;

            _isMonitoring = true;
            _monitorThread = new Thread(MonitorLoop)
            {
                IsBackground = true
            };
            _monitorThread.Start();

            OnMonitoringStatusChanged?.Invoke(true);
        }

        /// <summary>
        /// Dừng giám sát
        /// </summary>
        public void StopMonitoring()
        {
            _isMonitoring = false;
            OnMonitoringStatusChanged?.Invoke(false);
        }

        /// <summary>
        /// Vòng lặp chính để giám sát cửa sổ đang hoạt động
        /// Kiểm tra mỗi 2 giây
        /// </summary>
        private void MonitorLoop()
        {
            while (_isMonitoring)
            {
                try
                {
                    string detectedUrl = GetActiveWindowUrl();

                    if (!string.IsNullOrEmpty(detectedUrl) && detectedUrl != _currentUrl)
                    {
                        _currentUrl = detectedUrl;
                        OnUrlDetected?.Invoke(detectedUrl);

                        CheckUrlWithServer(detectedUrl);
                    }
                }
                catch (Exception)
                {
                    // Bỏ qua lỗi và tiếp tục giám sát
                }

                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Lấy URL từ tiêu đề cửa sổ trình duyệt đang hoạt động
        /// </summary>
        /// <returns>URL hoặc tên miền được phát hiện</returns>
        private string GetActiveWindowUrl()
        {
            try
            {
                IntPtr handle = GetForegroundWindow();
                StringBuilder windowTitle = new StringBuilder(256);
                GetWindowText(handle, windowTitle, 256);

                string title = windowTitle.ToString();

                // Phát hiện các trình duyệt phổ biến
                if (title.Contains("- Google Chrome") ||
                    title.Contains("- Mozilla Firefox") ||
                    title.Contains("- Microsoft Edge"))
                {
                    string[] parts = title.Split(new[] { " - " }, StringSplitOptions.None);
                    if (parts.Length > 0)
                    {
                        return ExtractDomain(parts[0]);
                    }
                }
            }
            catch { }

            return null;
        }

        /// <summary>
        /// Trích xuất tên miền từ tiêu đề trang web
        /// </summary>
        private string ExtractDomain(string text)
        {
            string lowerText = text.ToLower();

            string[] commonSites = {
                "facebook", "youtube", "google", "twitter",
                "instagram", "tiktok", "reddit", "netflix"
            };

            foreach (var site in commonSites)
            {
                if (lowerText.Contains(site))
                {
                    return site + ".com";
                }
            }

            return text;
        }

        /// <summary>
        /// Kiểm tra URL với server (placeholder)
        /// </summary>
        private void CheckUrlWithServer(string url)
        {
            Task.Run(() => {
                // Placeholder cho kiểm tra với server
            });
        }

        public bool IsMonitoring => _isMonitoring;
        public string CurrentUrl => _currentUrl;
    }
}