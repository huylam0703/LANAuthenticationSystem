using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANAuthClient.Forms
{
    public partial class UpdateInfo : Form
    {
        public UpdateInfo()
        {
            InitializeComponent();
        }

        private void buttonAddInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = textBoxAddName.Text;
                string email = textBoxAddDEmail.Text;
                string userId = textBoxUserCode.Text; // ví dụ bạn lưu sẵn sau khi login

                // tạo nội dung gửi sang server (dạng JSON đơn giản)
                string message = $"UPDATE_INFO|{userId}|{fullName}|{email}";

                using (TcpClient client = new TcpClient("192.168.100.190", 5555))
                {
                    NetworkStream stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    // nhận phản hồi
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    DialogResult result = MessageBox.Show(response, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi yêu cầu: " + ex.Message);
            }
        }

        private void UpdateInfo_Load(object sender, EventArgs e)
        {
            

        }
    }
}
