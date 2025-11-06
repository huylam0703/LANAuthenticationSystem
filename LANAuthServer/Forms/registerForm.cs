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
    public partial class registerForm : Form
    {
        private readonly UserService _userService = new UserService();
        public registerForm()
        {
            InitializeComponent();
        }

        private void registerForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {

            string username = textBoxAddUsername.Text.Trim();
            string password = textBoxAddPassword.Text;
            string confirmPassword = textBoxAddReturnPassword.Text;


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _userService.registerUser(username, password, "user");
                DialogResult result = MessageBox.Show("Đăng ký nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }



        // logic

        //private void LoadUsers()
        //{
        //    var users = _userService.registerUser();
        //    dgvUsers.DataSource = users;
        //}
    }
}
