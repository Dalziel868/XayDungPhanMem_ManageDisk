
using IViews_Presenters.frmInsertDisk;
using Presenters.frmInsertDisk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageDisk_XDPM.Views.Manager
{
    public partial class frrtInsertDisk : Form, IInsertDisk
    {
        private readonly InsertDiskPresenter _presenter;
        public frrtInsertDisk()
        {
            InitializeComponent();
            _presenter = new InsertDiskPresenter(this);
        }

        public int ID => throw new NotImplementedException();

        public string Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CategoryID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TitleID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void frrtInsertDisk_Load(object sender, EventArgs e)
        {
            cboLoai.Items.Add("Game");
            cboLoai.Items.Add("Movie");
            ReloadListview();
            lvwDisk.CheckBoxes = false;
            cboTitle.Enabled = false;
            lvwDisk.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.None);
            lvwDisk.Columns[0].Width = 0;
        }


        private void btnThemDia_Click(object sender, EventArgs e)
        {
            if(cboLoai.SelectedItem.ToString() != "" && cboTitle.SelectedItem.ToString() != "")
            {
                int id = 0;
                try
                {
                    id = _presenter.InsertNewDisk(cboLoai.SelectedItem.ToString(), cboTitle.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                MessageBox.Show("Thêm mới thành công đĩa mới có mã là: " + id.ToString() + " cho tiêu đề "  +"''"+ cboTitle.SelectedItem.ToString() + "''", "THÀNH CÔNG");
                ReloadListview();
            }    
            else
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Thiếu thông tin");
        }

        private void ReloadListview()
        {
            lvwDisk.Items.Clear();
            foreach (var item in _presenter.getAllDisk().ToList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(item.DiskID.ToString());
                lvi.SubItems.Add(item.TieuDe);
                lvi.SubItems.Add(item.TheLoai);
                lvi.SubItems.Add(item.TrangThai);

                lvwDisk.Items.Add(lvi);
            }
            //if(lvwDisk.Columns.Count == 5)
            //    lvwDisk.Columns[0].Dispose();


        }

        private void cboTitle_Validated(object sender, EventArgs e)
        {

        }

        private void cboLoai_SelectedValueChanged(object sender, EventArgs e)
        {
            cboTitle.Enabled = true;
            cboTitle.DataSource = _presenter.getTitleByCategory(cboLoai.SelectedItem.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (_presenter.RemoveDisk(txtMaDia.Text) == 1)
                {
                    MessageBox.Show("Xóa thành công đĩa có mã: " + txtMaDia.Text, "THÀNH CÔNG");
                    ReloadListview();
                }
                else
                    MessageBox.Show("Mã đĩa không hợp lệ, vui lòng kiểm tra lại mã đĩa", "ERROR");
            }
            catch (Exception)
            {

                MessageBox.Show("Mã đĩa không hợp lệ, vui lòng kiểm tra lại mã đĩa", "ERROR");
            }
            
        }
    }
}
