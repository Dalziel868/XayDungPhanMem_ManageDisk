using DTO.BillDetails;
using DTO.Customers;
using IViews_Presenters.frmRemoveLateCharge;
using ManageDisk_XDPM.RegexExpression;
using Presenters.frmRemoveLateCharge;
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

namespace ManageDisk_XDPM.Views.Manager
{
    public partial class frmRemoveLateCharge : Form, IRemoveLateCharge
    {
        public int CustomerID
        {
            get
            {
                if (string.IsNullOrEmpty(txtidCustomer.Text))
                    return -1;
                return int.Parse(txtidCustomer.Text);
            }
        }

        public List<Guid> ListRowID
        {
            get
            {
                List<Guid> listGuid = new List<Guid>();
                foreach (ListViewItem item in lstvListCharge.Items)
                {
                    if (item.Checked)
                        listGuid.Add(Guid.Parse(item.Tag.ToString()));
                }
                return listGuid;
            }
        }

        private readonly RemoveLateChargePresenter _presenter;
        private decimal _totalLateCharge = 0;
        private decimal _totalChargeWillMinus = 0;
       
        public frmRemoveLateCharge()
        {
            InitializeComponent();
            _presenter = new RemoveLateChargePresenter(this);
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
                if (btns.GetType() == typeof(ListView))
                {
                    ListView lstv = (ListView)btns;
                    lstv.ForeColor = ThemeColor.PrimaryColor;

                }


            }

            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.SecondaryColor;
            lblTotalLateCharge.ForeColor = ThemeColor.SecondaryColor;
            label3.ForeColor = ThemeColor.SecondaryColor;
            label4.ForeColor = ThemeColor.SecondaryColor;
           
        }

        private void frmRemoveLateCharge_Load(object sender, EventArgs e)
        {
            if (!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }
        }
        private void ShowPopupNotifi(string title, string content)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.icon404;
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
        private void btnFindLateCharge_Click(object sender, EventArgs e)
        {
            _totalLateCharge = 0;
            lblTotalLateCharge.Text = string.Format("{0:#,###.00} Vnd", _totalLateCharge);
            List<BillDetailForRemoveLateCharge> listLateCharge=null;
            try
            {
                listLateCharge = _presenter.GetListLateChargeOfOneCustomer().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MÃ KHÁCH HÀNG CÓ VẤN ĐỀ!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            if(listLateCharge.Count==0)
            {
                ShowPopupNotifi("KHÔNG TÌM THẤY PHÍ TRỄ!", "Khách hàng này hiện tại không tìm thấy khoản phí trễ nào");
                lstvListCharge.Items.Clear();
            }
            else
            {
                lstvListCharge.Items.Clear();
                foreach (var item in listLateCharge)
                {
                    ListViewItem lstItem = addItemToListView(item);
                    lstvListCharge.Items.Add(lstItem);
                }
                
            }
        }
        private void AddCharge(decimal money)
        {
            _totalLateCharge += money;
            lblTotalLateCharge.Text = string.Format("{0:#,###.00} Vnd", _totalLateCharge);
        }
        //private void MinusCharge(decimal money)
        //{
        //    _totalLateCharge -= money;
        //    lblTotalLateCharge.Text = string.Format("{0:#,###.00} Vnd", _totalLateCharge);
        //}

        private ListViewItem addItemToListView(BillDetailForRemoveLateCharge dto)
        {
            ListViewItem lstItem = new ListViewItem(dto.DiskName);
            lstItem.SubItems.Add(dto.DueDate.ToString("dd/MM/yyyy"));
            DateTime returnDateIfNull = dto.ReturnDate ?? DateTime.Now;
            lstItem.SubItems.Add(returnDateIfNull.ToString("dd/MM/yyyy HH:mm"));
            lstItem.SubItems.Add(dto.NumberOfDaysLate.ToString());
            lstItem.SubItems.Add(string.Format("{0:#,###.00}", dto.LateCharge));
            lstItem.Tag = dto.RowID;

            AddCharge(dto.LateCharge);
            return lstItem;
        }

        private void lstvListCharge_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            decimal money = Convert.ToDecimal(lstvListCharge.Items[e.Index].SubItems[4].Text.Replace(",",""));
            if(e.NewValue==CheckState.Checked)
            {
                _totalChargeWillMinus += money;
            }
            else if(e.NewValue==CheckState.Unchecked)
            {
                _totalChargeWillMinus -= money;
            }
        }

        private void txtidCustomer_Leave(object sender, EventArgs e)
        {
            bool regexNumber = RegularExpression.isNumber(txtidCustomer.Text);
            if(!regexNumber && !string.IsNullOrEmpty(txtidCustomer.Text))
            {
                MessageBox.Show("Mã khách hàng phải là số nguyên", "SAI ĐỊNH DẠNG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtidCustomer.SelectAll();
                txtidCustomer.Focus();
            }
            else if(regexNumber && !string.IsNullOrEmpty(txtidCustomer.Text))
            {
                CustomerToCancelReservation dto = _presenter.GetCustomer();
                if (dto != null)
                {
                    lblFullName.Text = dto.FullName;
                    lblPhone.Text = dto.Phone;
                  
                }
                else
                {

                    MessageBox.Show("Không tìm thấy khách hàng, vui lòng kiểm tra lại ID đã nhập", "KHÔNG TÌM THẤY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtidCustomer.SelectAll();
                    txtidCustomer.Focus();
                }
            }


        }

        private void btnDeleteLateCharge_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show($"Xác nhận xóa khoản nợ: {string.Format("{0:#,###.00} Vnd", _totalChargeWillMinus)}", "XEM KỸ TRƯỚC KHI XÓA!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(dialog==DialogResult.Yes)
            {
                bool deleteLateCharge = _presenter.DeleteLateCharge();
                if(deleteLateCharge)
                {
                    ShowPopupNotifi("XÓA NỢ THÀNH CÔNG", $"Đã xóa khoản nợ {string.Format("{0:#,###.00} Vnd", _totalChargeWillMinus)}");
                    _totalLateCharge = 0;
                    lblTotalLateCharge.Text = string.Format("{0:#,###.00} Vnd", _totalLateCharge);
                    List<BillDetailForRemoveLateCharge> listLateCharge = _presenter.GetListLateChargeOfOneCustomer().ToList();
                    lstvListCharge.Items.Clear();
                    foreach (var item in listLateCharge)
                    {
                        ListViewItem lstItem = addItemToListView(item);
                        lstvListCharge.Items.Add(lstItem);
                    }

                }
                else
                {
                    MessageBox.Show("Có gì đó không ổn, hãy báo quản lý để kiểm tra lại!", "KHÔNG THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }    
            }
            
        }
    }
}
