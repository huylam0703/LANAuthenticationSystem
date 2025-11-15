using LANAuthServer.Data;
using LANAuthServer.Models;
using System;
using System.Collections.Generic;

namespace LANAuthServer.Services
{
    internal class UserService
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly BCryptService _bcryptService = new BCryptService();

        /// <summary>
        /// Đăng ký người dùng mới
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <param name="role">Vai trò (user/admin)</param>
        /// <returns>True nếu đăng ký thành công</returns>
        public bool registerUser(string username, string password, string role = null)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new AggregateException("Username và password không được để trống");
            }

            role = role ?? "user";
            string userCode = GenerateUserCode();

            var bcryptPass = _bcryptService.hashPassword(password);

            return _userRepo.AddUser(username, bcryptPass, role, userCode);
        }

        /// <summary>
        /// Tạo mã nhân viên ngẫu nhiên
        /// Format: NV_XXXXXX (X là ký tự chữ và số)
        /// </summary>
        private string GenerateUserCode()
        {
            string shortCode = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            return "NV_" + shortCode;
        }

        /// <summary>
        /// Lấy danh sách tất cả người dùng
        /// </summary>
        public List<User> GetUsers() => _userRepo.GetAllUsers();

        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <param name="userCode">Mã nhân viên</param>
        /// <param name="fullName">Họ tên đầy đủ</param>
        /// <param name="email">Email</param>
        /// <returns>True nếu cập nhật thành công</returns>
        public bool UpdateUserInfo(string userCode, string fullName, string email)
        {
            if (string.IsNullOrWhiteSpace(userCode))
                throw new ArgumentException("UserCode không hợp lệ");

            if (string.IsNullOrWhiteSpace(fullName) && string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Phải có ít nhất một thông tin để cập nhật");

            return _userRepo.UpdateUserInfo(userCode, fullName, email);
        }

        /// <summary>
        /// Xóa người dùng khỏi hệ thống
        /// </summary>
        /// <param name="userCode">Mã nhân viên cần xóa</param>
        /// <returns>True nếu xóa thành công</returns>
        public bool DeleteUserInfo(string userCode)
        {
            if (string.IsNullOrWhiteSpace(userCode))
                throw new ArgumentException("UserCode không hợp lệ");

            return _userRepo.DeleteUserInfo(userCode);
        }

        /// <summary>
        /// Xác thực đăng nhập
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>Đối tượng User nếu đăng nhập thành công, null nếu thất bại</returns>
        public User Login(string username, string password)
        {
            var user = _userRepo.GetUserByUsername(username);

            if (user == null)
                return null;

            bool isValid = _bcryptService.verifyPassword(password, user.password);

            return isValid ? user : null;
        }

        /// <summary>
        /// Xác minh mật khẩu
        /// </summary>
        public bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            var bcrypt = new BCryptService();
            return bcrypt.verifyPassword(plainPassword, hashedPassword);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepo.GetUserByUsername(username);
        }

        public User GetUserByCode(string userCode)
        {
            return _userRepo.GetUserByCode(userCode);
        }
    }
}