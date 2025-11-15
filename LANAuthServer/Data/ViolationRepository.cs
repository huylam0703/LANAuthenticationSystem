using LANAuthServer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LANAuthServer.Data
{
    internal class ViolationRepository
    {
        /// <summary>
        /// Thêm vi phạm mới vào database
        /// </summary>
        /// <param name="userId">ID người dùng vi phạm</param>
        /// <param name="fullName">Tên người vi phạm</param>
        /// <param name="url">URL vi phạm</param>
        /// <returns>True nếu thêm thành công</returns>
        public bool AddViolation(int userId, string fullName, string url)
        {
            string query = @"INSERT INTO violations (userID, fullName, url, violationTime, status) 
                           VALUES (@userID, @fullName, @url, @violationTime, @status)";

            MySqlConnection conn = null;
            try
            {
                conn = DatabaseHelper.GetConnection();
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userId);
                    cmd.Parameters.AddWithValue("@fullName", fullName ?? "Unknown");
                    cmd.Parameters.AddWithValue("@url", url ?? "");
                    cmd.Parameters.AddWithValue("@violationTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@status", "pending");

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Lấy tất cả vi phạm từ database
        /// </summary>
        public List<Violation> GetAllViolations()
        {
            var violations = new List<Violation>();
            string query = @"SELECT v.violationID, v.userID, v.fullName, v.url, 
                                   v.violationTime, v.status 
                            FROM violations v 
                            ORDER BY v.violationTime DESC";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        violations.Add(new Violation
                        {
                            ViolationID = reader.GetInt32("violationID"),
                            UserID = reader.GetInt32("userID"),
                            FullName = reader.GetString("fullName"),
                            Url = reader.GetString("url"),
                            ViolationTime = reader.GetDateTime("violationTime"),
                            Status = reader.GetString("status")
                        });
                    }
                }
            }

            return violations;
        }

        /// <summary>
        /// Lấy vi phạm của một người dùng cụ thể
        /// </summary>
        public List<Violation> GetViolationsByUser(int userId)
        {
            var violations = new List<Violation>();
            string query = @"SELECT v.violationID, v.userID, v.fullName, v.url, 
                                   v.violationTime, v.status 
                            FROM violations v 
                            WHERE v.userID = @userID
                            ORDER BY v.violationTime DESC";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userID", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            violations.Add(new Violation
                            {
                                ViolationID = reader.GetInt32("violationID"),
                                UserID = reader.GetInt32("userID"),
                                FullName = reader.GetString("fullName"),
                                Url = reader.GetString("url"),
                                ViolationTime = reader.GetDateTime("violationTime"),
                                Status = reader.GetString("status")
                            });
                        }
                    }
                }
            }

            return violations;
        }

        /// <summary>
        /// Đếm số vi phạm trong ngày hôm nay
        /// </summary>
        public int GetViolationCountToday()
        {
            string query = @"SELECT COUNT(*) FROM violations 
                           WHERE DATE(violationTime) = CURDATE()";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Cập nhật trạng thái vi phạm
        /// </summary>
        public bool UpdateViolationStatus(int violationId, string status)
        {
            string query = "UPDATE violations SET status = @status WHERE violationID = @violationID";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@violationID", violationId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Xóa vi phạm khỏi database
        /// </summary>
        public bool DeleteViolation(int violationId)
        {
            string query = "DELETE FROM violations WHERE violationID = @violationID";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@violationID", violationId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}