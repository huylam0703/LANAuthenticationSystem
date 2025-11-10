using LANAuthServer.Services;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;
using LANAuthServer.Models;

namespace LANAuthServer.NetWork
{
    internal class ServerListener
    {
        private readonly UserService _userService = new UserService();

        public void Start()
        {
            Thread listenerThread = new Thread(() =>
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 5555);
                listener.Start();
                Console.WriteLine("Server đang lắng nghe trên cổng 5555...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
            });

            listenerThread.IsBackground = true;
            listenerThread.Start();
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[2048];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Nhận dữ liệu: {message}");

                    // ==== LOGIN REQUEST ====
                    if (message.StartsWith("LOGIN|"))
                    {
                        string[] parts = message.Split('|');
                        if (parts.Length < 3)
                        {
                            SendResponse(stream, "FAIL|Thiếu thông tin đăng nhập");
                            return;
                        }

                        string username = parts[1];
                        string password = parts[2];

                        User user = _userService.GetUserByUsername(username);
                        if (user == null)
                        {
                            SendResponse(stream, "FAIL|Không tìm thấy tài khoản");
                            return;
                        }

                        bool isMatch = _userService.VerifyPassword(password, user.password);
                        if (isMatch)
                        {
                            SendResponse(stream, $"SUCCESS|{user.role}|{user.userCode}");
                            Console.WriteLine($"Đăng nhập thành công: {username} ({user.role})");
                        }
                        else
                        {
                            SendResponse(stream, "FAIL|Sai mật khẩu");
                        }
                    }

                    // ==== UPDATE INFO ====
                    else if (message.StartsWith("UPDATE_INFO|"))
                    {
                        string[] parts = message.Split('|');
                        if (parts.Length < 4)
                        {
                            SendResponse(stream, "FAIL|Thiếu dữ liệu cập nhật");
                            return;
                        }

                        string userCode = parts[1];
                        string fullName = parts[2];
                        string email = parts[3];

                        bool updated = _userService.UpdateUserInfo(userCode, fullName, email);
                        string response = updated ? "SUCCESS|Cập nhật thành công" : "FAIL|Không thể cập nhật";
                        SendResponse(stream, response);
                    }

                    // ==== GET USER INFO ====
                    else if (message.StartsWith("GET_USER_INFO|"))
                    {
                        // Format: GET_USER_INFO|userCode
                        string[] parts = message.Split('|');
                        if (parts.Length < 2)
                        {
                            SendResponse(stream, "FAIL|Thiếu mã người dùng");
                            return;
                        }

                        string userCode = parts[1];
                        User user = _userService.GetUserByCode(userCode);

                        if (user != null)
                        {
                            string response = $"USER_INFO|{user.fullName}|{user.userCode}|{user.email}";
                            SendResponse(stream, response);
                        }
                        else
                        {
                            SendResponse(stream, "FAIL|Không tìm thấy người dùng");
                        }
                    }

                    // ==== UNKNOWN COMMAND ====
                    else
                    {
                        SendResponse(stream, "FAIL|Lệnh không hợp lệ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xử lý client: " + ex.Message);
            }
        }

        private void SendResponse(NetworkStream stream, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
    }
}
