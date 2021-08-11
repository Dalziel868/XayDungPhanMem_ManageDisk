using DTO.Disks;
using IViews_Presenters.frmReportStatus;
using ManageDisk_XDPM.RegexExpression;
using Presenters.frmReportStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace ManageDisk_XDPM.Views.Disks
{
    public partial class frmReportStatus : Form, IReportStatus
    {
        private readonly ReportStatusDiskPresenter _presenter;
        public frmReportStatus()
        {
            InitializeComponent();
            _presenter = new ReportStatusDiskPresenter(this);
        }

        public int DiskID
        {
            get
            {
                if (string.IsNullOrEmpty(txtIdDisk.Text))
                    return -1;
                return int.Parse(txtIdDisk.Text);
            }
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {

                if (btns.GetType() == typeof(Button))
                {

                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                if (btns.GetType() == typeof(Label))
                {

                    Label btn = (Label)btns;
                   
                    btn.ForeColor = ThemeColor.PrimaryColor;
                   
                }
            }
            
        }
        private void frmReportStatus_Load(object sender, EventArgs e)
        {
            if (!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }
        }
        private void ShowPopupNotifi(string title, string content)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.iconNotice;
            //popup.TitleText = "THÀNH CÔNG";
            popup.TitleText = title;
            popup.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            popup.TitleColor = Color.FromArgb(10, 48, 240);
            //
            //popup.ContentText = $"Xác nhận đã trả đĩa có ID: {this.DiskId}";
            popup.ContentText = content;
            popup.ContentFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            popup.ContentHoverColor = Color.FromArgb(207, 4, 21);
            popup.Popup(); //show
        }
        private void btnReportDisk_Click(object sender, EventArgs e)
        {
            DiskDto dto = _presenter.GetInfoOfDisk();
            if(dto==null)
            {
                MessageBox.Show("Vui lòng kiểm tra lại mã đĩa, mã đĩa không hợp lệ", "MÃ ĐĨA KHÔNG ĐÚNG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbltitle.Text = "";
                lblstatus.Text = "";
                lblidcustomer.Text = "";
                lblcustomername.Text = "";
                lblphone.Text = "";
                lblduedate.Text = "";
                return;
            }    
            if(dto.GetType()==typeof(DiskOnshelfDto))
            {
                DiskOnshelfDto onshelfDto =(DiskOnshelfDto) dto;
                lbltitle.Text = onshelfDto.Name;
                lblstatus.Text = onshelfDto.C_Status;

                lblidcustomer.Text = "";
                lblcustomername.Text = "";
                lblphone.Text = "";
                lblduedate.Text = "";

                ShowPopupNotifi("ĐĨA ONSHELF", "Đã hiển thị báo cáo về đĩa");
            }
            else if(dto.GetType()==typeof(DiskOnHoldDto))
            {
                DiskOnHoldDto onholdDto = (DiskOnHoldDto)dto;
                lbltitle.Text = onholdDto.Name;
                lblstatus.Text = onholdDto.C_Status;
                lblidcustomer.Text = onholdDto.Id.ToString();
                lblcustomername.Text = onholdDto.FullName;
                lblphone.Text = onholdDto.Phone;
                lblduedate.Text = "";
                ShowPopupNotifi("ĐĨA Onhold", "Đã hiển thị báo cáo về đĩa");

            }
            else if(dto.GetType() == typeof(DiskRentedDto))
            {
                DiskRentedDto rentedDto = (DiskRentedDto)dto;

                lbltitle.Text = rentedDto.Name;
                lblstatus.Text = rentedDto.C_Status;
                lblidcustomer.Text = rentedDto.Id.ToString();
                lblcustomername.Text = rentedDto.FullName;
                lblphone.Text = rentedDto.Phone;
                lblduedate.Text = rentedDto.DueDate.ToString("dd/MM/yyyy HH:mm");

                ShowPopupNotifi("ĐĨA RENTED", "Đã hiển thị báo cáo về đĩa");

            }
            

        }

        private void txtIdDisk_Leave(object sender, EventArgs e)
        {
            bool regexNumber = RegularExpression.isNumber(txtIdDisk.Text);
            if(!string.IsNullOrEmpty(txtIdDisk.Text) && !regexNumber)
            {
                MessageBox.Show("Mã đĩa sai định dạng", "SAI ĐỊNH DẠNG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdDisk.SelectAll();
                txtIdDisk.Focus();
            }    
        }
    }
}
