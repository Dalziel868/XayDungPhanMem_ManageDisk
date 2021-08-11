
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoOnhold = new System.Windows.Forms.RadioButton();
            this.rdoRented = new System.Windows.Forms.RadioButton();
            this.rdoOnshelf = new System.Windows.Forms.RadioButton();
            this.lstvListReport = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoOnhold);
            this.panel1.Controls.Add(this.rdoRented);
            this.panel1.Controls.Add(this.rdoOnshelf);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1375, 94);
            this.panel1.TabIndex = 0;
            // 
            // rdoOnhold
            // 
            this.rdoOnhold.AutoSize = true;
            this.rdoOnhold.Location = new System.Drawing.Point(1041, 33);
            this.rdoOnhold.Name = "rdoOnhold";
            this.rdoOnhold.Size = new System.Drawing.Size(97, 29);
            this.rdoOnhold.TabIndex = 1;
            this.rdoOnhold.TabStop = true;
            this.rdoOnhold.Text = "Onhold";
            this.rdoOnhold.UseVisualStyleBackColor = true;
            this.rdoOnhold.CheckedChanged += new System.EventHandler(this.rdoOnhold_CheckedChanged);
            // 
            // rdoRented
            // 
            this.rdoRented.AutoSize = true;
            this.rdoRented.Location = new System.Drawing.Point(616, 33);
            this.rdoRented.Name = "rdoRented";
            this.rdoRented.Size = new System.Drawing.Size(95, 29);
            this.rdoRented.TabIndex = 1;
            this.rdoRented.TabStop = true;
            this.rdoRented.Text = "Rented";
            this.rdoRented.UseVisualStyleBackColor = true;
            this.rdoRented.CheckedChanged += new System.EventHandler(this.rdoRented_CheckedChanged);
            // 
            // rdoOnshelf
            // 
            this.rdoOnshelf.AutoSize = true;
            this.rdoOnshelf.Location = new System.Drawing.Point(181, 33);
            this.rdoOnshelf.Name = "rdoOnshelf";
            this.rdoOnshelf.Size = new System.Drawing.Size(101, 29);
            this.rdoOnshelf.TabIndex = 1;
            this.rdoOnshelf.Text = "Onshelf";
            this.rdoOnshelf.UseVisualStyleBackColor = true;
            this.rdoOnshelf.CheckedChanged += new System.EventHandler(this.rdoOnshelf_CheckedChanged);
            // 
            // lstvListReport
            // 
            this.lstvListReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstvListReport.CheckBoxes = true;
            this.lstvListReport.FullRowSelect = true;
            this.lstvListReport.GridLines = true;
            this.lstvListReport.HideSelection = false;
            this.lstvListReport.Location = new System.Drawing.Point(65, 111);
            this.lstvListReport.Name = "lstvListReport";
            this.lstvListReport.Size = new System.Drawing.Size(1244, 297);
            this.lstvListReport.TabIndex = 1;
            this.lstvListReport.UseCompatibleStateImageBehavior = false;
            this.lstvListReport.View = System.Windows.Forms.View.Details;
            // 
            // frmReportStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1375, 592);
            this.ControlBox = false;
            this.Controls.Add(this.lstvListReport);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Trạng Thái Đĩa";
            this.Load += new System.EventHandler(this.frmReportStatus_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lstvListReport;
        private System.Windows.Forms.RadioButton rdoOnhold;
        private System.Windows.Forms.RadioButton rdoRented;
        private System.Windows.Forms.RadioButton rdoOnshelf;
    }
}