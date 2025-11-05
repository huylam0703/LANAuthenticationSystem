using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANAuthServer.Forms
{
    public partial class DeleteEmployeeForm : Form
    {
        public DeleteEmployeeForm()
        {
            InitializeComponent();
        }

        private void DeleteEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelEmployee_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
