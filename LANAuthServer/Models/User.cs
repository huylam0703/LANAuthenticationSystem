
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

    }
}
