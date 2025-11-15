using LANAuthServer.Services;
using System;
using System.Windows.Forms;

namespace LANAuthServer.Forms
{
    public partial class DeleteEmployeeForm : Form
    {
        private readonly UserService _userService = new UserService();

        public DeleteEmployeeForm()
        {
            InitializeComponent();
        }

        private void DeleteEmployeeForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút xóa nhân viên
        /// </summary>
        private void buttonDelEmployee_Click(object sender, EventArgs e)
        {
            string userCode = textBoxDelByUserCode.Text.Trim();

            // Kiểm tra input
            if (string.IsNullOrWhiteSpace(userCode))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhân viên có mã '{userCode}'?\n\n" +
                "Hành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Thực hiện xóa
                bool deleted = _userService.DeleteUserInfo(userCode);

                if (deleted)
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên với mã này.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}