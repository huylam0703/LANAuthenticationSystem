using LANAuthServer.Services;
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
        UserService _userService = new UserService();

        public DeleteEmployeeForm()
        {
            InitializeComponent();
        }

        private void DeleteEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelEmployee_Click(object sender, EventArgs e)
        {

            string userCode = textBoxDelByUserCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(userCode))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool deleted = _userService.DeleteUserInfo(userCode);

                if (deleted)
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên với mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
