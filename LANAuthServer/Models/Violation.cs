using System;

namespace LANAuthServer.Models
{
    internal class Violation
    {
        public int ViolationID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Url { get; set; }
        public DateTime ViolationTime { get; set; }
        public string Status { get; set; } // pending, reviewed, resolved

        public Violation()
        {
            ViolationTime = DateTime.Now;
            Status = "pending";
        }

        public string GetStatusText()
        {
            switch (Status.ToLower())
            {
                case "pending":
                    return "Chờ xử lý";
                case "reviewed":
                    return "Đã xem xét";
                case "resolved":
                    return "Đã giải quyết";
                default:
                    return Status;
            }
        }

        public override string ToString()
        {
            return $"[{ViolationTime:yyyy-MM-dd HH:mm:ss}] {FullName} - {Url} ({GetStatusText()})";
        }
    }
}