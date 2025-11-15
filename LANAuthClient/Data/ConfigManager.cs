using System;
using System.Configuration;
using System.IO;

namespace LANAuthClient.Data
{
    internal class ConfigManager
    {
        private readonly string _configPath;

        public ConfigManager()
        {
            _configPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "LANAuth",
                "client.config"
            );

            EnsureConfigDirectory();
        }

        private void EnsureConfigDirectory()
        {
            string directory = Path.GetDirectoryName(_configPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public void SaveServerAddress(string serverIp, int port)
        {
            try
            {
                File.WriteAllText(_configPath, $"{serverIp}:{port}");
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể lưu cấu hình: " + ex.Message);
            }
        }

        public (string ip, int port) LoadServerAddress()
        {
            try
            {
                if (File.Exists(_configPath))
                {
                    string content = File.ReadAllText(_configPath);
                    string[] parts = content.Split(':');

                    if (parts.Length == 2 && int.TryParse(parts[1], out int port))
                    {
                        return (parts[0], port);
                    }
                }
            }
            catch { }

            // Giá trị mặc định
            return ("192.168.100.190", 5555);
        }

        public void SaveUserPreferences(string userCode, bool autoStart, bool minimizeToTray)
        {
            try
            {
                string prefPath = Path.Combine(
                    Path.GetDirectoryName(_configPath),
                    $"{userCode}_prefs.config"
                );

                File.WriteAllText(prefPath, $"{autoStart}|{minimizeToTray}");
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể lưu tùy chọn: " + ex.Message);
            }
        }

        public (bool autoStart, bool minimizeToTray) LoadUserPreferences(string userCode)
        {
            try
            {
                string prefPath = Path.Combine(
                    Path.GetDirectoryName(_configPath),
                    $"{userCode}_prefs.config"
                );

                if (File.Exists(prefPath))
                {
                    string content = File.ReadAllText(prefPath);
                    string[] parts = content.Split('|');

                    if (parts.Length == 2 &&
                        bool.TryParse(parts[0], out bool autoStart) &&
                        bool.TryParse(parts[1], out bool minimizeToTray))
                    {
                        return (autoStart, minimizeToTray);
                    }
                }
            }
            catch { }

            return (false, false);
        }
    }
}