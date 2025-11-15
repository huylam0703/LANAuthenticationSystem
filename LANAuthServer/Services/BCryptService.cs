using BCryptNet = BCrypt.Net.BCrypt;

namespace LANAuthServer.Services
{
    internal class BCryptService
    {
        /// <summary>
        /// Mã hóa mật khẩu sử dụng BCrypt
        /// </summary>
        public string hashPassword(string password)
        {
            return BCryptNet.HashPassword(password);
        }

        /// <summary>
        /// Xác minh mật khẩu với hash đã lưu
        /// </summary>
        public bool verifyPassword(string password, string hashedPassword)
        {
            return BCryptNet.Verify(password, hashedPassword);
        }
    }
}