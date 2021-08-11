using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Customers;
using IViews_Presenters;
using ManageDisk_XDPM.RegexExpression;
using Presenters;
using Presenters.frmUpdateCustomer;
using Tulpep.NotificationWindow;

namespace ManageDisk_XDPM.Customers
{
    public partial class frmUpdateCustomer : Form,IUpdateCustomer
    {
        private CustomerForUpdateDTO _customerDto;
        private readonly CustomerForUpdatePresenter _cuspresenter;


        public frmUpdateCustomer()
        {
            InitializeComponent();
            _cuspresenter = new CustomerForUpdatePresenter(this);
        }

        public CustomerForUpdateDTO CustomerDto
        {
            get
            {
                if (_customerDto == null)
                    _customerDto = new CustomerForUpdateDTO();
                _customerDto.Id = Convert.ToInt32(txtID.Text);
                _customerDto.Phone = txtPhone.Text;
                _customerDto.FullName = txtName.Text;
                _customerDto.HouseNumber_StreetName = txtNumberAddress.Text;
                _customerDto.Ward = txtWard.Text;
                _customerDto.District = txtDistrict.Text;
                _customerDto.City = txtCity.Text;
                return _customerDto;
            }
            set
            {
                _customerDto = value;
                txtID.Text = _customerDto.Id.ToString();
                txtPhone.Text = _customerDto.Phone;
                txtName.Text = _customerDto.FullName;
                txtNumberAddress.Text = _customerDto.HouseNumber_StreetName;
                txtWard.Text = _customerDto.Ward;
                txtDistrict.Text = _customerDto.District;
                txtCity.Text = _customerDto.City;
            }
        }
       
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {

                if (btns.GetType() == typeof(Panel))
                {
                    foreach (Control item in btns.Controls)
                    {
                        if (item.GetType() == typeof(GroupBox))
                        {
                            foreach (Control item2 in item.Controls)
                            {
                                if (item2.GetType() == typeof(Label))
                                {
                                    item2.ForeColor = ThemeColor.SecondaryColor;
                                }
                                if (item2.GetType() == typeof(Button))
                                {
                                    Button btn = (Button)item2;
                                    btn.BackColor = ThemeColor.PrimaryColor;
                                    btn.ForeColor = Color.White;
                                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

                                }
                            }
                        }

                    }
                }
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.SecondaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.PrimaryColor;
                }
            }

            //label1.ForeColor = ThemeColor.PrimaryColor;
            //label2.ForeColor = ThemeColor.SecondaryColor;
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmUpdateCustomer_Load(object sender, EventArgs e)
        {
            if (!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }
            DataToListView();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
           

        }
        private void DataToListView()
        {
            List<CustomerForUpdateDTO> listCustomer = _cuspresenter.GetListCustomer().ToList();
            if (listCustomer.Count > 0)
            {
                foreach (var item in listCustomer)
                {
                    ListViewItem lstItem = addItem(item);
                    lvwListCutomers.Items.Add(lstItem);
                }
            }

        }
        private ListViewItem addItem(CustomerForUpdateDTO item)
        {
            ListViewItem lstItem = new ListViewItem(item.Id.ToString());
            lstItem.SubItems.Add(item.FullName);
            lstItem.SubItems.Add(item.Phone);
            lstItem.SubItems.Add(item.HouseNumber_StreetName);
            lstItem.SubItems.Add(item.Ward);
            lstItem.SubItems.Add(item.District);
            lstItem.SubItems.Add(item.City);
            lstItem.Tag = item.Id;
            return lstItem;
        }

       

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lvwListCutomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwListCutomers.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwListCutomers.SelectedItems[0];
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                txtID.Text = item.SubItems[0].Text;
                txtName.Text = item.SubItems[1].Text;
                txtPhone.Text = item.SubItems[2].Text;
                txtNumberAddress.Text = item.SubItems[3].Text;
                txtWard.Text = item.SubItems[4].Text;
                txtDistrict.Text = item.SubItems[5].Text;
                txtCity.Text = item.SubItems[6].Text;
            }

        }

        private void btnCancer_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtNumberAddress.Text = string.Empty;
            txtWard.Text = string.Empty;
            txtDistrict.Text = string.Empty;
            txtCity.Text = string.Empty;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int result = _cuspresenter.updateCustomer();
            if (result > 0)
            {
                ShowPopupNotifi("THÀNH CÔNG", $"Cập nhật khách hàng thành công");
                //MessageBox.Show($"Bạn vừa tạo thành công khách hàng {result}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Clear();
                txtName.Clear();
                txtNumberAddress.Clear();
                txtPhone.Clear();
                txtDistrict.Clear();
                txtCity.Clear();
                txtID.Clear();
                lvwListCutomers.Items.Clear();
                lvwListCutomers.Refresh();
                DataToListView();
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }

            else
            {
                MessageBox.Show($"Cập nhật khách hàng không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                int result = _cuspresenter.deleteCustomer();
                if (result > 0)
                {

                    ShowPopupNotifi("THÀNH CÔNG", $"Xóa khách hàng thành công");
                    //MessageBox.Show($"Bạn vừa tạo thành công khách hàng {result}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Clear();
                    txtName.Clear();
                    txtNumberAddress.Clear();
                    txtPhone.Clear();
                    txtDistrict.Clear();
                    txtCity.Clear();
                    txtID.Clear();
                    lvwListCutomers.Items.Clear();
                    lvwListCutomers.Refresh();
                    DataToListView();
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                }

                else
                {
                    MessageBox.Show($"Xóa khách hàng không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
              
           

        }
    }
}
