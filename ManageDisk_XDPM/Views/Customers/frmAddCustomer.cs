using DTO.Customers;
using IViews_Presenters;

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

namespace ManageDisk_XDPM.Customers
{
    public partial class frmAddCustomer : Form,IAddCustomer
    {
        private CustomerForCreateDto _customerDto;
        private CustomerForCreatePresenter _cuspresenter;
        public frmAddCustomer()
        {
            InitializeComponent();
            if(!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int result = _cuspresenter.addCustomer();
            if(result>0)
            {
                MessageBox.Show($"Bạn vừa tạo thành công khách hàng {result}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
