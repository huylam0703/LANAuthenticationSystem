using System;

using System.Windows.Forms;

namespace LANAuthClient.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void updateInfo_Click(object sender, EventArgs e)
        {
            UpdateInfo updateInfo = new UpdateInfo();
            updateInfo.ShowDialog();


        }
    }
}
