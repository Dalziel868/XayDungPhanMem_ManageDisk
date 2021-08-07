using DTO.BillDetails;
using DTO.Customers;
using DTO.Disks;
using IViews_Presenters.frmInfoLateCharge;
using Presenters.frmInfoLateCharge;
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
    public partial class frmInfoLateCharge : Form, IInfoCharge
    {
        private readonly int _customerID;
        private readonly decimal _totalLateCharge;
        private InfoLateChargePresenter _presenter;
        private int _diskID;
        public frmInfoLateCharge(int CustomerID,decimal totalLateCharge)
        {
            InitializeComponent();
            _customerID = CustomerID;
            _totalLateCharge = totalLateCharge;
            _presenter = new InfoLateChargePresenter(this);
        }

        public int CustomerID
        {
            get
            {
                return _customerID;
            }
        }

        public int DiskID
        {
            get
            {
                return _diskID;
            }
            set
            { 
                    _diskID = value;
            }
        }

        public List<int> ListDiskID {
            get
            {
                List<int> listDiskId = new List<int>();
                foreach (TreeNode node in trvDiskTitles.Nodes)
                {
                    foreach (TreeNode node2 in node.Nodes)
                    {
                        listDiskId.Add(int.Parse(node2.Tag.ToString()));
                    }
                        
                }
                return listDiskId;
            }
        }

        private void MapUICustomerInfo()
        {
            CustomerInfoLateCharge customer = _presenter.GetCustomerInInfoCharge();
            if(customer!=null)
            {
                lblIDCustomer.Text = customer.Id.ToString();
                lblFullName.Text = customer.FullName;
                lblPhone.Text = customer.Phone;
                lbladdress.Text = $"{customer.HouseNumber_StreetName}, {customer.Ward}, {customer.District}, {customer.City}";
                lblFeeToRent.Text= string.Format("{0:#,###.00} Vnd", _totalLateCharge);
            }
            

        }

        private void frmInfoLateCharge_Load(object sender, EventArgs e)
        {
            
            MapUICustomerInfo();
            MapToTreeView();
           
        }
        private void MapToTreeView()
        {
            trvDiskTitles.Nodes.Clear();
            TreeNode rootNode = new TreeNode("All Disk");
            rootNode.Tag = -1;
            List<Disk_Title> listDiskTitle = _presenter.GetDiskAndTitle().ToList();
            foreach (var item in listDiskTitle)
            {
                TreeNode tChild1 = new TreeNode(item.Name);
                foreach (var item2 in item.TitleNames)
                {
                    TreeNode tChild2 = new TreeNode(item2);
                    tChild2.Tag = item.DiskID;

                    tChild1.Nodes.Add(tChild2);
                }
                tChild1.Tag = item.DiskID;
                rootNode.Nodes.Add(tChild1);
            }
            trvDiskTitles.Nodes.Add(rootNode);
            trvDiskTitles.ExpandAll();
        }
        private ListViewItem AddItem(BillDetailInfoLateCharge info)
        {
            ListViewItem lstItem = new ListViewItem(info.DiskName);
            lstItem.SubItems.Add(info.DueDate.ToString("dd/MM/yyyy"));

            DateTime returnDateIfNull = info.ReturnDate ?? DateTime.Now;
            lstItem.SubItems.Add(returnDateIfNull.ToString("dd/MM/yyyy HH:mm"));
            lstItem.SubItems.Add(info.NumberOfDaysLate.ToString());
            lstItem.SubItems.Add(string.Format("{0:#,###.00}", info.LateCharge));
            return lstItem;
        }
        private void trvDiskTitles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this._diskID = int.Parse(e.Node.Tag.ToString());
            lstvDetailCharge.Items.Clear();
            if(this._diskID!=-1)
            {
                List<BillDetailInfoLateCharge> listBillInfo = _presenter.ListBillDetailInfoCharge().ToList();
                if (listBillInfo.Count > 0)
                {
                    foreach (var item in listBillInfo)
                    {
                        ListViewItem lstItem = AddItem(item);
                        lstvDetailCharge.Items.Add(lstItem);
                    }
                }
            }
            else
            {
                List<BillDetailInfoLateCharge> listBillInfo = _presenter.ListInfoWithListDiskId().ToList();
                if (listBillInfo.Count > 0)
                {
                    foreach (var item in listBillInfo)
                    {
                        ListViewItem lstItem = AddItem(item);
                        lstvDetailCharge.Items.Add(lstItem);
                    }
                }
            }
            
           
        }
    }
}
