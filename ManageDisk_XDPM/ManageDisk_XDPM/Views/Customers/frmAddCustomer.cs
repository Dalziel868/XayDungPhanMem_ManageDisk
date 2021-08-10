using DTO.Customers;
using IViews_Presenters;
using ManageDisk_XDPM.RegexExpression;
using Presenters;
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

namespace ManageDisk_XDPM.Customers
{
    public partial class frmAddCustomer : Form,IAddCustomer
    {
        private  CustomerForCreateDto _customerDto;
        private readonly CustomerForCreatePresenter _cuspresenter;
        public frmAddCustomer()
        {
            InitializeComponent();
            
            _cuspresenter = new CustomerForCreatePresenter(this);
          

        }

        

        public CustomerForCreateDto CustomerDto
        {
            get
            {
                if (_customerDto == null)
                    _customerDto = new CustomerForCreateDto();
                _customerDto.Phone = txtphone.Text;
                _customerDto.FullName = txtfullname.Text;
                _customerDto.HouseNumber_StreetName = txthousenumber.Text;
                _customerDto.Ward = txtward.Text;
                _customerDto.District = txtdistrict.Text;
                _customerDto.City = txtcity.Text;
                return _customerDto;
            }
            set
            {
                _customerDto = value;
                txtphone.Text = _customerDto.Phone;
                txtfullname.Text = _customerDto.FullName;
                txthousenumber.Text = _customerDto.HouseNumber_StreetName;
                txtward.Text = _customerDto.Ward;
                txtdistrict.Text = _customerDto.District;
                txtcity.Text = _customerDto.City;
            }
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                
                if(btns.GetType()==typeof(Panel))
                {
                    foreach (Control item in btns.Controls)
                    {
                        if(item.GetType()==typeof(Label))
                        {
                            item.ForeColor = ThemeColor.SecondaryColor;
                        }
                        if (item.GetType() == typeof(Button))
                        {
                            Button btn = (Button)item;
                            btn.BackColor = ThemeColor.PrimaryColor;
                            btn.ForeColor = Color.White;
                            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

                        }
                    }
                }
            }
           
            //label1.ForeColor = ThemeColor.PrimaryColor;
            //label2.ForeColor = ThemeColor.SecondaryColor;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int result = _cuspresenter.addCustomer();
            if(result>0)
            {
                ShowPopupNotifi("THÀNH CÔNG", $"Bạn vừa tạo thành công khách hàng {result}");
                //MessageBox.Show($"Bạn vừa tạo thành công khách hàng {result}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtfullname.Clear();
                txtphone.Clear();
                txthousenumber.Clear();
                txtward.Clear();
                txtdistrict.Clear();
                txtcity.Clear();
            }
               
            else
            {
                MessageBox.Show($"Thêm khách hàng không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                

           
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            if (!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }
        }

        private void txtphone_Leave(object sender, EventArgs e)
        {

            bool regex = RegularExpression.isPhone(txtphone.Text);
            if(regex==false)
            {
                MessageBox.Show("Số điện thoại không đúng định dạng", "SAI ĐỊNH DẠNG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtphone.SelectAll();
                txtphone.Focus();
            }
        }
    }
}
