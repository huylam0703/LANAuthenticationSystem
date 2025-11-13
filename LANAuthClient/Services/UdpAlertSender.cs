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

        public UdpAlertSender(string serverIp = "127.0.0.1", int port = 5556)
        {
            _udpClient = new UdpClient();
            _serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
        }

        public void SendViolationAlert(string userCode, string fullName, string url)
        {
            try
            {
                string message = $"VIOLATION|{userCode}|{fullName}|{url}|{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                byte[] data = Encoding.UTF8.GetBytes(message);

                _udpClient.Send(data, data.Length, _serverEndPoint);
                Console.WriteLine($"✓ Sent violation alert to {_serverEndPoint.Address}:{_serverEndPoint.Port}");
                Console.WriteLine($"  Message: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("✗ Error sending alert: " + ex.Message);
            }
        }

        public void SendHeartbeat(string userCode)
        {
            try
            {
                string message = $"HEARTBEAT|{userCode}|{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                byte[] data = Encoding.UTF8.GetBytes(message);

                _udpClient.Send(data, data.Length, _serverEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending heartbeat: " + ex.Message);
            }
        }

        public void Dispose()
        {
            _udpClient?.Close();
        }
    }
}