using LANAuthServer.Services;
using System;
using System.Windows.Forms;

namespace LANAuthServer.Forms
{
    public partial class AddWebForm : Form
    {
        private readonly BannedWebService _bannedWebService = new BannedWebService();
        public AddWebForm()
        {
            InitializeComponent();
        }


        private void AddWebForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddWebBanned_Click(object sender, EventArgs e)
        {

            string url = textBoxAddURLWeb.Text;
            string description = textBoxAddDescription.Text;

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool added = _bannedWebService.AddBannedWebsite(url, description);

                if (added)
                {
                    MessageBox.Show("Thêm website bị chặn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dữ liệu nhập cũ
                    textBoxAddURLWeb.Clear();
                    textBoxAddDescription.Clear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Website này đã tồn tại trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm website: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
