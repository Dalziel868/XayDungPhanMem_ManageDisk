using IViews_Presenters.Customers;
using Presenters.Customers;
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
using DTO.Disks;
using ManageDisk_XDPM.Views.Charge;

namespace ManageDisk_XDPM.Disks
{
    public partial class frmRentDisk : Form,ICustomerForRentDisk
    {

        private CustomerForRentDiskPresenter _present;
        private List<string> listId;
        private Decimal totalMoney=0;
        public frmRentDisk()
        {
            InitializeComponent();
            if (!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }
            _present = new CustomerForRentDiskPresenter(this);
        }
        //private void LoadIntoListBox()
        //{
        //    lstbAll.DataSource = _present.GetDiskToRent();
        //    lstbAll.DisplayMember = "Name";
        //    lstbAll.ValueMember = "Id";

        //    lstbAll.SelectedValueChanged += new EventHandler(lstbAll_SelectedValueChanged);
        //}
        private void AutoCompleteTextBox(List<string> listId)
        {
            
            if(listId.Count>0)
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                foreach (string item in listId)
                {
                    collection.Add(item);
                }
                txtDiskID.AutoCompleteCustomSource = collection;
            }
            
        }

        //private void lstbAll_SelectedValueChanged(object sender, EventArgs e)
        //{
            
        //}

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {

                if (btns.GetType() == typeof(Panel))
                {
                    foreach (Control item in btns.Controls)
                    {
                        if(item.GetType()==typeof(GroupBox))
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
                if(btns.GetType()==typeof(Button))
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

        public int CustomerID {
            get
            {
                return int.Parse(txtIdCustomer.Text);
            }
            set
            {
               txtIdCustomer.Text = value.ToString();
            }
        }

        public string DiskID {
            get
            {
                return txtDiskID.Text;
            }
           
        }

        public List<int> ListDiskId {

            get
            {
                //return listId.Select(int.Parse).ToList();
                List<int> listIdOfDisk = new List<int>();
                foreach (ListViewItem item in lstvListDisk.Items)
                {
                    listIdOfDisk.Add(Convert.ToInt16(item.Tag));
                }
                return listIdOfDisk;
            }
            
        }


        //private void btnsearchCustomer_Click(object sender, EventArgs e)
        //{
        //    if (!txtIdCustomer.Text.Trim().Equals(""))
        //    {
        //        CusTomerForRentDiskDto _cusDto = _present.GetCustomerToRentDisk();
        //        if(_cusDto==null)
        //            MessageBox.Show("ID không hợp lệ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        else
        //            lblInfor.Text = $"{_cusDto.FullName} - {_cusDto.Phone}";
        //    }
        //    else
        //        MessageBox.Show("ID không hợp lệ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //}

        private void frmRentDisk_Load(object sender, EventArgs e)
        {
            listId = _present.GetAllIdOfDiskToSelect();
            AutoCompleteTextBox(listId);
            
        }
        private void addItem(DiskForRent disk)
        {
            ListViewItem lstvItem = new ListViewItem(disk.Id.ToString());
            lstvItem.SubItems.Add(disk.Name);
            lstvItem.SubItems.Add(disk.CategoryName);
            lstvItem.SubItems.Add(string.Format("{0:#,###.00}", Convert.ToDecimal(disk.UnitPrice)));
            lstvItem.SubItems.Add(disk.RentTime.ToString());
            lstvItem.Tag = disk.Id;
            lstvListDisk.Items.Add(lstvItem);

            totalMoney += disk.UnitPrice ?? 0;
            lblTotalMoney.Text = string.Format("{0:#,###.00} Vnd", totalMoney);

            this.listId.Remove(disk.Id.ToString());
            AutoCompleteTextBox(this.listId);
        }
        private void addDiskToListView(DiskForRent disk)
        {
            if (lstvListDisk.Items.Count>0)
            {
                for (int i = 0; i < lstvListDisk.Items.Count; i++)
                {
                    
                    if (disk.Id == int.Parse(lstvListDisk.Items[i].Tag.ToString()))
                    {
                        MessageBox.Show("ID đĩa đã được đặt bên dưới", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                addItem(disk);

            }
            else
            {
                addItem(disk);
            }
           

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DiskForRent diskForRent = _present.GetDiskToRent();
            if(diskForRent!=null)
                addDiskToListView(diskForRent);
            else
                MessageBox.Show("ID đĩa không hợp lệ, kiểm tra lại", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txtDiskID.Clear();
            txtDiskID.Focus();
        }

        private void txtIdCustomer_Leave(object sender, EventArgs e)
        {
         
            if (!txtIdCustomer.Text.Trim().Equals(""))
            {
                CusTomerForRentDiskDto _cusDto = _present.GetCustomerToRentDisk();
                if (_cusDto == null)
                {
                    MessageBox.Show("ID Khách Hàng không hợp lệ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdCustomer.Focus();
                    txtIdCustomer.SelectAll();
                }  
                else
                    lblInfor.Text = $"{_cusDto.FullName} - {_cusDto.Phone}";
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtIdCustomer.Text))
            {
                MessageBox.Show("ID Khách Hàng chưa được nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(lstvListDisk.Items.Count==0)
            {
                MessageBox.Show("Bạn chưa chọn đĩa để thuê", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool rent = _present.ProcedureToRentDisk();
            if(rent)
            {
                decimal lateCharge = _present.GetTotalLateCharge();
                if (lateCharge > 0)
                {
                    DialogResult dialog = MessageBox.Show($"Quý khách có phí trễ hạn chưa Thanh Toán:\n1. Tổng tiền thuê lần này (bắt buộc): {string.Format("{0:#,###.00} Vnd", totalMoney)}\n2. Tổng Phí Trễ Hạn (tùy chọn): {string.Format("{0:#,###.00} Vnd", lateCharge)}\nTổng Tiền: {string.Format("{0:#,###.00} Vnd", totalMoney + lateCharge)}", "Khách Hàng Có Nợ Phí Cần Thanh Toán!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dialog == DialogResult.Yes)
                    {

                        frmPayChargeLate frmPayCharge = new frmPayChargeLate(totalMoney,this.CustomerID);
                        frmPayCharge.ShowDialog();
                       
                    }
                    else
                        MessageBox.Show($"Tổng tiền cần thanh toán: {string.Format("{0:#,###.00} Vnd", totalMoney)}", "Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show($"Tổng tiền cần thanh toán: {string.Format("{0:#,###.00} Vnd", totalMoney)}","Thanh Toán",MessageBoxButtons.OK,MessageBoxIcon.Information);


                ClearItems();
            }
            else
            {
                MessageBox.Show("Thủ tục thuê đĩa không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void removeItemInListView(ListViewItem item)
        {
            lstvListDisk.Items.Remove(item);
            totalMoney -= Convert.ToDecimal(item.SubItems[3].Text.Trim().Replace(",",""));
            lblTotalMoney.Text = string.Format("{0:#,###.00} Vnd", totalMoney);

            this.listId.Add(item.Tag.ToString());
            AutoCompleteTextBox(this.listId);
            if(totalMoney<=0)
            {
                lblTotalMoney.Text = "0";
            }
        }
        private void lstvListDisk_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            removeItemInListView(lstvListDisk.SelectedItems[0]);
            
        }
        private void ClearItems()
        {
            lstvListDisk.Items.Clear();
            totalMoney = 0;
            lblTotalMoney.Text = "0";
            listId = _present.GetAllIdOfDiskToSelect();
            AutoCompleteTextBox(listId);
        }
        private void btnClearList_Click(object sender, EventArgs e)
        {
            ClearItems();
        }
    }
}
