using LANAuthServer.Forms;
using LANAuthServer.Services;
using System;

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LANAuthServer.forms
{
    public partial class BannedSitesForm : Form
    {
        private readonly UserService _userService = new UserService();
        private readonly BannedWebService _bannedWebService = new BannedWebService();
        public BannedSitesForm()
        {
            InitializeComponent();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void BannedSitesForm_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            Series series = new Series("Employees");
            series.ChartType = SeriesChartType.Column; // Bar = ngang, Column = dọc

            series.Points.AddXY("Tổng nhân viên", 10);
            series.Points.AddXY("tổng số vi phạm", 6);
            series.Points.AddXY("Tổng website cấm", 4);

            chart1.Series.Add(series);

            series.IsValueShownAsLabel = true;


            /////////////////////////////////////////////////
            // Danh sach vi pham

            dataGridView1.Columns.Clear();

            // Tạo cột
            dataGridView1.Columns.Add("User", "Nhân Viên");
            dataGridView1.Columns.Add("userCode", "Mã nhân viên");
            dataGridView1.Columns.Add("Website", "Website");
            dataGridView1.Columns.Add("Time", "Thời gian");
            dataGridView1.Columns.Add("Status", "Trạng thái");

            // Thêm dữ liệu mẫu
            dataGridView1.Rows.Add("huy.lam", "363636", "facebook.com", "10:32", "Vi phạm");
            dataGridView1.Rows.Add("thao.nguyen", "PC-02", "youtube.com", "10:35", "Vi phạm");

            // Căn giữa các cột
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Tùy chỉnh kích thước cột
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //danh sach nhan vien
            LoadEmployees();

            ///////////////////////////////////////
            // Danh sach web cấm
            RefreshBannedWebList();


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBoxNonfication.Height = 40;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            registerForm registerForm = new registerForm();
            registerForm.ShowDialog();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteEmployeeForm deleteEmployeeForm = new DeleteEmployeeForm();
            deleteEmployeeForm.ShowDialog();
        }

        private void ButtonWebBan_Click(object sender, EventArgs e)
        {
            AddWebForm addWebForm = new AddWebForm();
            addWebForm.ShowDialog();
        }

        private void ButtonDeleteWeb_Click(object sender, EventArgs e)
        {
            DeleteWebForm deleteWebForm = new DeleteWebForm();
            deleteWebForm.ShowDialog();
        }

        private void buttonExitForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void LoadEmployees()
        {
            try
            {
                // Lấy danh sách người dùng từ service
                var users = _userService.GetUsers();

                // Xóa dữ liệu cũ
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                // Cấu trúc cột
                dataGridView2.Columns.Add("Employee", "Nhân viên");
                dataGridView2.Columns.Add("UserCode", "Mã nhân viên");
                dataGridView2.Columns.Add("Email", "Email");
                dataGridView2.Columns.Add("Status", "Trạng thái");

                // Thêm dữ liệu vào bảng
                foreach (var u in users)
                {
                    dataGridView2.Rows.Add(
                        u.fullName ?? "(Chưa có tên)",
                        u.userCode ?? "N/A",
                        u.email ?? "Không có email",
                        u.Status.ToString()
                    );
                }

                // Căn giữa và tự động giãn cột
                dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void RefreshBannedWebList()
        {
            try
            {
                // Lấy danh sách từ service
                var bannedList = _bannedWebService.GetAllBannedWebsites();

                // Xóa dữ liệu cũ
                dataGridView3.Rows.Clear();
                dataGridView3.Columns.Clear();

                // Tạo cột
                dataGridView3.Columns.Add("URL", "URL");
                dataGridView3.Columns.Add("Description", "Mô tả");
                dataGridView3.Columns.Add("CreatedAt", "Ngày tạo");

                // Thêm dữ liệu
                foreach (var item in bannedList)
                {
                    dataGridView3.Rows.Add(item.Url, item.Reason, item.CreatedAt.ToString("g"));
                }

                // Căn giữa và tự động giãn cột
                dataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách website cấm: " + ex.Message);
            }
        }

        private void ButtonRefeshData_Click(object sender, EventArgs e)
        {
            RefreshBannedWebList();
        }
    }
}
