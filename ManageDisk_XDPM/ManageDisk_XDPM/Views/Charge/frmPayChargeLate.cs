using DTO.Charges;
using DTO.Customers;
using IViews_Presenters.Charges;
using Presenters.Charges;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageDisk_XDPM.Views.Charge
{
    public partial class frmPayChargeLate : Form,ICaculateLateCharge
    {
        private readonly Decimal _totalMoney=0;
        private readonly int _idCustomer;
        private readonly LateChargePresenter _present;
        private decimal _lateCharge = 0;
        public int CustomerID
        {
            get
            {
                return _idCustomer;
            }
        }

        public List<Guid> ListBillDetailID
        {
            get
            {
                List<Guid> listBillDetailID = new List<Guid>();
                foreach (ListViewItem item in lstvLateCharge.Items)
                {
                    if (item.Checked)
                        listBillDetailID.Add(Guid.Parse(item.Tag.ToString()));
                }
                return listBillDetailID;
            }
        }

        public frmPayChargeLate(Decimal totalMoney, int customerID)
        {
            InitializeComponent();
            _totalMoney = totalMoney;
            _idCustomer = customerID;
            _present = new LateChargePresenter(this);
        }
        public frmPayChargeLate(int customerID)
        {
            InitializeComponent();
          
            _present = new LateChargePresenter(this);
            _idCustomer = customerID;

        }
        private void MapCustomerToUI()
        {
            CustomerLateCharge customer = _present.GetOneCustomer();
            if(customer!=null)
            {
                lblIDCustomer.Text = _idCustomer.ToString();
                if (_totalMoney > 0)
                    lblFeeToRent.Text = string.Format("{0:#,###.00} Vnd", _totalMoney);
                else
                    lblFeeToRent.Text = "0";
                lblFullName.Text = customer.FullName;
                lblPhone.Text = customer.Phone;
                lbladdress.Text = $"{customer.HouseNumber_StreetName}, {customer.Ward}, {customer.District}, {customer.City}";
                if (_lateCharge + _totalMoney > 0)
                    lblTotalMoney.Text = string.Format("{0:#,###.00} Vnd", _lateCharge + _totalMoney);
                else
                    lblTotalMoney.Text = "0";
            }
        }
        private void DataToListView()
        {
            List<ChargeToPay> chargeToPays = _present.GetListChargeOfCusTomer().ToList();
            if(chargeToPays.Count>0)
            {
                foreach (var item in chargeToPays)
                {
                    ListViewItem lstItem = addItem(item);
                    lstvLateCharge.Items.Add(lstItem);
                }
            }
            
        }
        private ListViewItem addItem(ChargeToPay pay)
        {
            ListViewItem lstItem = new ListViewItem();
            lstItem.Text = string.Format("{0:#,###.00}", pay.LateCharge);
            lstItem.SubItems.Add(pay.NumberOfDaysLate.ToString());
            lstItem.Tag = pay.RowID;
            return lstItem;
        }
        private void frmPayChargeLate_Load(object sender, EventArgs e)
        {
            MapCustomerToUI();
            DataToListView();
        }

        private void lstvLateCharge_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue==CheckState.Checked)
            {
                _lateCharge += Convert.ToDecimal(lstvLateCharge.Items[e.Index].Text);
                lblTotalMoney.Text = string.Format("{0:#,###.00} Vnd", _lateCharge+_totalMoney);
            }
            else
            //if(e.NewValue==CheckState.Unchecked)
            {
                _lateCharge -= Convert.ToDecimal(lstvLateCharge.Items[e.Index].Text);
                if(_lateCharge+_totalMoney==0)
                {
                    lblTotalMoney.Text = "0";
                }
                else
                    lblTotalMoney.Text = string.Format("{0:#,###.00} Vnd", _lateCharge+_totalMoney);
            }
            
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(lstvLateCharge.Items.Count>0)
            {
                if (chkSelectAll.Checked)
                {
                    foreach (ListViewItem item in lstvLateCharge.Items)
                    {
                        item.Checked = true;
                    }
                }
                else
                {
                    foreach (ListViewItem item in lstvLateCharge.Items)
                    {
                        item.Checked = false;
                    }
                }
            }
           
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            bool payChargeResult = _present.PayLateCharge();
            if(payChargeResult)
            {
                MessageBox.Show($"Bạn đã thanh toán số tiền: {string.Format("{0:#,###.00} Vnd", _lateCharge + _totalMoney)}", "Thanh Toán Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Có thể bạn chưa chọn khoản phí trễ nào để thanh toán??", "Không Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChiTietPhiTre_Click(object sender, EventArgs e)
        {
            decimal totalLateCharge = 0;
            foreach (ListViewItem item in lstvLateCharge.Items)
            {
                totalLateCharge += decimal.Parse(item.Text.Replace(",", ""));
            }

            frmInfoLateCharge frmInfo = new frmInfoLateCharge(this.CustomerID, totalLateCharge);
            frmInfo.ShowDialog();
        }
    }
}
