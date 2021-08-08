
namespace ManageDisk_XDPM.Views.Disks
{
    partial class frmReserveDisk
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
            this.txtTitleName = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstvListTitle = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReserveDisk = new System.Windows.Forms.Button();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstvtitleReserved = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtTitleName
            // 
            this.txtTitleName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTitleName.Location = new System.Drawing.Point(481, 88);
            this.txtTitleName.Name = "txtTitleName";
            this.txtTitleName.Size = new System.Drawing.Size(361, 132);
            this.txtTitleName.TabIndex = 0;
            this.txtTitleName.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(380, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiêu Đề:";
            // 
            // lstvListTitle
            // 
            this.lstvListTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstvListTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstvListTitle.CheckBoxes = true;
            this.lstvListTitle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstvListTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvListTitle.ForeColor = System.Drawing.Color.Black;
            this.lstvListTitle.FullRowSelect = true;
            this.lstvListTitle.GridLines = true;
            this.lstvListTitle.HideSelection = false;
            this.lstvListTitle.Location = new System.Drawing.Point(100, 287);
            this.lstvListTitle.Name = "lstvListTitle";
            this.lstvListTitle.Size = new System.Drawing.Size(849, 284);
            this.lstvListTitle.TabIndex = 2;
            this.lstvListTitle.UseCompatibleStateImageBehavior = false;
            this.lstvListTitle.View = System.Windows.Forms.View.Details;
            this.lstvListTitle.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstvListTitle_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Tiêu Đề";
            this.columnHeader1.Width = 228;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Tiêu Đề";
            this.columnHeader2.Width = 605;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.BackColor = System.Drawing.Color.Yellow;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(880, 127);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 49);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReserveDisk
            // 
            this.btnReserveDisk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReserveDisk.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnReserveDisk.FlatAppearance.BorderSize = 0;
            this.btnReserveDisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserveDisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReserveDisk.Location = new System.Drawing.Point(588, 600);
            this.btnReserveDisk.Name = "btnReserveDisk";
            this.btnReserveDisk.Size = new System.Drawing.Size(194, 61);
            this.btnReserveDisk.TabIndex = 3;
            this.btnReserveDisk.Text = "ĐẶT ĐĨA";
            this.btnReserveDisk.UseVisualStyleBackColor = false;
            this.btnReserveDisk.Click += new System.EventHandler(this.btnReserveDisk_Click);
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCustomerId.Location = new System.Drawing.Point(481, 36);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(361, 26);
            this.txtCustomerId.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(301, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Khách Hàng:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(950, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "DANH SÁCH ID ĐẶT:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(95, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "DANH SÁCH TÌM KIẾM:";
            // 
            // lstvtitleReserved
            // 
            this.lstvtitleReserved.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstvtitleReserved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstvtitleReserved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvtitleReserved.ForeColor = System.Drawing.Color.Black;
            this.lstvtitleReserved.FullRowSelect = true;
            this.lstvtitleReserved.HideSelection = false;
            this.lstvtitleReserved.Location = new System.Drawing.Point(955, 287);
            this.lstvtitleReserved.MultiSelect = false;
            this.lstvtitleReserved.Name = "lstvtitleReserved";
            this.lstvtitleReserved.Size = new System.Drawing.Size(267, 284);
            this.lstvtitleReserved.TabIndex = 2;
            this.lstvtitleReserved.UseCompatibleStateImageBehavior = false;
            this.lstvtitleReserved.View = System.Windows.Forms.View.Tile;
            this.lstvtitleReserved.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstvtitleReserved_MouseDoubleClick);
            // 
            // frmReserveDisk
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1319, 673);
            this.ControlBox = false;
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.btnReserveDisk);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstvtitleReserved);
            this.Controls.Add(this.lstvListTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitleName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReserveDisk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ĐẶT ĐĨA QUA TIÊU ĐỀ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReserveDisk_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtTitleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstvListTitle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnReserveDisk;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstvtitleReserved;
    }
}