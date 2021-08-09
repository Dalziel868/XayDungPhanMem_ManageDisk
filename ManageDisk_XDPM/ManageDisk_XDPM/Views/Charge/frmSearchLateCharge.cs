using IViews_Presenters.frmSearchLateCharge;
using ManageDisk_XDPM.RegexExpression;
using Presenters.frmSearchLateCharge;
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
    public partial class frmSearchLateCharge : Form, ISearchLateCharge
    {
        private SearchLateChargePresenter _presenter;
        public int CustomerID
        {
            get
            {
                if (string.IsNullOrEmpty(txtidCustomer.Text))
                    return -1;
                return int.Parse(txtidCustomer.Text);
            }
        }

        public frmSearchLateCharge()
        {
            InitializeComponent();
            _presenter = new SearchLateChargePresenter(this);
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

        private void frmSearchLateCharge_Load(object sender, EventArgs e)
        {
            if (!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }
        }

        private void btnSearchLateCharge_Click(object sender, EventArgs e)
        {

            try
            {
                decimal totalLateCharge = _presenter.GetTotalLateCharge();
                if(totalLateCharge==0)
                {
                    MessageBox.Show("Khách hàng không có phí trễ", "KHÔNG CÓ PHÍ TRỄ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult dialog = MessageBox.Show($"Tổng phí trễ của Khách hàng là: {string.Format("{0:#,###.00} Vnd", totalLateCharge)}\n1. Chọn YES để ghi nhận thanh toán\n2. Chọn NO để xem chi tiết phí trễ\n3. Chọn Cancel để thoát","KẾT QUẢ PHÍ TRỄ",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
                if(dialog==DialogResult.Yes)
                {
                    frmPayChargeLate frmpay = new frmPayChargeLate(this.CustomerID);
                    frmpay.ShowDialog();
                }
                if(dialog==DialogResult.No)
                {
                    frmInfoLateCharge frmInfo = new frmInfoLateCharge(this.CustomerID, totalLateCharge);
                    frmInfo.ShowDialog();
                }
                txtidCustomer.SelectAll();
                txtidCustomer.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "NHẬP THIẾU DỮ LIỆU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtidCustomer_Leave(object sender, EventArgs e)
        {
            bool regexNumber = RegularExpression.isNumber(txtidCustomer.Text);
            if(!string.IsNullOrEmpty(txtidCustomer.Text) && !regexNumber)
            {
                MessageBox.Show("ID Đĩa chỉ toàn là số, không chứa ký tự đặc biệt khác", "SAI ĐỊNH DẠNG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtidCustomer.SelectAll();
                txtidCustomer.Focus();
            }
        }
    }
}
