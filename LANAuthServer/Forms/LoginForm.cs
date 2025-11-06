using LANAuthServer.forms;
using LANAuthServer.Models;
using LANAuthServer.Services;
using System;
using System.Windows.Forms;

namespace LANAuthServer
{
    public partial class LoginForm : Form

    {
        private readonly UserService _userService = new UserService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {


        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {

            string username = BoxUsername.Text.Trim();
            string password = BoxPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User user = _userService.Login(username, password);

                if (user == null)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (user.role != "admin")
                {
                    MessageBox.Show("Tài khoản này không có quyền truy cập admin!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nếu là admin → mở form quản trị
                this.Hide();
                BannedSitesForm bannedSitesForm = new BannedSitesForm();
                bannedSitesForm.ShowDialog();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void BoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
