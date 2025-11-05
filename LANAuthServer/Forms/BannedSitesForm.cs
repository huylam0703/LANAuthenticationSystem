using LANAuthServer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LANAuthServer.forms
{
    public partial class BannedSitesForm : Form
    {
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
            dataGridView1.Columns.Add("IpAndress", "Địa chỉ Ip");
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


            ///////////////////////////////////////
            // Danh sach nhan vien

            dataGridView2.Columns.Clear();

            // Tạo cột
            dataGridView2.Columns.Add("Employee", "Nhân Viên");
            dataGridView2.Columns.Add("IpAndress", "Địa chỉ Ip");
            dataGridView2.Columns.Add("Email", "Email");
            dataGridView2.Columns.Add("Status", "Trạng thái");

            // Thêm dữ liệu mẫu
            dataGridView2.Rows.Add("lam nhat huy", "363636", "huyhocgioi12@gmail.com", "Online");
            dataGridView2.Rows.Add("tran van phi", "PC-02", "phingu@gmail.com", "Offline");

            // Căn giữa các cột
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Tùy chỉnh kích thước cột
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            ///////////////////////////////////////
            // Danh sach web cấm

            dataGridView3.Columns.Clear();

            // Tạo cột
            dataGridView3.Columns.Add("URL", "URL");
            dataGridView3.Columns.Add("Description", "Mô tả");

            // Thêm dữ liệu mẫu
            dataGridView3.Rows.Add("facebook.com", "mạng xã hội cấm");
            dataGridView3.Rows.Add("chatgpt.com", "lộ thông tin bảo mật");

            // Căn giữa các cột
            dataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Tùy chỉnh kích thước cột
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
    }
}
