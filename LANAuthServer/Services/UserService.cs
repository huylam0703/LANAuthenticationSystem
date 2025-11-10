
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

        public bool registerUser(string username, string password, string role = null)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) {

                throw new AggregateException("Username va password khong duoc de trong");
            };

            role = role ?? "user";
            string userCode = GenerateUserCode();

            var bcryptPass = _bcryptService.hashPassword(password);

            return _userRepo.AddUser(username, bcryptPass, role, userCode);

        }

        private string GenerateUserCode()
        {
            string shortCode = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            return "NV_" + shortCode;
        }



        public List<User> GetUsers() => _userRepo.GetAllUsers();



        public bool UpdateUserInfo(string userCode, string fullName, string email)
        {
            if (string.IsNullOrWhiteSpace(userCode))
                throw new ArgumentException("UserCode không hợp lệ");

            if (string.IsNullOrWhiteSpace(fullName) && string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Phải có ít nhất một thông tin để cập nhật");

            return _userRepo.UpdateUserInfo(userCode, fullName, email);
        }


        public bool DeleteUserInfo(string userCode)
        {
            if (string.IsNullOrWhiteSpace(userCode))
                throw new ArgumentException("UserCode không hợp lệ");

            return _userRepo.DeleteUserInfo(userCode);
        }

        public User Login(string username, string password)
        {
            var user = _userRepo.GetUserByUsername(username);

            if (user == null)
                return null;

            bool isValid = _bcryptService.verifyPassword(password, user.password);

            return isValid ? user : null;
        }

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
