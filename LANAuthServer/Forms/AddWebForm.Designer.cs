namespace LANAuthServer.Forms
{
    partial class AddWebForm
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
            this.textBoxAddDescription = new System.Windows.Forms.TextBox();
            this.textBoxAddURLWeb = new System.Windows.Forms.TextBox();
            this.buttonAddWebBanned = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAddDescription);
            this.groupBox1.Controls.Add(this.textBoxAddURLWeb);
            this.groupBox1.Controls.Add(this.buttonAddWebBanned);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 236);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // textBoxAddDescription
            // 
            this.textBoxAddDescription.Location = new System.Drawing.Point(28, 129);
            this.textBoxAddDescription.Name = "textBoxAddDescription";
            this.textBoxAddDescription.Size = new System.Drawing.Size(361, 22);
            this.textBoxAddDescription.TabIndex = 4;
            // 
            // textBoxAddURLWeb
            // 
            this.textBoxAddURLWeb.Location = new System.Drawing.Point(26, 52);
            this.textBoxAddURLWeb.Name = "textBoxAddURLWeb";
            this.textBoxAddURLWeb.Size = new System.Drawing.Size(363, 22);
            this.textBoxAddURLWeb.TabIndex = 3;
            // 
            // buttonAddWebBanned
            // 
            this.buttonAddWebBanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddWebBanned.Location = new System.Drawing.Point(144, 173);
            this.buttonAddWebBanned.Name = "buttonAddWebBanned";
            this.buttonAddWebBanned.Size = new System.Drawing.Size(119, 41);
            this.buttonAddWebBanned.TabIndex = 3;
            this.buttonAddWebBanned.Text = "Xác nhận";
            this.buttonAddWebBanned.UseVisualStyleBackColor = true;
            this.buttonAddWebBanned.Click += new System.EventHandler(this.buttonAddWebBanned_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mô tả:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(130, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Thêm Web cấm";
            // 
            // AddWebForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 288);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Name = "AddWebForm";
            this.Text = "AddWebForm";
            this.Load += new System.EventHandler(this.AddWebForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAddDescription;
        private System.Windows.Forms.TextBox textBoxAddURLWeb;
        private System.Windows.Forms.Button buttonAddWebBanned;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}