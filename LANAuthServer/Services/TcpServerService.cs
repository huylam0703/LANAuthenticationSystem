using LANAuthServer.Data;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LANAuthServer.Services
{
    internal class TcpServerService
    {
        private TcpListener _listener;
        private Thread _listenerThread;
        private bool _isRunning;
        private readonly int _port;
        private readonly BannedWebRepository _bannedRepo;

        public event Action<string> OnClientMessage;

        public TcpServerService(int port = 5555)
        {
            _port = port;
            _bannedRepo = new BannedWebRepository();
        }

        public void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();

            _listenerThread = new Thread(ListenerLoop)
            {
                IsBackground = true
            };
            _listenerThread.Start();

            Console.WriteLine($"TCP Server started on port {_port}");
        }

        public void Stop()
        {
            _isRunning = false;
            _listener?.Stop();
            Console.WriteLine("TCP Server stopped");
        }

        private void ListenerLoop()
        {
            while (_isRunning)
            {
                try
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client))
                    {
                        IsBackground = true
                    };
                    clientThread.Start();
                }
                catch (SocketException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("TCP Server error: " + ex.Message);
                }
            }
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

                    OnClientMessage?.Invoke(message);

                    // Xử lý CHECK_URL request
                    if (message.StartsWith("CHECK_URL|"))
                    {
                        string[] parts = message.Split('|');
                        if (parts.Length >= 2)
                        {
                            string url = parts[1];
                            bool isBanned = CheckIfUrlBanned(url);

                            string response = isBanned ? "BANNED" : "OK";
                            SendResponse(stream, response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error handling client: " + ex.Message);
            }
            finally
            {
                client?.Close();
            }
        }

        private bool CheckIfUrlBanned(string url)
        {
            try
            {
                var bannedList = _bannedRepo.GetAllBannedWebsites();

                foreach (var item in bannedList)
                {
                    if (url.ToLower().Contains(item.Url.ToLower()))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking banned URL: " + ex.Message);
            }

            return false;
        }

        private void SendResponse(NetworkStream stream, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
    }
}