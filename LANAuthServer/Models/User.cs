
using System;

namespace LANAuthServer.Models
{
    internal class User
    {

        public int UserID { get; set; }
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public string userCode { get; set; } = "";
        public string fullName { get; set; } = "";
        public string email { get; set; } = "";
        public string role { get; set; } = "";
        public UserStatus Status { get; set; }

        public DateTime? LastHeartbeat { get; set; }

        public bool IsOnline()
        {
            if (!LastHeartbeat.HasValue)
                return false;

            // Consider user online if last heartbeat was within 60 seconds
            return (DateTime.Now - LastHeartbeat.Value).TotalSeconds < 60;
        }

    }
}
