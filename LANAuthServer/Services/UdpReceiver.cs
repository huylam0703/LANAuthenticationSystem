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

            Console.WriteLine($"✓ UDP Receiver started on port {_port}");
            Console.WriteLine("  Listening for violations and heartbeats...");
        }

        public void Stop()
        {
            _isRunning = false;
            _udpClient?.Close();
            Console.WriteLine("UDP Receiver stopped");
        }

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
                    // Socket closed
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UDP Receiver error: " + ex.Message);
                }
            }
        }

        private void ProcessMessage(string message, IPEndPoint remoteEP)
        {
            try
            {
                Console.WriteLine($"\n--- Received UDP Message ---");
                Console.WriteLine($"From: {remoteEP.Address}:{remoteEP.Port}");
                Console.WriteLine($"Data: {message}");
                Console.WriteLine($"Time: {DateTime.Now:HH:mm:ss}");

                if (message.StartsWith("VIOLATION|"))
                {
                    Console.WriteLine("Type: VIOLATION");
                    ProcessViolation(message);
                }
                else if (message.StartsWith("HEARTBEAT|"))
                {
                    Console.WriteLine("Type: HEARTBEAT");
                    ProcessHeartbeat(message);
                }
                else
                {
                    Console.WriteLine($"Type: UNKNOWN");
                }

                Console.WriteLine("---------------------------\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error processing message: {ex.Message}");
            }
        }

        private void ProcessViolation(string message)
        {
            // Format: VIOLATION|userCode|fullName|url|timestamp
            string[] parts = message.Split('|');

            if (parts.Length >= 4)
            {
                string userCode = parts[1];
                string fullName = parts[2];
                string url = parts[3];

                Console.WriteLine($"Processing violation: {userCode} - {fullName} - {url}");

                try
                {
                    // Lấy user từ userCode
                    var user = _userRepo.GetUserByCode(userCode);

                    if (user == null)
                    {
                        Console.WriteLine($"✗ User not found with code: {userCode}");

                        // Vẫn trigger event để hiển thị, nhưng không lưu DB
                        string violationMessage = $"{fullName} ({userCode}) truy cập {url}";
                        OnViolationReceived?.Invoke(violationMessage);

                        Console.WriteLine("  Violation displayed but NOT saved to database (user not found)");
                        return;
                    }

                    Console.WriteLine($"✓ User found: ID={user.UserID}, Name={user.fullName}");

                    // Thêm violation vào database
                    bool added = _violationRepo.AddViolation(user.UserID, fullName, url);

                    if (added)
                    {
                        string violationMessage = $"{fullName} ({userCode}) truy cập {url}";
                        Console.WriteLine($"✓ Violation saved to database successfully");

                        // Trigger event để cập nhật UI
                        OnViolationReceived?.Invoke(violationMessage);
                    }
                    else
                    {
                        Console.WriteLine("✗ Failed to save violation to database");

                        // Vẫn hiển thị trên UI
                        string violationMessage = $"{fullName} ({userCode}) truy cập {url}";
                        OnViolationReceived?.Invoke(violationMessage);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✗ Exception processing violation: {ex.Message}");

                    // Vẫn cố gắng hiển thị trên UI dù có lỗi
                    try
                    {
                        string violationMessage = $"{fullName} ({userCode}) truy cập {url}";
                        OnViolationReceived?.Invoke(violationMessage);
                        Console.WriteLine("  Violation displayed despite error");
                    }
                    catch
                    {
                        Console.WriteLine("  Could not display violation");
                    }
                }
            }
            else
            {
                Console.WriteLine($"✗ Invalid violation message format: {message}");
                Console.WriteLine($"  Expected: VIOLATION|userCode|fullName|url|timestamp");
                Console.WriteLine($"  Received {parts.Length} parts");
            }
        }

        private void ProcessHeartbeat(string message)
        {
            // Format: HEARTBEAT|userCode|timestamp
            string[] parts = message.Split('|');

            if (parts.Length >= 2)
            {
                string userCode = parts[1];
                Console.WriteLine($"Heartbeat from: {userCode}");

                // Update last heartbeat in database
                try
                {
                    bool updated = _userRepo.UpdateLastHeartbeat(userCode);
                    if (updated)
                    {
                        Console.WriteLine($"✓ Updated heartbeat for {userCode}");
                    }
                    else
                    {
                        Console.WriteLine($"✗ Failed to update heartbeat for {userCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✗ Error updating heartbeat: {ex.Message}");
                }

                OnHeartbeatReceived?.Invoke(userCode);
            }
        }
    }
}