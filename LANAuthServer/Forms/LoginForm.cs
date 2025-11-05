using LANAuthServer.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANAuthServer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {


        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();

            BannedSitesForm bannedSitesForm = new BannedSitesForm();
            bannedSitesForm.ShowDialog();
        }
    }
}
