
namespace ManageDisk_XDPM.Views.Disks
{
    partial class frmReportStatus
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
            this.btnReportDisk = new System.Windows.Forms.Button();
            this.txtIdDisk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblstatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblidcustomer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblcustomername = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblphone = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblduedate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReportDisk
            // 
            this.btnReportDisk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReportDisk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReportDisk.FlatAppearance.BorderSize = 0;
            this.btnReportDisk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReportDisk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta;
            this.btnReportDisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportDisk.Location = new System.Drawing.Point(633, 103);
            this.btnReportDisk.Name = "btnReportDisk";
            this.btnReportDisk.Size = new System.Drawing.Size(130, 51);
            this.btnReportDisk.TabIndex = 1;
            this.btnReportDisk.Text = "Báo Cáo";
            this.btnReportDisk.UseVisualStyleBackColor = true;
            this.btnReportDisk.Click += new System.EventHandler(this.btnReportDisk_Click);
            // 
            // txtIdDisk
            // 
            this.txtIdDisk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdDisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdDisk.Location = new System.Drawing.Point(412, 45);
            this.txtIdDisk.Name = "txtIdDisk";
            this.txtIdDisk.Size = new System.Drawing.Size(609, 30);
            this.txtIdDisk.TabIndex = 0;
            this.txtIdDisk.Leave += new System.EventHandler(this.txtIdDisk_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập ID Đĩa:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tiêu Đề:";
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.Location = new System.Drawing.Point(565, 181);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(0, 26);
            this.lbltitle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Trạng Thái:";
            // 
            // lblstatus
            // 
            this.lblstatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.Location = new System.Drawing.Point(565, 237);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(0, 26);
            this.lblstatus.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mã Khách Hàng:";
            // 
            // lblidcustomer
            // 
            this.lblidcustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblidcustomer.AutoSize = true;
            this.lblidcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidcustomer.Location = new System.Drawing.Point(565, 290);
            this.lblidcustomer.Name = "lblidcustomer";
            this.lblidcustomer.Size = new System.Drawing.Size(0, 26);
            this.lblidcustomer.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tên Khách Hàng:";
            // 
            // lblcustomername
            // 
            this.lblcustomername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcustomername.AutoSize = true;
            this.lblcustomername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcustomername.Location = new System.Drawing.Point(565, 338);
            this.lblcustomername.Name = "lblcustomername";
            this.lblcustomername.Size = new System.Drawing.Size(0, 26);
            this.lblcustomername.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Số Điện Thoại:";
            // 
            // lblphone
            // 
            this.lblphone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblphone.AutoSize = true;
            this.lblphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblphone.Location = new System.Drawing.Point(565, 383);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(0, 26);
            this.lblphone.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày tới hạn:";
            // 
            // lblduedate
            // 
            this.lblduedate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblduedate.AutoSize = true;
            this.lblduedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblduedate.Location = new System.Drawing.Point(565, 427);
            this.lblduedate.Name = "lblduedate";
            this.lblduedate.Size = new System.Drawing.Size(0, 26);
            this.lblduedate.TabIndex = 3;
            // 
            // frmReportStatus
            // 
            this.AcceptButton = this.btnReportDisk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1336, 592);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReportDisk);
            this.Controls.Add(this.txtIdDisk);
            this.Controls.Add(this.lblduedate);
            this.Controls.Add(this.lblphone);
            this.Controls.Add(this.lblcustomername);
            this.Controls.Add(this.lblidcustomer);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo Cáo Trạng Thái Đĩa";
            this.Load += new System.EventHandler(this.frmReportStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReportDisk;
        private System.Windows.Forms.TextBox txtIdDisk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblidcustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblcustomername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblduedate;
    }
}