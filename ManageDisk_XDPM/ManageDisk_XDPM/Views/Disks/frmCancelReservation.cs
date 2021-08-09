using DTO.Customers;
using DTO.Titles;
using IViews_Presenters.frmCancelReservation;
using ManageDisk_XDPM.RegexExpression;
using Presenters.frmCancelReservation;
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
    public partial class frmCancelReservation : Form, ICancelReservation
    {
        private CancelReservationPresenter _presenter;
        public frmCancelReservation()
        {
            InitializeComponent();
            _presenter = new CancelReservationPresenter(this);
           
        }

        public int CustomerID {
            get
            {
                if (string.IsNullOrEmpty(txtidCustomer.Text))
                    return -1;
                return int.Parse(txtidCustomer.Text);
            }
            
        }
        public int TitleID {
            get
            {
                if(cboListReservation.SelectedIndex>=0)
                {
                    return int.Parse(cboListReservation.SelectedValue.ToString());
                }
                return -1;
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
                    Label lbl = (Label)btns;
                    lbl.ForeColor = ThemeColor.SecondaryColor;

                }


            }

          
        }
        private void MapDataToCombobox()
        {
            List<TitleToReserveDto> listTitle = _presenter.GetListTitleReserved().ToList();
            if (listTitle.Count > 0)
            {
                cboListReservation.DataSource = listTitle;
                cboListReservation.DisplayMember = "Name";
                cboListReservation.ValueMember = "Id";
            }
            else
            {
                cboListReservation.DataSource = null;
                MessageBox.Show("Khách hàng không có đĩa đặt trước", "KHÔNG TÌM THẤY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtidCustomer.Clear();

            }    
               
            

        }

        private void txtidCustomer_Leave(object sender, EventArgs e)
        {
            bool regexNumber = RegularExpression.isNumber(txtidCustomer.Text);
            if(!string.IsNullOrEmpty(txtidCustomer.Text) && regexNumber)
            {
                CustomerToCancelReservation dto = _presenter.GetCustomer();
                if (dto != null)
                {
                    lblfullname.Text = dto.FullName;
                    lblphone.Text = dto.Phone;
                    MapDataToCombobox();
                }
                else
                {

                    MessageBox.Show("Không tìm thấy khách hàng, vui lòng kiểm tra lại ID đã nhập", "KHÔNG TÌM THẤY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtidCustomer.SelectAll();
                    txtidCustomer.Focus();
                }
            }
            else if (!regexNumber)
            {
                MessageBox.Show("ID Khách hàng không đúng định dạng, kiểm tra lại", "SAI ĐỊNH DẠNG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtidCustomer.Focus();
                txtidCustomer.SelectAll();
            }    
                

        }

        private void frmCancelReservation_Load(object sender, EventArgs e)
        {
            if (!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }
        }
        private void ShowPopupNotifi(string title, string content, Image image)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = image;
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            bool cancel = _presenter.CancelReservation();
            if(cancel)
            {
                ShowPopupNotifi("THÀNH CÔNG", "Đã hủy đặt đĩa cho khách hàng", Properties.Resources.iconNotice);
                txtidCustomer.Clear();
                cboListReservation.DataSource = null;
            }
            else
                MessageBox.Show("Hủy đặt đĩa không thành công, vui lòng kiểm tra lại", "KHÔNG THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
