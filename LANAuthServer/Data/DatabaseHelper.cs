using System;
using MySql.Data.MySqlClient;

namespace LANAuthServer.Data
{
    internal class DatabaseHelper
    {
        private static string connectionString =
    "server=192.168.100.190;" +
    "port=3306;" +
    "user=admin;" +
    "password=123456;" +
    "database=lanathentication;" +
    "SslMode=Preferred;" +
    "CharSet=utf8mb4;";


        /// <summary>
        /// Lấy connection đến MySQL database
        /// </summary>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Kiểm tra kết nối database
        /// </summary>
        /// <returns>True nếu kết nối thành công</returns>
        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    Console.WriteLine("✓ Database connection successful");
                    Console.WriteLine($"  Server: {conn.ServerVersion}");
                    Console.WriteLine($"  Database: {conn.Database}");
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"✗ Database connection failed:");
                Console.WriteLine($"  Error ({ex.Number}): {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Unexpected error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xác minh các bảng trong database tồn tại
        /// </summary>
        public static void VerifyTables()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    string[] tables = { "users", "bannedweb", "violations", "sessions" };

                    Console.WriteLine("\n=== Verifying Database Tables ===");

                    foreach (var table in tables)
                    {
                        string query = $"SELECT COUNT(*) FROM {table}";
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            object result = cmd.ExecuteScalar();
                            Console.WriteLine($"  ✓ Table '{table}': {result} rows");
                        }
                    }

                    Console.WriteLine("=================================\n");
                }
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"✗ Error verifying tables: {ex.Message}");

            //}
            catch (MySqlException ex)
            {
                Console.WriteLine($"MYSQL ERROR NUMBER   : {ex.Number}");
                Console.WriteLine($"MYSQL ERROR MESSAGE  : {ex.Message}");
            }

        }
    }
}