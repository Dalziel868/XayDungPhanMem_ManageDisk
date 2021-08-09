using DTO.Customers;
using IViews_Presenters.Disks;
using ManageDisk_XDPM.RegexExpression;
using ManageDisk_XDPM.Views.Charge;
using Presenters.Disk;
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
    public partial class frmReturnDisk : Form,IReturnDisk
    {
        public int DiskId
        {
            get
            {
                if (!string.IsNullOrEmpty(txtIdDisk.Text))
                    return int.Parse(txtIdDisk.Text);
                else
                    return -1;
            }
        }

        public int ListOrderOnHold {
            get
            {
                return _listOrderOnhold++;
            }
            
        }

        private DiskReturnPresenter _presenter;
        private int _listOrderOnhold = 0;
        public frmReturnDisk()
        {
            InitializeComponent();
           
            _presenter = new DiskReturnPresenter(this);
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
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
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
        private void MessageOnHold()
        {
            CusTomerForRentDiskDto customerDto = _presenter.GetCustomerReserve();
            if (customerDto != null)
            {
                string titleName = _presenter.GetTitleName();
                DialogResult dialog = MessageBox.Show($"Tên: {customerDto.FullName}, Điện Thoại: {customerDto.Phone}",$"Tiêu Đề: {titleName}",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                if(dialog==DialogResult.OK)
                {
                    ShowPopupNotifi("THÀNH CÔNG", "Đã xác nhận đặt đĩa với khách hàng");
                }
                else if(dialog==DialogResult.Cancel)
                {
                    _presenter.removeOnholdToCustomer();
                    MessageOnHold();
                }
            }
        }
        private void btnReturnDisk_Click(object sender, EventArgs e)
        {
            decimal returnDisk = _presenter.ReturnDisk();
            if(returnDisk==0)
            {
                ShowPopupNotifi("THÀNH CÔNG", $"Xác nhận đã trả đĩa có ID: {this.DiskId} đúng hạn");
               
                  txtIdDisk.SelectAll();
                  txtIdDisk.Focus();

                bool onHold = _presenter.OnHoldToDisk();
                if (onHold)
                {
                    MessageOnHold();
                }

            }
            else if(returnDisk>0)
            {
                DialogResult dialog = MessageBox.Show($"Bạn đã trả đĩa bị trễ hạn rồi! Tổng phí trễ là {string.Format("{0:#,###.00} Vnd", returnDisk)}.\nCó muốn thanh toán phí trễ bây giờ không?", "TRẢ ĐĨA BỊ TRỄ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if(dialog==DialogResult.Yes)
                {
                    int customerId = _presenter.GetIdOfCustomer();
                    frmPayChargeLate payCharge = new frmPayChargeLate(customerId);
                    payCharge.ShowDialog();

                }
                txtIdDisk.SelectAll();
                txtIdDisk.Focus();

                bool onHold = _presenter.OnHoldToDisk();
                if (onHold)
                {
                    MessageOnHold();
                }

            }    
            else
            {
                MessageBox.Show("Không tìm thấy Đĩa phù hợp","TRẢ ĐĨA KHÔNG THÀNH CÔNG",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtIdDisk.Focus();
                txtIdDisk.SelectAll();
            }

           

        }

        private void frmReturnDisk_Load(object sender, EventArgs e)
        {
            if (!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }
        }

        private void txtIdDisk_Leave(object sender, EventArgs e)
        {
            bool regexNumber = RegularExpression.isNumber(txtIdDisk.Text);
            if (!regexNumber)
            {
                MessageBox.Show("ID của đĩa không đúng định dạng, kiểm tra lại", "SAI ĐỊNH DẠNG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdDisk.SelectAll();
                txtIdDisk.Focus();
            }
        }
    }
}
