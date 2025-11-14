using LANAuthServer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LANAuthServer.Data
{
    internal class UserRepository
    {
        // Create user
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

        // Get all users with online status
        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            string query = "SELECT userCode, fullName, email, lastHeartbeat FROM users WHERE role = 'user'";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            userCode = reader["userCode"] as string,
                            fullName = reader["fullName"] as string,
                            email = reader["email"] == DBNull.Value ? null : reader["email"].ToString(),
                            LastHeartbeat = reader["lastHeartbeat"] == DBNull.Value
                                ? (DateTime?)null
                                : reader.GetDateTime("lastHeartbeat")
                        };

                        // Set status based on last heartbeat
                        user.Status = user.IsOnline() ? UserStatus.online : UserStatus.offline;

                        users.Add(user);
                    }
                }
            }

            return users;
        }

        // Update last heartbeat timestamp
        public bool UpdateLastHeartbeat(string userCode)
        {
            string query = "UPDATE users SET lastHeartbeat = @lastHeartbeat WHERE userCode = @userCode";

            using (var connect = DatabaseHelper.GetConnection())
            {
                connect.Open();
                using (var cmd = new MySqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@lastHeartbeat", DateTime.Now);
                    cmd.Parameters.AddWithValue("@userCode", userCode);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Get count of online users
        public int GetOnlineUserCount()
        {
            string query = @"SELECT COUNT(*) FROM users 
                            WHERE role = 'user' 
                            AND lastHeartbeat IS NOT NULL 
                            AND TIMESTAMPDIFF(SECOND, lastHeartbeat, NOW()) < 60";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Update user info after registration
        public bool UpdateUserInfo(string userCode, string fullName, string email)
        {
            List<string> updates = new List<string>();
            if (!string.IsNullOrWhiteSpace(fullName))
                updates.Add("fullName = @fullName");
            if (!string.IsNullOrWhiteSpace(email))
                updates.Add("email = @Email");

            if (updates.Count == 0)
                return false;

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

        // Delete user
        public bool DeleteUserInfo(string userCode)
        {
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

        // Get user by username
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
                                email = reader["email"]?.ToString() ?? "",
                                LastHeartbeat = reader["lastHeartbeat"] == DBNull.Value
                                    ? (DateTime?)null
                                    : reader.GetDateTime("lastHeartbeat")
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Get user by code
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
                                UserID = reader["userID"] != DBNull.Value ? Convert.ToInt32(reader["userID"]) : 0,
                                userCode = reader["userCode"]?.ToString() ?? "",
                                fullName = reader["fullName"]?.ToString() ?? "",
                                email = reader["email"] == DBNull.Value ? null : reader["email"].ToString(),
                                role = reader["role"]?.ToString() ?? "",
                                LastHeartbeat = reader["lastHeartbeat"] == DBNull.Value
                                    ? (DateTime?)null
                                    : reader.GetDateTime("lastHeartbeat")
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}