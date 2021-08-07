
namespace ManageDisk_XDPM.Views.Disks
{
    partial class frmReturnDisk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnDisk));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdDisk = new System.Windows.Forms.TextBox();
            this.btnReturnDisk = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập ID Đĩa:";
            // 
            // txtIdDisk
            // 
            this.txtIdDisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdDisk.Location = new System.Drawing.Point(341, 88);
            this.txtIdDisk.Name = "txtIdDisk";
            this.txtIdDisk.Size = new System.Drawing.Size(609, 30);
            this.txtIdDisk.TabIndex = 1;
            // 
            // btnReturnDisk
            // 
            this.btnReturnDisk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReturnDisk.FlatAppearance.BorderSize = 0;
            this.btnReturnDisk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReturnDisk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta;
            this.btnReturnDisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnDisk.Location = new System.Drawing.Point(591, 147);
            this.btnReturnDisk.Name = "btnReturnDisk";
            this.btnReturnDisk.Size = new System.Drawing.Size(96, 49);
            this.btnReturnDisk.TabIndex = 2;
            this.btnReturnDisk.Text = "Trả Đĩa";
            this.btnReturnDisk.UseVisualStyleBackColor = true;
            this.btnReturnDisk.Click += new System.EventHandler(this.btnReturnDisk_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(337, 224);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(613, 433);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmReturnDisk
            // 
            this.AcceptButton = this.btnReturnDisk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1302, 680);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReturnDisk);
            this.Controls.Add(this.txtIdDisk);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReturnDisk";
            this.Text = "Trả Đĩa Đã Thuê";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdDisk;
        private System.Windows.Forms.Button btnReturnDisk;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}