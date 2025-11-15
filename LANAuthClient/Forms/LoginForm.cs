using LANAuthClient.Data;
using LANAuthClient.Forms;
using System;
using System.Net.Sockets;
using System.Text;

using System.Windows.Forms;

namespace LANAuthClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
                var configManager = new ConfigManager();
                var (serverIp, serverPort) = configManager.LoadServerAddress();

                using (TcpClient client = new TcpClient(serverIp, serverPort))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"LOGIN|{username}|{password}";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[2048];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (response.StartsWith("SUCCESS"))
                    {

                        string[] parts = response.Split('|');
                        string role = parts[1];
                        string userCode = parts[2];
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                        // Mở form chính cho user
                        MainForm mainForm = new MainForm(userCode);
                        mainForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
