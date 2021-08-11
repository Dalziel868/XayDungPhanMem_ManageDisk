using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageDisk_XDPM.Views.Disks
{
    public partial class frmReportStatus : Form
    {
        public frmReportStatus()
        {
            InitializeComponent();
        }

        private void columnForOnshelf()
        {
            ColumnHeader columnTitle = new ColumnHeader();
            columnTitle.Text = "Tiêu Đề";
            columnTitle.Width = 1239;

            lstvListReport.Columns.Add(columnTitle);
      
        }
        private void columnForRented()
        {
            ColumnHeader columnTitle = new ColumnHeader();
            columnTitle.Text = "Tiêu Đề";
            columnTitle.Width = 380;

            ColumnHeader columnID = new ColumnHeader();
            columnID.Text = "ID Khách Thuê";
            columnID.Width = 150;

            ColumnHeader columnPhone = new ColumnHeader();
            columnPhone.Text = "Số Điện Thoại";
            columnPhone.Width = 186;

            ColumnHeader columnName = new ColumnHeader();
            columnName.Text = "Tên Khách Thuê";
            columnName.Width = 282;

            ColumnHeader columnDuedate = new ColumnHeader();
            columnDuedate.Text = "Hạn Trả";
            columnDuedate.Width = 241;

            lstvListReport.Columns.Add(columnTitle);
            lstvListReport.Columns.Add(columnID);

            lstvListReport.Columns.Add(columnPhone);

            lstvListReport.Columns.Add(columnName);
            lstvListReport.Columns.Add(columnDuedate);

        }

        private void columnForOnhold()
        {
            ColumnHeader columnTitle = new ColumnHeader();
            columnTitle.Text = "Tiêu Đề";
            columnTitle.Width = 450;

            ColumnHeader columnID = new ColumnHeader();
            columnID.Text = "ID Khách Thuê";
            columnID.Width = 165;

            ColumnHeader columnPhone = new ColumnHeader();
            columnPhone.Text = "Số Điện Thoại";
            columnPhone.Width = 247;

            ColumnHeader columnName = new ColumnHeader();
            columnName.Text = "Tên Khách Thuê";
            columnName.Width = 378;

            lstvListReport.Columns.Add(columnTitle);
            lstvListReport.Columns.Add(columnID);

            lstvListReport.Columns.Add(columnPhone);

            lstvListReport.Columns.Add(columnName);
        }

        private void frmReportStatus_Load(object sender, EventArgs e)
        {
           
        }

        private void rdoOnshelf_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnshelf.Checked)
            {
                lstvListReport.Clear();
                columnForOnshelf();
            }
               
        }

        private void rdoRented_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRented.Checked)
            {
                lstvListReport.Clear();
                columnForRented();
            }
                
        }

        private void rdoOnhold_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOnhold.Checked)
            {
                lstvListReport.Clear();
                columnForOnhold();
            }
               
        }
    }
}
