
namespace ManageDisk_XDPM.Views.Manager
{
    partial class frmRemoveLateCharge
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtidCustomer = new System.Windows.Forms.TextBox();
            this.lstvListCharge = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFindLateCharge = new System.Windows.Forms.Button();
            this.btnDeleteLateCharge = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalLateCharge = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Khách Hàng:";
            // 
            // txtidCustomer
            // 
            this.txtidCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtidCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidCustomer.Location = new System.Drawing.Point(425, 37);
            this.txtidCustomer.Name = "txtidCustomer";
            this.txtidCustomer.Size = new System.Drawing.Size(471, 34);
            this.txtidCustomer.TabIndex = 0;
            this.txtidCustomer.Leave += new System.EventHandler(this.txtidCustomer_Leave);
            // 
            // lstvListCharge
            // 
            this.lstvListCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstvListCharge.CheckBoxes = true;
            this.lstvListCharge.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstvListCharge.FullRowSelect = true;
            this.lstvListCharge.GridLines = true;
            this.lstvListCharge.HideSelection = false;
            this.lstvListCharge.Location = new System.Drawing.Point(114, 267);
            this.lstvListCharge.Name = "lstvListCharge";
            this.lstvListCharge.Size = new System.Drawing.Size(1128, 377);
            this.lstvListCharge.TabIndex = 2;
            this.lstvListCharge.UseCompatibleStateImageBehavior = false;
            this.lstvListCharge.View = System.Windows.Forms.View.Details;
            this.lstvListCharge.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstvListCharge_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Đĩa";
            this.columnHeader1.Width = 343;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ngày Tới Hạn";
            this.columnHeader2.Width = 191;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày Trả";
            this.columnHeader3.Width = 207;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số Ngày Trễ";
            this.columnHeader4.Width = 177;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Phí Trễ";
            this.columnHeader5.Width = 205;
            // 
            // btnFindLateCharge
            // 
            this.btnFindLateCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFindLateCharge.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnFindLateCharge.FlatAppearance.BorderSize = 2;
            this.btnFindLateCharge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFindLateCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindLateCharge.Location = new System.Drawing.Point(920, 29);
            this.btnFindLateCharge.Name = "btnFindLateCharge";
            this.btnFindLateCharge.Size = new System.Drawing.Size(157, 52);
            this.btnFindLateCharge.TabIndex = 3;
            this.btnFindLateCharge.Text = "Tìm Phí Trễ";
            this.btnFindLateCharge.UseVisualStyleBackColor = true;
            this.btnFindLateCharge.Click += new System.EventHandler(this.btnFindLateCharge_Click);
            // 
            // btnDeleteLateCharge
            // 
            this.btnDeleteLateCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteLateCharge.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteLateCharge.FlatAppearance.BorderSize = 2;
            this.btnDeleteLateCharge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeleteLateCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLateCharge.Location = new System.Drawing.Point(625, 667);
            this.btnDeleteLateCharge.Name = "btnDeleteLateCharge";
            this.btnDeleteLateCharge.Size = new System.Drawing.Size(161, 74);
            this.btnDeleteLateCharge.TabIndex = 4;
            this.btnDeleteLateCharge.Text = "Xóa Phí Trễ";
            this.btnDeleteLateCharge.UseVisualStyleBackColor = true;
            this.btnDeleteLateCharge.Click += new System.EventHandler(this.btnDeleteLateCharge_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng Nợ:";
            // 
            // lblTotalLateCharge
            // 
            this.lblTotalLateCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalLateCharge.AutoSize = true;
            this.lblTotalLateCharge.Location = new System.Drawing.Point(215, 225);
            this.lblTotalLateCharge.Name = "lblTotalLateCharge";
            this.lblTotalLateCharge.Size = new System.Drawing.Size(24, 26);
            this.lblTotalLateCharge.TabIndex = 5;
            this.lblTotalLateCharge.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ Tên:";
            // 
            // lblFullName
            // 
            this.lblFullName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(425, 92);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(0, 26);
            this.lblFullName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số Điện Thoại:";
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(425, 147);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(0, 26);
            this.lblPhone.TabIndex = 0;
            // 
            // frmRemoveLateCharge
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1351, 757);
            this.ControlBox = false;
            this.Controls.Add(this.lblTotalLateCharge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteLateCharge);
            this.Controls.Add(this.btnFindLateCharge);
            this.Controls.Add(this.lstvListCharge);
            this.Controls.Add(this.txtidCustomer);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRemoveLateCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xóa Phí Trễ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRemoveLateCharge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidCustomer;
        private System.Windows.Forms.ListView lstvListCharge;
        private System.Windows.Forms.Button btnFindLateCharge;
        private System.Windows.Forms.Button btnDeleteLateCharge;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalLateCharge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPhone;
    }
}