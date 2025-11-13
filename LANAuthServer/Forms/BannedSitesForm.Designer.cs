namespace LANAuthServer.forms
{
    partial class BannedSitesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.titleClient = new System.Windows.Forms.Label();
            this.view = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TopPanelBox = new System.Windows.Forms.GroupBox();
            this.LabelTotalWebBan = new System.Windows.Forms.Label();
            this.TotalWebBanned = new System.Windows.Forms.Label();
            this.LabelTotalViolate = new System.Windows.Forms.Label();
            this.LabelTotalEmployeeOnline = new System.Windows.Forms.Label();
            this.labelTotalEmployee = new System.Windows.Forms.Label();
            this.Totalviolate = new System.Windows.Forms.Label();
            this.TotalEmployeeOnline = new System.Windows.Forms.Label();
            this.TotalEmployee = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonRefeshViPham = new System.Windows.Forms.Button();
            this.LabelTotalListViolate = new System.Windows.Forms.Label();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.groupBoxViolate = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.LabelSearch = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonRefeshUser = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonRegister = new System.Windows.Forms.Button();
            this.LabelTotalEmployeeList = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ButtonSearchEmployee = new System.Windows.Forms.Button();
            this.textBoxSearchEmployee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ButtonDeleteWeb = new System.Windows.Forms.Button();
            this.ButtonWebBan = new System.Windows.Forms.Button();
            this.LabelTotalWebBannedList = new System.Windows.Forms.Label();
            this.buttonRefeshBanned = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ButtonNotification = new System.Windows.Forms.Button();
            this.textBoxNonfication = new System.Windows.Forms.TextBox();
            this.buttonExitForm = new System.Windows.Forms.Button();
            this.view.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.TopPanelBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxViolate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // titleClient
            // 
            this.titleClient.AutoSize = true;
            this.titleClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleClient.Location = new System.Drawing.Point(445, 25);
            this.titleClient.Name = "titleClient";
            this.titleClient.Size = new System.Drawing.Size(276, 25);
            this.titleClient.TabIndex = 1;
            this.titleClient.Text = "LAN Authentication System";
            // 
            // view
            // 
            this.view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.view.Controls.Add(this.tabPage1);
            this.view.Controls.Add(this.tabPage2);
            this.view.Controls.Add(this.tabPage3);
            this.view.Controls.Add(this.tabPage4);
            this.view.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view.ItemSize = new System.Drawing.Size(230, 35);
            this.view.Location = new System.Drawing.Point(-5, 86);
            this.view.MinimumSize = new System.Drawing.Size(930, 511);
            this.view.Name = "view";
            this.view.SelectedIndex = 0;
            this.view.Size = new System.Drawing.Size(1238, 564);
            this.view.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.view.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.TopPanelBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1230, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dashboard";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(-2, 219);
            this.chart1.MinimumSize = new System.Drawing.Size(915, 272);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1223, 272);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // TopPanelBox
            // 
            this.TopPanelBox.Controls.Add(this.LabelTotalWebBan);
            this.TopPanelBox.Controls.Add(this.TotalWebBanned);
            this.TopPanelBox.Controls.Add(this.LabelTotalViolate);
            this.TopPanelBox.Controls.Add(this.LabelTotalEmployeeOnline);
            this.TopPanelBox.Controls.Add(this.labelTotalEmployee);
            this.TopPanelBox.Controls.Add(this.Totalviolate);
            this.TopPanelBox.Controls.Add(this.TotalEmployeeOnline);
            this.TopPanelBox.Controls.Add(this.TotalEmployee);
            this.TopPanelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopPanelBox.Location = new System.Drawing.Point(7, 20);
            this.TopPanelBox.Name = "TopPanelBox";
            this.TopPanelBox.Size = new System.Drawing.Size(1214, 184);
            this.TopPanelBox.TabIndex = 0;
            this.TopPanelBox.TabStop = false;
            this.TopPanelBox.Text = "Tổng quan";
            // 
            // LabelTotalWebBan
            // 
            this.LabelTotalWebBan.AutoSize = true;
            this.LabelTotalWebBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalWebBan.Location = new System.Drawing.Point(236, 148);
            this.LabelTotalWebBan.Name = "LabelTotalWebBan";
            this.LabelTotalWebBan.Size = new System.Drawing.Size(27, 20);
            this.LabelTotalWebBan.TabIndex = 7;
            this.LabelTotalWebBan.Text = "16";
            // 
            // TotalWebBanned
            // 
            this.TotalWebBanned.AutoSize = true;
            this.TotalWebBanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalWebBanned.Location = new System.Drawing.Point(14, 148);
            this.TotalWebBanned.Name = "TotalWebBanned";
            this.TotalWebBanned.Size = new System.Drawing.Size(182, 20);
            this.TotalWebBanned.TabIndex = 6;
            this.TotalWebBanned.Text = "Tổng các website cấm:";
            // 
            // LabelTotalViolate
            // 
            this.LabelTotalViolate.AutoSize = true;
            this.LabelTotalViolate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalViolate.Location = new System.Drawing.Point(245, 110);
            this.LabelTotalViolate.Name = "LabelTotalViolate";
            this.LabelTotalViolate.Size = new System.Drawing.Size(18, 20);
            this.LabelTotalViolate.TabIndex = 5;
            this.LabelTotalViolate.Text = "0";
            // 
            // LabelTotalEmployeeOnline
            // 
            this.LabelTotalEmployeeOnline.AutoSize = true;
            this.LabelTotalEmployeeOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalEmployeeOnline.Location = new System.Drawing.Point(245, 74);
            this.LabelTotalEmployeeOnline.Name = "LabelTotalEmployeeOnline";
            this.LabelTotalEmployeeOnline.Size = new System.Drawing.Size(18, 20);
            this.LabelTotalEmployeeOnline.TabIndex = 4;
            this.LabelTotalEmployeeOnline.Text = "6";
            // 
            // labelTotalEmployee
            // 
            this.labelTotalEmployee.AutoSize = true;
            this.labelTotalEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalEmployee.Location = new System.Drawing.Point(188, 35);
            this.labelTotalEmployee.Name = "labelTotalEmployee";
            this.labelTotalEmployee.Size = new System.Drawing.Size(27, 20);
            this.labelTotalEmployee.TabIndex = 3;
            this.labelTotalEmployee.Text = "15";
            // 
            // Totalviolate
            // 
            this.Totalviolate.AutoSize = true;
            this.Totalviolate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Totalviolate.Location = new System.Drawing.Point(10, 110);
            this.Totalviolate.Name = "Totalviolate";
            this.Totalviolate.Size = new System.Drawing.Size(205, 20);
            this.Totalviolate.TabIndex = 2;
            this.Totalviolate.Text = "Tổng số vi phạm hôm nay:";
            // 
            // TotalEmployeeOnline
            // 
            this.TotalEmployeeOnline.AutoSize = true;
            this.TotalEmployeeOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalEmployeeOnline.Location = new System.Drawing.Point(10, 74);
            this.TotalEmployeeOnline.Name = "TotalEmployeeOnline";
            this.TotalEmployeeOnline.Size = new System.Drawing.Size(199, 20);
            this.TotalEmployeeOnline.TabIndex = 1;
            this.TotalEmployeeOnline.Text = "Tổng số nhân viên online:";
            // 
            // TotalEmployee
            // 
            this.TotalEmployee.AutoSize = true;
            this.TotalEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalEmployee.Location = new System.Drawing.Point(10, 35);
            this.TotalEmployee.Name = "TotalEmployee";
            this.TotalEmployee.Size = new System.Drawing.Size(150, 20);
            this.TotalEmployee.TabIndex = 0;
            this.TotalEmployee.Text = "Tổng số nhân viên:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonRefeshViPham);
            this.tabPage2.Controls.Add(this.LabelTotalListViolate);
            this.tabPage2.Controls.Add(this.LabelTotal);
            this.tabPage2.Controls.Add(this.groupBoxViolate);
            this.tabPage2.Controls.Add(this.ButtonSearch);
            this.tabPage2.Controls.Add(this.textBoxSearch);
            this.tabPage2.Controls.Add(this.LabelSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1230, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Danh sách vi phạm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonRefeshViPham
            // 
            this.buttonRefeshViPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefeshViPham.Location = new System.Drawing.Point(1055, 10);
            this.buttonRefeshViPham.Name = "buttonRefeshViPham";
            this.buttonRefeshViPham.Size = new System.Drawing.Size(126, 49);
            this.buttonRefeshViPham.TabIndex = 6;
            this.buttonRefeshViPham.Text = "Refesh";
            this.buttonRefeshViPham.UseVisualStyleBackColor = true;
            // 
            // LabelTotalListViolate
            // 
            this.LabelTotalListViolate.AutoSize = true;
            this.LabelTotalListViolate.Location = new System.Drawing.Point(93, 462);
            this.LabelTotalListViolate.Name = "LabelTotalListViolate";
            this.LabelTotalListViolate.Size = new System.Drawing.Size(90, 20);
            this.LabelTotalListViolate.TabIndex = 5;
            this.LabelTotalListViolate.Text = "12 vi phạm";
            // 
            // LabelTotal
            // 
            this.LabelTotal.AutoSize = true;
            this.LabelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotal.Location = new System.Drawing.Point(25, 460);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(62, 22);
            this.LabelTotal.TabIndex = 4;
            this.LabelTotal.Text = "Tổng:";
            // 
            // groupBoxViolate
            // 
            this.groupBoxViolate.Controls.Add(this.dataGridView1);
            this.groupBoxViolate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxViolate.Location = new System.Drawing.Point(7, 65);
            this.groupBoxViolate.Name = "groupBoxViolate";
            this.groupBoxViolate.Size = new System.Drawing.Size(1190, 364);
            this.groupBoxViolate.TabIndex = 3;
            this.groupBoxViolate.TabStop = false;
            this.groupBoxViolate.Text = "Danh sách vi phạm";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1168, 337);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(780, 17);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(101, 32);
            this.ButtonSearch.TabIndex = 2;
            this.ButtonSearch.Text = "Tìm";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(162, 20);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(612, 27);
            this.textBoxSearch.TabIndex = 1;
            // 
            // LabelSearch
            // 
            this.LabelSearch.AutoSize = true;
            this.LabelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSearch.Location = new System.Drawing.Point(41, 25);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(90, 22);
            this.LabelSearch.TabIndex = 0;
            this.LabelSearch.Text = "Tìm kiếm";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonRefeshUser);
            this.tabPage3.Controls.Add(this.ButtonDelete);
            this.tabPage3.Controls.Add(this.ButtonRegister);
            this.tabPage3.Controls.Add(this.LabelTotalEmployeeList);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.ButtonSearchEmployee);
            this.tabPage3.Controls.Add(this.textBoxSearchEmployee);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1230, 521);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Quản lí nhân viên";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonRefeshUser
            // 
            this.buttonRefeshUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefeshUser.Location = new System.Drawing.Point(1054, 10);
            this.buttonRefeshUser.Name = "buttonRefeshUser";
            this.buttonRefeshUser.Size = new System.Drawing.Size(126, 49);
            this.buttonRefeshUser.TabIndex = 14;
            this.buttonRefeshUser.Text = "Refesh";
            this.buttonRefeshUser.UseVisualStyleBackColor = true;
            this.buttonRefeshUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(1016, 446);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(165, 47);
            this.ButtonDelete.TabIndex = 13;
            this.ButtonDelete.Text = "Xóa nhân viên";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonRegister
            // 
            this.ButtonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRegister.Location = new System.Drawing.Point(832, 446);
            this.ButtonRegister.Name = "ButtonRegister";
            this.ButtonRegister.Size = new System.Drawing.Size(165, 47);
            this.ButtonRegister.TabIndex = 12;
            this.ButtonRegister.Text = "Thêm nhân viên";
            this.ButtonRegister.UseVisualStyleBackColor = true;
            this.ButtonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // LabelTotalEmployeeList
            // 
            this.LabelTotalEmployeeList.AutoSize = true;
            this.LabelTotalEmployeeList.Location = new System.Drawing.Point(92, 459);
            this.LabelTotalEmployeeList.Name = "LabelTotalEmployeeList";
            this.LabelTotalEmployeeList.Size = new System.Drawing.Size(103, 20);
            this.LabelTotalEmployeeList.TabIndex = 11;
            this.LabelTotalEmployeeList.Text = "16 nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tổng:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1190, 364);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhân viên";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 27);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1168, 337);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // ButtonSearchEmployee
            // 
            this.ButtonSearchEmployee.Location = new System.Drawing.Point(781, 14);
            this.ButtonSearchEmployee.Name = "ButtonSearchEmployee";
            this.ButtonSearchEmployee.Size = new System.Drawing.Size(101, 32);
            this.ButtonSearchEmployee.TabIndex = 8;
            this.ButtonSearchEmployee.Text = "Tìm";
            this.ButtonSearchEmployee.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchEmployee
            // 
            this.textBoxSearchEmployee.Location = new System.Drawing.Point(161, 17);
            this.textBoxSearchEmployee.Name = "textBoxSearchEmployee";
            this.textBoxSearchEmployee.Size = new System.Drawing.Size(614, 27);
            this.textBoxSearchEmployee.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tìm kiếm";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ButtonDeleteWeb);
            this.tabPage4.Controls.Add(this.ButtonWebBan);
            this.tabPage4.Controls.Add(this.LabelTotalWebBannedList);
            this.tabPage4.Controls.Add(this.buttonRefeshBanned);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Location = new System.Drawing.Point(4, 39);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1230, 521);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Web cấm";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // ButtonDeleteWeb
            // 
            this.ButtonDeleteWeb.Location = new System.Drawing.Point(1013, 439);
            this.ButtonDeleteWeb.Name = "ButtonDeleteWeb";
            this.ButtonDeleteWeb.Size = new System.Drawing.Size(165, 47);
            this.ButtonDeleteWeb.TabIndex = 21;
            this.ButtonDeleteWeb.Text = "Xóa Web";
            this.ButtonDeleteWeb.UseVisualStyleBackColor = true;
            this.ButtonDeleteWeb.Click += new System.EventHandler(this.ButtonDeleteWeb_Click);
            // 
            // ButtonWebBan
            // 
            this.ButtonWebBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonWebBan.Location = new System.Drawing.Point(829, 439);
            this.ButtonWebBan.Name = "ButtonWebBan";
            this.ButtonWebBan.Size = new System.Drawing.Size(165, 47);
            this.ButtonWebBan.TabIndex = 20;
            this.ButtonWebBan.Text = "Thêm Web cấm";
            this.ButtonWebBan.UseVisualStyleBackColor = true;
            this.ButtonWebBan.Click += new System.EventHandler(this.ButtonWebBan_Click);
            // 
            // LabelTotalWebBannedList
            // 
            this.LabelTotalWebBannedList.AutoSize = true;
            this.LabelTotalWebBannedList.Location = new System.Drawing.Point(89, 452);
            this.LabelTotalWebBannedList.Name = "LabelTotalWebBannedList";
            this.LabelTotalWebBannedList.Size = new System.Drawing.Size(108, 20);
            this.LabelTotalWebBannedList.TabIndex = 19;
            this.LabelTotalWebBannedList.Text = "9 web bị cấm";
            // 
            // buttonRefeshBanned
            // 
            this.buttonRefeshBanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefeshBanned.Location = new System.Drawing.Point(1051, 6);
            this.buttonRefeshBanned.Name = "buttonRefeshBanned";
            this.buttonRefeshBanned.Size = new System.Drawing.Size(126, 49);
            this.buttonRefeshBanned.TabIndex = 3;
            this.buttonRefeshBanned.Text = "Refesh";
            this.buttonRefeshBanned.UseVisualStyleBackColor = true;
            this.buttonRefeshBanned.Click += new System.EventHandler(this.ButtonRefeshData_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 450);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tổng:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1190, 364);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách Web cấm";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 27);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(1168, 337);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(786, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 32);
            this.button3.TabIndex = 16;
            this.button3.Text = "Tìm";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(158, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(622, 27);
            this.textBox1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tìm kiếm";
            // 
            // ButtonNotification
            // 
            this.ButtonNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNotification.Location = new System.Drawing.Point(12, 658);
            this.ButtonNotification.Name = "ButtonNotification";
            this.ButtonNotification.Size = new System.Drawing.Size(126, 49);
            this.ButtonNotification.TabIndex = 4;
            this.ButtonNotification.Text = "Thông báo";
            this.ButtonNotification.UseVisualStyleBackColor = true;
            // 
            // textBoxNonfication
            // 
            this.textBoxNonfication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNonfication.Location = new System.Drawing.Point(144, 670);
            this.textBoxNonfication.Name = "textBoxNonfication";
            this.textBoxNonfication.Size = new System.Drawing.Size(904, 27);
            this.textBoxNonfication.TabIndex = 5;
            this.textBoxNonfication.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonExitForm
            // 
            this.buttonExitForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitForm.Location = new System.Drawing.Point(1054, 659);
            this.buttonExitForm.Name = "buttonExitForm";
            this.buttonExitForm.Size = new System.Drawing.Size(126, 49);
            this.buttonExitForm.TabIndex = 6;
            this.buttonExitForm.Text = "Thoát";
            this.buttonExitForm.UseVisualStyleBackColor = true;
            this.buttonExitForm.Click += new System.EventHandler(this.buttonExitForm_Click);
            // 
            // BannedSitesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 730);
            this.Controls.Add(this.buttonExitForm);
            this.Controls.Add(this.textBoxNonfication);
            this.Controls.Add(this.ButtonNotification);
            this.Controls.Add(this.view);
            this.Controls.Add(this.titleClient);
            this.MinimumSize = new System.Drawing.Size(1250, 737);
            this.Name = "BannedSitesForm";
            this.Text = "BannedSitesForm";
            this.Load += new System.EventHandler(this.BannedSitesForm_Load);
            this.view.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.TopPanelBox.ResumeLayout(false);
            this.TopPanelBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBoxViolate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleClient;
        private System.Windows.Forms.TabControl view;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox TopPanelBox;
        private System.Windows.Forms.Label Totalviolate;
        private System.Windows.Forms.Label TotalEmployeeOnline;
        private System.Windows.Forms.Label TotalEmployee;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label LabelTotalViolate;
        private System.Windows.Forms.Label LabelTotalEmployeeOnline;
        private System.Windows.Forms.Label labelTotalEmployee;
        private System.Windows.Forms.Label LabelTotalWebBan;
        private System.Windows.Forms.Label TotalWebBanned;
        private System.Windows.Forms.Button buttonRefeshBanned;
        private System.Windows.Forms.Button ButtonNotification;
        private System.Windows.Forms.TextBox textBoxNonfication;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label LabelSearch;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.GroupBox groupBoxViolate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label LabelTotalListViolate;
        private System.Windows.Forms.Label LabelTotal;
        private System.Windows.Forms.Label LabelTotalEmployeeList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button ButtonSearchEmployee;
        private System.Windows.Forms.TextBox textBoxSearchEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonRegister;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonDeleteWeb;
        private System.Windows.Forms.Button ButtonWebBan;
        private System.Windows.Forms.Label LabelTotalWebBannedList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExitForm;
        private System.Windows.Forms.Button buttonRefeshViPham;
        private System.Windows.Forms.Button buttonRefeshUser;
    }
}