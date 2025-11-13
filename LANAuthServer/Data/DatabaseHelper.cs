using System;
using MySql.Data.MySqlClient;

namespace LANAuthServer.Data
{
    internal class DatabaseHelper
    {
        private static string connectionString =
            "server=localhost;" +
            "port=3306;" +
            "user=root;" +
            "password=root;" +
            "database=lanathentication;" +
            "CharSet=utf8mb4;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

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
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error verifying tables: {ex.Message}");
            }
        }
    }
}