using System;
using System.Runtime.InteropServices;

namespace LANAuthServer.Helpers
{
    internal static class ConsoleHelper
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        public static void ShowConsole()
        {
            if (GetConsoleWindow() == IntPtr.Zero)
            {
                AllocConsole();
                Console.WriteLine("=== LAN Authentication Server Console ===");
                Console.WriteLine($"Started at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine("==========================================\n");
            }
        }

        public static void HideConsole()
        {
            FreeConsole();
        }

        public static void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[INFO] {DateTime.Now:HH:mm:ss} - {message}");
            Console.ResetColor();
        }

        public static void LogSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[SUCCESS] {DateTime.Now:HH:mm:ss} - {message}");
            Console.ResetColor();
        }

        public static void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] {DateTime.Now:HH:mm:ss} - {message}");
            Console.ResetColor();
        }

        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {DateTime.Now:HH:mm:ss} - {message}");
            Console.ResetColor();
        }

        public static void LogViolation(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"[VIOLATION] {DateTime.Now:HH:mm:ss} - {message}");
            Console.ResetColor();
        }
    }
}