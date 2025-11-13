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

        public void StopMonitoring()
        {
            _isMonitoring = false;
            OnMonitoringStatusChanged?.Invoke(false);
        }

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

                        // Kiểm tra với server xem URL có bị cấm không
                        CheckUrlWithServer(detectedUrl);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Monitor error: " + ex.Message);
                }

                Thread.Sleep(2000); // Kiểm tra mỗi 2 giây
            }
        }

        private string GetActiveWindowUrl()
        {
            try
            {
                IntPtr handle = GetForegroundWindow();
                StringBuilder windowTitle = new StringBuilder(256);
                GetWindowText(handle, windowTitle, 256);

                string title = windowTitle.ToString();

                // Phát hiện browser và extract URL từ title
                if (title.Contains("- Google Chrome") ||
                    title.Contains("- Mozilla Firefox") ||
                    title.Contains("- Microsoft Edge"))
                {
                    // Lấy phần trước dấu "-" (thường là title trang web)
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

        private string ExtractDomain(string text)
        {
            // Đơn giản hóa - tìm các domain phổ biến
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

        private void CheckUrlWithServer(string url)
        {
            // Gửi URL lên server để kiểm tra
            // Server sẽ phản hồi nếu URL bị cấm
            Task.Run(() => {
                // TODO: Implement server check
                // Tạm thời log ra
                Console.WriteLine($"Checking URL: {url}");
            });
        }

        public bool IsMonitoring => _isMonitoring;
        public string CurrentUrl => _currentUrl;
    }
}