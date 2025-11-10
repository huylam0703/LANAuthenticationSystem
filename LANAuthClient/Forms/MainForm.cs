using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LANAuthClient.Forms
{
    public partial class MainForm : Form
    {   
        private string userCode;

        private void LoadUserInfo()
        {
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5555))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = $"GET_USER_INFO|{userCode}";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[2048];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (response.StartsWith("USER_INFO|"))
                    {
                        string[] parts = response.Split('|');
                        string fullName = parts[1];
                        string userCodeFromServer = parts[2];
                        string email = parts[3];

                        nameResult.Text = fullName;
                        employeeCodeResult.Text = userCodeFromServer;
                        labelEmail.Text = email;
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
            }
        }

        public MainForm(string code)
        {
            InitializeComponent();
            userCode = code;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void updateInfo_Click(object sender, EventArgs e)
        {
            UpdateInfo updateInfo = new UpdateInfo();
            updateInfo.ShowDialog();


        }

        private void nameResult_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 5555))
            using (NetworkStream stream = client.GetStream())
            {
                string message = $"GET_USER_INFO|{userCode}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[2048];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (response.StartsWith("USER_INFO|"))
                {
                    string[] parts = response.Split('|');
                    string fullName = parts[1];
                    string userCodeFromServer = parts[2];
                    string email = parts[3];

                    nameResult.Text = fullName;
                    employeeCodeResult.Text = userCodeFromServer;
                    labelEmail.Text = email;
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserInfo();
        }


    }
}
