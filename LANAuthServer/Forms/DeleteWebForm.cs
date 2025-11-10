using LANAuthServer.Services;
using System;
using System.Windows.Forms;

namespace LANAuthServer.Forms
{
    public partial class DeleteWebForm : Form
    {   
        private readonly BannedWebService bannedWebService = new BannedWebService();
        public DeleteWebForm()
        {
            InitializeComponent();
        }

        private void buttonDeleteBannedWeb_Click(object sender, EventArgs e)
        {
            string url = textBoxAddURLWeb.Text;

            if (string.IsNullOrEmpty(url)) {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool del = bannedWebService.DeleteBannedWebsite(url);
                if (del)
                {
                    MessageBox.Show("Xóa website bị chặn thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Website này khong co trong danh sách!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Lỗi khi thêm website: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
