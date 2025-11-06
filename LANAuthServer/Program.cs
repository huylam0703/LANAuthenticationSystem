using LANAuthServer.forms;
using LANAuthServer.NetWork;
using LANAuthServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANAuthServer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServerListener server = new ServerListener();
            server.Start();
            var authService = new AuthService();
            authService.EnsureAdminAccount();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

           
        }
    }
}
