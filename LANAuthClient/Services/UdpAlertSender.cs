using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LANAuthClient.Services
{
    internal class UdpAlertSender
    {
        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _serverEndPoint;

        public UdpAlertSender(string serverIp = "192.168.100.190", int port = 5556)
        {
            _udpClient = new UdpClient();
            _serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
        }

        /// <summary>
        /// Gửi cảnh báo vi phạm đến server qua UDP
        /// </summary>
        /// <param name="userCode">Mã nhân viên</param>
        /// <param name="fullName">Họ tên nhân viên</param>
        /// <param name="url">URL vi phạm</param>
        public void SendViolationAlert(string userCode, string fullName, string url)
        {
            try
            {
                string message = $"VIOLATION|{userCode}|{fullName}|{url}|{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                byte[] data = Encoding.UTF8.GetBytes(message);

                _udpClient.Send(data, data.Length, _serverEndPoint);
            }
            catch (Exception)
            {
                // Bỏ qua lỗi gửi
            }
        }

        /// <summary>
        /// Gửi tín hiệu heartbeat đến server để cập nhật trạng thái online
        /// </summary>
        /// <param name="userCode">Mã nhân viên</param>
        public void SendHeartbeat(string userCode)
        {
            try
            {
                string message = $"HEARTBEAT|{userCode}|{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                byte[] data = Encoding.UTF8.GetBytes(message);

                _udpClient.Send(data, data.Length, _serverEndPoint);
            }
            catch (Exception)
            {
                // Bỏ qua lỗi gửi
            }
        }

        public void Dispose()
        {
            _udpClient?.Close();
        }
    }
}