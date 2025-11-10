using System;

namespace LANAuthServer.Models
{
    internal class BannedWeb
    {
        public int Id { get; set; }
        public string url { get; set; } = "";
        public string description { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}
