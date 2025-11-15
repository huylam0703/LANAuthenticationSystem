using LANAuthServer.Data;
using System;

namespace LANAuthServer.Services
{
    internal class AuthService
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly BCryptService _bcryptService = new BCryptService();

        /// <summary>
        /// Đảm bảo tài khoản admin tồn tại trong database
        /// Tạo tài khoản mặc định nếu chưa có
        /// Username: admin, Password: admin
        /// </summary>
        public void EnsureAdminAccount()
        {
            string adminUsername = "admin";
            string adminPassword = "admin";
            string role = "admin";

            var existingAdmin = _userRepo.GetUserByUsername(adminUsername);
            if (existingAdmin != null)
            {
                return;
            }

            string hashedPass = _bcryptService.hashPassword(adminPassword);
            string userCode = null;

            _userRepo.AddUser(adminUsername, hashedPass, role, userCode);
        }
    }
}