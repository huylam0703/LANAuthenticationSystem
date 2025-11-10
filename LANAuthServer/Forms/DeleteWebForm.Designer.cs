namespace LANAuthServer.Forms
{
    partial class DeleteWebForm
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
            this.textBoxAddURLWeb = new System.Windows.Forms.TextBox();
            this.buttonDeleteBannedWeb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAddURLWeb);
            this.groupBox1.Controls.Add(this.buttonDeleteBannedWeb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 156);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // textBoxAddURLWeb
            // 
            this.textBoxAddURLWeb.Location = new System.Drawing.Point(26, 52);
            this.textBoxAddURLWeb.Name = "textBoxAddURLWeb";
            this.textBoxAddURLWeb.Size = new System.Drawing.Size(363, 22);
            this.textBoxAddURLWeb.TabIndex = 3;
            // 
            // buttonDeleteBannedWeb
            // 
            this.buttonDeleteBannedWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteBannedWeb.Location = new System.Drawing.Point(139, 98);
            this.buttonDeleteBannedWeb.Name = "buttonDeleteBannedWeb";
            this.buttonDeleteBannedWeb.Size = new System.Drawing.Size(119, 41);
            this.buttonDeleteBannedWeb.TabIndex = 3;
            this.buttonDeleteBannedWeb.Text = "Xác nhận";
            this.buttonDeleteBannedWeb.UseVisualStyleBackColor = true;
            this.buttonDeleteBannedWeb.Click += new System.EventHandler(this.buttonDeleteBannedWeb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL Web";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Xóa Web cấm";
            // 
            // DeleteWebForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 210);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Name = "DeleteWebForm";
            this.Text = "DeleteWebForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAddURLWeb;
        private System.Windows.Forms.Button buttonDeleteBannedWeb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}