using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;


namespace LANAuthServer.Data
{
    internal class DatabaseHelper
    {

        private static string connectionString = "server=localhost;" +
            "port=3306;" +
            "user=root;" +
            "password=root;" +
            "database=lanathentication;";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
