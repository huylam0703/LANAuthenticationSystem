using System;

namespace LANAuthClient.Models
{
    internal class MessagePacket
    {
        public string Type { get; set; } // LOGIN, HEARTBEAT, VIOLATION, etc.
        public string UserCode { get; set; }
        public string Data { get; set; }
        public DateTime Timestamp { get; set; }

        public MessagePacket()
        {
            Timestamp = DateTime.Now;
        }

        public MessagePacket(string type, string userCode, string data)
        {
            Type = type;
            UserCode = userCode;
            Data = data;
            Timestamp = DateTime.Now;
        }

        public string Serialize()
        {
            return $"{Type}|{UserCode}|{Data}|{Timestamp:yyyy-MM-dd HH:mm:ss}";
        }

        public static MessagePacket Deserialize(string message)
        {
            try
            {
                string[] parts = message.Split('|');
                if (parts.Length >= 3)
                {
                    return new MessagePacket
                    {
                        Type = parts[0],
                        UserCode = parts[1],
                        Data = parts[2],
                        Timestamp = parts.Length > 3 && DateTime.TryParse(parts[3], out DateTime dt)
                            ? dt
                            : DateTime.Now
                    };
                }
            }
            catch { }

            return null;
        }
    }
}