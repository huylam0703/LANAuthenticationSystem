using System;
using System.Net.Sockets;
using System.Text;

namespace LANAuthClient.Services
{
    internal class TcpClientService
    {
        private readonly string _serverIp;
        private readonly int _port;

        public TcpClientService(string serverIp = "192.168.100.190", int port = 5555)
        {
            _serverIp = serverIp;
            _port = port;
        }

        public string SendRequest(string message)
        {
            try
            {
                using (TcpClient client = new TcpClient(_serverIp, _port))
                using (NetworkStream stream = client.GetStream())
                {
                    // Gửi dữ liệu
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    // Nhận phản hồi
                    byte[] buffer = new byte[2048];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể kết nối đến server: " + ex.Message);
            }
        }

        public (bool success, string role, string userCode) Login(string username, string password)
        {
            string message = $"LOGIN|{username}|{password}";
            string response = SendRequest(message);

            if (response.StartsWith("SUCCESS"))
            {
                string[] parts = response.Split('|');
                return (true, parts[1], parts[2]);
            }

            return (false, null, null);
        }

        public (bool success, string fullName, string email) GetUserInfo(string userCode)
        {
            string message = $"GET_USER_INFO|{userCode}";
            string response = SendRequest(message);

            if (response.StartsWith("USER_INFO"))
            {
                string[] parts = response.Split('|');
                return (true, parts[1], parts[3]);
            }

            return (false, null, null);
        }

        public bool UpdateUserInfo(string userCode, string fullName, string email)
        {
            string message = $"UPDATE_INFO|{userCode}|{fullName}|{email}";
            string response = SendRequest(message);

            return response.StartsWith("SUCCESS");
        }

        public bool CheckBannedUrl(string url)
        {
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5555))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"CHECK_URL|{url}";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[2048];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    return response.StartsWith("BANNED");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking URL: " + ex.Message);
                return false;
            }
        }
    }
}