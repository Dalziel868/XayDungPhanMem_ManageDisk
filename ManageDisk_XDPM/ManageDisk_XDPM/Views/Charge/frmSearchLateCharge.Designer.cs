
namespace ManageDisk_XDPM.Views.Charge
{
    partial class frmSearchLateCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchLateCharge));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSearchLateCharge = new System.Windows.Forms.Button();
            this.txtidCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(341, 210);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(613, 433);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnSearchLateCharge
            // 
            this.btnSearchLateCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearchLateCharge.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSearchLateCharge.FlatAppearance.BorderSize = 0;
            this.btnSearchLateCharge.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearchLateCharge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta;
            this.btnSearchLateCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchLateCharge.Location = new System.Drawing.Point(554, 124);
            this.btnSearchLateCharge.Name = "btnSearchLateCharge";
            this.btnSearchLateCharge.Size = new System.Drawing.Size(136, 53);
            this.btnSearchLateCharge.TabIndex = 1;
            this.btnSearchLateCharge.Text = "Tra Phí Trễ";
            this.btnSearchLateCharge.UseVisualStyleBackColor = true;
            this.btnSearchLateCharge.Click += new System.EventHandler(this.btnSearchLateCharge_Click);
            // 
            // txtidCustomer
            // 
            this.txtidCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtidCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidCustomer.Location = new System.Drawing.Point(341, 55);
            this.txtidCustomer.Name = "txtidCustomer";
            this.txtidCustomer.Size = new System.Drawing.Size(613, 32);
            this.txtidCustomer.TabIndex = 0;
            this.txtidCustomer.Leave += new System.EventHandler(this.txtidCustomer_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID Khách Hàng:";
            // 
            // frmSearchLateCharge
            // 
            this.AcceptButton = this.btnSearchLateCharge;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1295, 673);
            this.ControlBox = false;
            this.Controls.Add(this.btnSearchLateCharge);
            this.Controls.Add(this.txtidCustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSearchLateCharge";
            this.Text = "Tra Cứu Phí Trễ";
            this.Load += new System.EventHandler(this.frmSearchLateCharge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSearchLateCharge;
        private System.Windows.Forms.TextBox txtidCustomer;
        private System.Windows.Forms.Label label1;
    }
}