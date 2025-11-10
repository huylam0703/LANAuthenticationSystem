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
            this.ButtonRefesh = new System.Windows.Forms.GroupBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.button1 = new System.Windows.Forms.Button();
            this.ButtonRefesh.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleClient
            // 
            this.titleClient.AutoSize = true;
            this.titleClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleClient.Location = new System.Drawing.Point(218, 30);
            this.titleClient.Name = "titleClient";
            this.titleClient.Size = new System.Drawing.Size(276, 25);
            this.titleClient.TabIndex = 0;
            this.titleClient.Text = "LAN Authentication System";
            // 
            // ButtonRefesh
            // 
            this.ButtonRefesh.Controls.Add(this.button1);
            this.ButtonRefesh.Controls.Add(this.labelEmail);
            this.ButtonRefesh.Controls.Add(this.label2);
            this.ButtonRefesh.Controls.Add(this.employeeCodeResult);
            this.ButtonRefesh.Controls.Add(this.nameResult);
            this.ButtonRefesh.Controls.Add(this.employeeCode);
            this.ButtonRefesh.Controls.Add(this.name);
            this.ButtonRefesh.Controls.Add(this.updateInfo);
            this.ButtonRefesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRefesh.Location = new System.Drawing.Point(3, 80);
            this.ButtonRefesh.Name = "ButtonRefesh";
            this.ButtonRefesh.Size = new System.Drawing.Size(704, 159);
            this.ButtonRefesh.TabIndex = 1;
            this.ButtonRefesh.TabStop = false;
            this.ButtonRefesh.Text = "Thông tin cá nhân:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(138, 106);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(53, 20);
            this.labelEmail.TabIndex = 7;
            this.labelEmail.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Emai:";
            // 
            // employeeCodeResult
            // 
            this.employeeCodeResult.AutoSize = true;
            this.employeeCodeResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeCodeResult.Location = new System.Drawing.Point(138, 73);
            this.employeeCodeResult.Name = "employeeCodeResult";
            this.employeeCodeResult.Size = new System.Drawing.Size(53, 20);
            this.employeeCodeResult.TabIndex = 5;
            this.employeeCodeResult.Text = "label4";
            // 
            // nameResult
            // 
            this.nameResult.AutoSize = true;
            this.nameResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameResult.Location = new System.Drawing.Point(138, 39);
            this.nameResult.Name = "nameResult";
            this.nameResult.Size = new System.Drawing.Size(53, 20);
            this.nameResult.TabIndex = 4;
            this.nameResult.Text = "label3";
            this.nameResult.Click += new System.EventHandler(this.nameResult_Click);
            // 
            // employeeCode
            // 
            this.employeeCode.AutoSize = true;
            this.employeeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeCode.Location = new System.Drawing.Point(10, 73);
            this.employeeCode.Name = "employeeCode";
            this.employeeCode.Size = new System.Drawing.Size(113, 20);
            this.employeeCode.TabIndex = 3;
            this.employeeCode.Text = "Mã nhân viên:";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(80, 39);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(580, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "Refesh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 419);
            this.Controls.Add(this.ButtonExitMain);
            this.Controls.Add(this.ButtonMini);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ButtonRefesh);
            this.Controls.Add(this.titleClient);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ButtonRefesh.ResumeLayout(false);
            this.ButtonRefesh.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleClient;
        private System.Windows.Forms.GroupBox ButtonRefesh;
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
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}