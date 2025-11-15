using LANAuthServer.Data;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LANAuthServer.Services
{
    internal class UdpReceiver
    {
        private UdpClient _udpClient;
        private Thread _listenerThread;
        private bool _isRunning;
        private readonly int _port;
        private readonly ViolationRepository _violationRepo;
        private readonly UserRepository _userRepo;

        public event Action<string> OnViolationReceived;
        public event Action<string> OnHeartbeatReceived;

        public UdpReceiver(int port = 5556)
        {
            _port = port;
            _violationRepo = new ViolationRepository();
            _userRepo = new UserRepository();
        }

        /// <summary>
        /// Bắt đầu lắng nghe UDP packets từ client
        /// </summary>
        public void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _udpClient = new UdpClient(_port);

            _listenerThread = new Thread(ListenerLoop)
            {
                IsBackground = true
            };
            _listenerThread.Start();
        }

        /// <summary>
        /// Dừng lắng nghe UDP
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
            _udpClient?.Close();
        }

        /// <summary>
        /// Vòng lặp lắng nghe UDP packets
        /// </summary>
        private void ListenerLoop()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, _port);

            while (_isRunning)
            {
                try
                {
                    byte[] data = _udpClient.Receive(ref remoteEP);
                    string message = Encoding.UTF8.GetString(data);

                    ProcessMessage(message, remoteEP);
                }
                catch (SocketException)
                {
                    break;
                }
                catch (Exception)
                {
                    // Bỏ qua lỗi và tiếp tục lắng nghe
                }
            }
        }

        /// <summary>
        /// Xử lý message nhận được từ client
        /// </summary>
        private void ProcessMessage(string message, IPEndPoint remoteEP)
        {
            try
            {
                if (message.StartsWith("VIOLATION|"))
                {
                    ProcessViolation(message);
                }
                else if (message.StartsWith("HEARTBEAT|"))
                {
                    ProcessHeartbeat(message);
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi xử lý message
            }
        }

        /// <summary>
        /// Xử lý thông báo vi phạm từ client
        /// Format: VIOLATION|userCode|fullName|url|timestamp
        /// </summary>
        private void ProcessViolation(string message)
        {
            string[] parts = message.Split('|');

            if (parts.Length >= 4)
            {
                string userCode = parts[1];
                string fullName = parts[2];
                string url = parts[3];

                try
                {
                    // Lấy thông tin user từ database
                    var user = _userRepo.GetUserByCode(userCode);

                    if (user == null)
                    {
                        // Vẫn hiển thị vi phạm nhưng không lưu vào DB
                        string violationMessage = $"{fullName} ({userCode}) truy cập {url}";
                        OnViolationReceived?.Invoke(violationMessage);
                        return;
                    }

                    // Lưu vi phạm vào database
                    bool added = _violationRepo.AddViolation(user.UserID, fullName, url);

                    if (added)
                    {
                        string violationMessage = $"{fullName} ({userCode}) truy cập {url}";
                        OnViolationReceived?.Invoke(violationMessage);
                    }
                    else
                    {
                        // Vẫn hiển thị dù lưu thất bại
                        string violationMessage = $"{fullName} ({userCode}) truy cập {url}";
                        OnViolationReceived?.Invoke(violationMessage);
                    }
                }
                catch (Exception)
                {
                    // Cố gắng hiển thị vi phạm dù có lỗi
                    try
                    {
                        string violationMessage = $"{fullName} ({userCode}) truy cập {url}";
                        OnViolationReceived?.Invoke(violationMessage);
                    }
                    catch
                    {
                        // Bỏ qua nếu không thể hiển thị
                    }
                }
            }
        }

        /// <summary>
        /// Xử lý tín hiệu heartbeat từ client
        /// Format: HEARTBEAT|userCode|timestamp
        /// </summary>
        private void ProcessHeartbeat(string message)
        {
            string[] parts = message.Split('|');

            if (parts.Length >= 2)
            {
                string userCode = parts[1];

                // Cập nhật thời gian heartbeat trong database
                try
                {
                    _userRepo.UpdateLastHeartbeat(userCode);
                }
                catch (Exception)
                {
                    // Bỏ qua lỗi cập nhật
                }

                OnHeartbeatReceived?.Invoke(userCode);
            }
        }
    }
}