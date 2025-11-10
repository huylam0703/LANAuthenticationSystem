using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LANAuthServer.Data
{
    internal class BannedWebRepository
    {
        public bool addWebBanned(string url, string description)
        {
            string query = "INSERT INTO bannedweb (url, description, createdAt) VALUES" +
                " (@url, @description, @createdAt)";
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@url", url);
                    cmd.Parameters.AddWithValue("@description", description ?? "Không có lý do");
                    cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteBannedWebsite(string url)
        {
            string query = "DELETE FROM bannedweb WHERE url = @url";
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@url", url);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<(string Url, string Reason, DateTime CreatedAt)> GetAllBannedWebsites()
        {
            List<(string Url, string description, DateTime CreatedAt)> list =
                new List<(string Url, string description, DateTime CreatedAt)>();

            string query = "SELECT url, description, createdAt FROM bannedweb ORDER BY createdAt DESC";

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add((
                            reader["url"].ToString(),
                            reader["description"].ToString(),
                            reader.GetDateTime("createdAt")
                        ));
                    }
                }
            }

            return list;
        }
    }
}
