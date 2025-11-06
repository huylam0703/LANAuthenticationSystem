using BCryptNet = BCrypt.Net.BCrypt;

namespace LANAuthServer.Services
{
    internal class BCryptService
    {
        public string hashPassword(string password)
        {
            return BCryptNet.HashPassword(password);
        }

        public bool verifyPassword(string password, string hashedPassword) {
            return BCryptNet.Verify(password, hashedPassword);
        }
    }
}
