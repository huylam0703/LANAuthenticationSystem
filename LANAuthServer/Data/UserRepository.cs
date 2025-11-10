
using LANAuthServer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LANAuthServer.Data
{
    internal class UserRepository
    {

        // create user
        public bool AddUser(string username, string password, string role, string userCode)
        {
            string query = "INSERT INTO users (username, password, role, userCode) VALUES" +
                " (@username, @password, @role, @userCode)";

            using (var connect = DatabaseHelper.GetConnection())
            {
                connect.Open();
                using (var cmd = new MySqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@userCode", userCode);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        //getAllUser

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            string query = "SELECT userCode, fullName, email, status FROM users";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            userCode = reader["userCode"] as string,
                            fullName = reader["fullName"] as string,
                            email = reader["email"] == DBNull.Value ? null : reader["email"].ToString(),
                            Status = UserStatus.offline
                        });
                    }
                }
            }

            return users;
        }


        // Cập nhật thông tin sau khi đăng ký
        public bool UpdateUserInfo(string userCode, string fullName, string email)
        {
            // Xây dựng câu SQL động tùy theo dữ liệu được truyền vào
            List<string> updates = new List<string>();
            if (!string.IsNullOrWhiteSpace(fullName))
                updates.Add("fullName = @fullName");
            if (!string.IsNullOrWhiteSpace(email))
                updates.Add("email = @Email");

            if (updates.Count == 0)
                return false; // Không có gì để cập nhật

            string query = $"UPDATE users SET {string.Join(", ", updates)} WHERE userCode = @userCode";

            using (var connect = DatabaseHelper.GetConnection())
            {
                connect.Open();
                using (var cmd = new MySqlCommand(query, connect))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                    if (!string.IsNullOrWhiteSpace(email))
                        cmd.Parameters.AddWithValue("@Email", email);

                    cmd.Parameters.AddWithValue("@userCode", userCode);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool DeleteUserInfo(string userCode) {
            string query = "DELETE FROM users WHERE userCode = @userCode";

            using (var connect = DatabaseHelper.GetConnection())
            {
                connect.Open();
                using (var cmd = new MySqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@userCode", userCode);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }

        }


        public User GetUserByUsername(string username)
        {
            string query = "SELECT * FROM users WHERE username = @username";
            using (var connect = DatabaseHelper.GetConnection())
            {
                connect.Open();
                using (var cmd = new MySqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = reader.GetInt32("userID"),
                                username = reader.GetString("username"),
                                password = reader.GetString("password"),
                                role = reader.GetString("role"),
                                userCode = reader["userCode"]?.ToString() ?? "",
                                fullName = reader["fullName"]?.ToString() ?? "",
                                email = reader["email"]?.ToString() ?? ""
                            };
                        }
                    }
                }
            }
            return null;
        }

        public User GetUserByCode(string userCode)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE userCode = @userCode LIMIT 1";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userCode", userCode);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                userCode = reader["userCode"].ToString(),
                                fullName = reader["fullName"].ToString(),
                                email = reader["email"] == DBNull.Value ? null : reader["email"].ToString(),
                                role = reader["role"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }


    }

}


