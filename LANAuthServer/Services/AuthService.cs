using LANAuthServer.Data;
using LANAuthServer.Models;
using System;

namespace LANAuthServer.Services
{
    internal class AuthService
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly BCryptService _bcryptService = new BCryptService();

        public void EnsureAdminAccount()
        {
            string adminUsername = "admin";
            string adminPassword = "admin"; 
            string role = "admin";

            var existingAdmin = _userRepo.GetUserByUsername(adminUsername);
            if (existingAdmin != null)
            {
                Console.WriteLine("Admin account already exists.");
                return;
            }

            string hashedPass = _bcryptService.hashPassword(adminPassword);
            string userCode = null;

            _userRepo.AddUser(adminUsername, hashedPass, role, userCode);
            Console.WriteLine("Admin account created successfully.");
            
        }
    }
}
