namespace LANAuthServer.Forms
{
    partial class DeleteEmployeeForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDelByUserCode = new System.Windows.Forms.TextBox();
            this.buttonDelEmployee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDelByUserCode);
            this.groupBox1.Controls.Add(this.buttonDelEmployee);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 151);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // textBoxDelByUserCode
            // 
            this.textBoxDelByUserCode.Location = new System.Drawing.Point(26, 52);
            this.textBoxDelByUserCode.Name = "textBoxDelByUserCode";
            this.textBoxDelByUserCode.Size = new System.Drawing.Size(363, 22);
            this.textBoxDelByUserCode.TabIndex = 3;
            // 
            // buttonDelEmployee
            // 
            this.buttonDelEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelEmployee.Location = new System.Drawing.Point(144, 98);
            this.buttonDelEmployee.Name = "buttonDelEmployee";
            this.buttonDelEmployee.Size = new System.Drawing.Size(119, 41);
            this.buttonDelEmployee.TabIndex = 3;
            this.buttonDelEmployee.Text = "Xác nhận";
            this.buttonDelEmployee.UseVisualStyleBackColor = true;
            this.buttonDelEmployee.Click += new System.EventHandler(this.buttonDelEmployee_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập mã nhân viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(145, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Xóa nhân viên";
            // 
            // DeleteEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 206);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Name = "DeleteEmployeeForm";
            this.Text = "DeleteEmployeeFormcs";
            this.Load += new System.EventHandler(this.DeleteEmployeeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDelByUserCode;
        private System.Windows.Forms.Button buttonDelEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}