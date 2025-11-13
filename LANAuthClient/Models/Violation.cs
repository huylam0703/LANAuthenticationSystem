using System;

namespace LANAuthClient.Models
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

        public override string ToString()
        {
            return $"[{ViolationTime:yyyy-MM-dd HH:mm:ss}] {FullName} truy cập {Url}";
        }
    }
}