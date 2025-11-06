namespace LANAuthClient.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.titleClient = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.employeeCodeResult = new System.Windows.Forms.Label();
            this.nameResult = new System.Windows.Forms.Label();
            this.employeeCode = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.updateInfo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TimeMain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.monitoringStatus = new System.Windows.Forms.Label();
            this.ButtonMini = new System.Windows.Forms.Button();
            this.ButtonExitMain = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleClient
            // 
            this.titleClient.AutoSize = true;
            this.titleClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleClient.Location = new System.Drawing.Point(78, 34);
            this.titleClient.Name = "titleClient";
            this.titleClient.Size = new System.Drawing.Size(276, 25);
            this.titleClient.TabIndex = 0;
            this.titleClient.Text = "LAN Authentication System";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.employeeCodeResult);
            this.groupBox1.Controls.Add(this.nameResult);
            this.groupBox1.Controls.Add(this.employeeCode);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.updateInfo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 159);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cá nhân:";
            // 
            // employeeCodeResult
            // 
            this.employeeCodeResult.AutoSize = true;
            this.employeeCodeResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeCodeResult.Location = new System.Drawing.Point(128, 73);
            this.employeeCodeResult.Name = "employeeCodeResult";
            this.employeeCodeResult.Size = new System.Drawing.Size(53, 20);
            this.employeeCodeResult.TabIndex = 5;
            this.employeeCodeResult.Text = "label4";
            // 
            // nameResult
            // 
            this.nameResult.AutoSize = true;
            this.nameResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameResult.Location = new System.Drawing.Point(127, 39);
            this.nameResult.Name = "nameResult";
            this.nameResult.Size = new System.Drawing.Size(53, 20);
            this.nameResult.TabIndex = 4;
            this.nameResult.Text = "label3";
            // 
            // employeeCode
            // 
            this.employeeCode.AutoSize = true;
            this.employeeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeCode.Location = new System.Drawing.Point(9, 73);
            this.employeeCode.Name = "employeeCode";
            this.employeeCode.Size = new System.Drawing.Size(113, 20);
            this.employeeCode.TabIndex = 3;
            this.employeeCode.Text = "Mã nhân viên:";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(76, 39);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(42, 20);
            this.name.TabIndex = 2;
            this.name.Text = "Tên:";
            // 
            // updateInfo
            // 
            this.updateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateInfo.Location = new System.Drawing.Point(581, 12);
            this.updateInfo.Name = "updateInfo";
            this.updateInfo.Size = new System.Drawing.Size(116, 30);
            this.updateInfo.TabIndex = 1;
            this.updateInfo.Text = "Update";
            this.updateInfo.UseVisualStyleBackColor = true;
            this.updateInfo.Click += new System.EventHandler(this.updateInfo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TimeMain);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.monitoringStatus);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 106);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạng thái";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // TimeMain
            // 
            this.TimeMain.AutoSize = true;
            this.TimeMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeMain.Location = new System.Drawing.Point(85, 69);
            this.TimeMain.Name = "TimeMain";
            this.TimeMain.Size = new System.Drawing.Size(82, 20);
            this.TimeMain.TabIndex = 3;
            this.TimeMain.Text = "Thời gian:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // monitoringStatus
            // 
            this.monitoringStatus.AutoSize = true;
            this.monitoringStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monitoringStatus.Location = new System.Drawing.Point(9, 34);
            this.monitoringStatus.Name = "monitoringStatus";
            this.monitoringStatus.Size = new System.Drawing.Size(158, 20);
            this.monitoringStatus.TabIndex = 1;
            this.monitoringStatus.Text = "Trạng thái giám sát:";
            // 
            // ButtonMini
            // 
            this.ButtonMini.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonMini.Location = new System.Drawing.Point(134, 357);
            this.ButtonMini.Name = "ButtonMini";
            this.ButtonMini.Size = new System.Drawing.Size(126, 50);
            this.ButtonMini.TabIndex = 3;
            this.ButtonMini.Text = "Thu nhỏ";
            this.ButtonMini.UseVisualStyleBackColor = true;
            // 
            // ButtonExitMain
            // 
            this.ButtonExitMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExitMain.Location = new System.Drawing.Point(434, 357);
            this.ButtonExitMain.Name = "ButtonExitMain";
            this.ButtonExitMain.Size = new System.Drawing.Size(126, 50);
            this.ButtonExitMain.TabIndex = 4;
            this.ButtonExitMain.Text = "Thoát";
            this.ButtonExitMain.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Emai:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 419);
            this.Controls.Add(this.ButtonExitMain);
            this.Controls.Add(this.ButtonMini);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.titleClient);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleClient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label employeeCode;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button updateInfo;
        private System.Windows.Forms.Label employeeCodeResult;
        private System.Windows.Forms.Label nameResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label monitoringStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonMini;
        private System.Windows.Forms.Button ButtonExitMain;
        private System.Windows.Forms.Label TimeMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}