using LANAuthServer.Data;
using LANAuthServer.forms;
using LANAuthServer.Helpers;
using LANAuthServer.NetWork;
using LANAuthServer.Services;
using System;
using System.Windows.Forms;

namespace LANAuthServer
{
    internal static class Program
    {
        public static UdpReceiver UdpReceiverInstance { get; private set; }
        public static TcpServerService UrlCheckServerInstance { get; private set; }

        [STAThread]
        static void Main()
        {
            // Hiển thị console
            ConsoleHelper.ShowConsole();

            // Kiểm tra kết nối database
            ConsoleHelper.LogInfo("Testing database connection...");
            if (!DatabaseHelper.TestConnection())
            {
                ConsoleHelper.LogError("Cannot connect to database!");
                ConsoleHelper.LogError("Please check:");
                ConsoleHelper.LogError("  1. MySQL is running");
                ConsoleHelper.LogError("  2. Database 'lanathentication' exists");
                ConsoleHelper.LogError("  3. Username/password in DatabaseHelper.cs is correct");

                MessageBox.Show(
                    "Cannot connect to database!\n\n" +
                    "Please check:\n" +
                    "1. MySQL is running\n" +
                    "2. Database exists\n" +
                    "3. Credentials are correct",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Xác minh các bảng trong database
            DatabaseHelper.VerifyTables();

            // Khởi tạo TCP Server cho authentication (port 5555)
            ServerListener tcpServer = new ServerListener();
            tcpServer.Start();
            ConsoleHelper.LogSuccess("TCP Server started on port 5555 (Authentication)");

            // Khởi tạo UDP Receiver cho violations và heartbeats (port 5556)
            UdpReceiverInstance = new UdpReceiver(5556);
            UdpReceiverInstance.OnViolationReceived += (msg) =>
            {
                ConsoleHelper.LogViolation(msg);
            };
            UdpReceiverInstance.OnHeartbeatReceived += (userCode) =>
            {
                ConsoleHelper.LogInfo($"Heartbeat from: {userCode}");
            };
            UdpReceiverInstance.Start();

            // Khởi tạo TCP Server bổ sung cho URL checking (port 5557)
            UrlCheckServerInstance = new TcpServerService(5557);
            UrlCheckServerInstance.OnClientMessage += (msg) =>
            {
                ConsoleHelper.LogInfo($"URL Check: {msg}");
            };
            UrlCheckServerInstance.Start();

            // Đảm bảo tài khoản admin tồn tại
            var authService = new AuthService();
            authService.EnsureAdminAccount();

            ConsoleHelper.LogSuccess("All services started successfully!");
            ConsoleHelper.LogInfo("Waiting for admin login...\n");

            // Khởi động giao diện
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            // Dọn dẹp khi đóng
            ConsoleHelper.LogInfo("Shutting down services...");
            UdpReceiverInstance?.Stop();
            UrlCheckServerInstance?.Stop();
            ConsoleHelper.LogSuccess("Server stopped successfully");
        }
    }
}