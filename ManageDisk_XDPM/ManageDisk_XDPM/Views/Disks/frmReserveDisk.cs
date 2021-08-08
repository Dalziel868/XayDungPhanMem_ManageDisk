namespace ManageDisk_XDPM.Views.Disks
{
    using DTO.Titles;
    using IViews_Presenters.frmReserveDisk;
    using Presenters.frmReserveDisk;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Tulpep.NotificationWindow;

    /// <summary>
    /// Defines the <see cref="frmReserveDisk" />.
    /// </summary>
    public partial class frmReserveDisk : Form, IReserveDisk
    {
        private ReserveDiskPresenter _presenter;
     
        /// <summary>
        /// Initializes a new instance of the <see cref="frmReserveDisk"/> class.
        /// </summary>
        public frmReserveDisk()
        {
            InitializeComponent();
            _presenter = new ReserveDiskPresenter(this);
            if (!ThemeColor.PrimaryColor.Name.Equals("0"))
            {
                LoadTheme();
            }

        }

        public string TitleName {
            get
            {
                return txtTitleName.Text;
            }
            set
            {
                txtTitleName.Text = value;
            }
        }

        public int CustomerID {
            get
            {
                return int.Parse(txtCustomerId.Text);
            }
            set
            {
                txtCustomerId.Text = value.ToString();
            }
        }

        public List<int> ListTitleID {
            get
            {
                List<int> listTitleId = new List<int>();
                foreach (ListViewItem item in lstvtitleReserved.Items)
                {
                        listTitleId.Add(int.Parse(item.Text));
                }
                return listTitleId;
            }
        }

        /// <summary>
        /// The LoadTheme.
        /// </summary>
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

            label1.ForeColor = ThemeColor.PrimaryColor;
            label2.ForeColor = ThemeColor.SecondaryColor;
        }
        private void ShowPopupNotifi(string title, string content,Image image)
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
        private ListViewItem addItem(TitleToReserveDto dto)
        {
            ListViewItem item = new ListViewItem(dto.Id.ToString());
            item.SubItems.Add(dto.Name);
            return item;
        }
        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            List<TitleToReserveDto> listTitleDto = _presenter.SearchForTitles().ToList();
            lstvListTitle.Items.Clear();
            if (listTitleDto.Count()==0)
            {
                ShowPopupNotifi("KHÔNG TÌM THẤY TIÊU ĐỀ", "Có vẻ tiêu đề không tồn tại, thử nhập lại từ khóa nào đúng hơn",Properties.Resources.icon404);
            }
            else
            {
                
                foreach (var item in listTitleDto)
                {
                    ListViewItem lstItem = addItem(item);
                    lstvListTitle.Items.Add(lstItem);
                }
            }

        }

        private void btnReserveDisk_Click(object sender, System.EventArgs e)
        {

        }

        
        //
       
        private void lstvListTitle_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue==CheckState.Checked)
            {
                int id =int.Parse(lstvListTitle.Items[e.Index].Text);
                if(lstvtitleReserved.Items.Count>0)
                {
                    foreach (ListViewItem item in lstvtitleReserved.Items)
                    {
                        if (int.Parse(item.Text) == id)
                        {
                            ShowPopupNotifi("KHÔNG THÀNH CÔNG", "Tiêu đề này đã được đặt trong danh sách rồi", Properties.Resources.icon404);
                            return;
                        }
                    }
                }
            
                lstvtitleReserved.Items.Add(id.ToString());
                
                
            }
        }

        private void frmReserveDisk_Load(object sender, System.EventArgs e)
        {
           
           
        }

        private void lstvtitleReserved_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lstvtitleReserved.Items.RemoveAt(lstvtitleReserved.SelectedIndices[0]);
        }
    }
}
