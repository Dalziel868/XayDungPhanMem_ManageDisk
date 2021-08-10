using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManageDisk_XDPM.Customers;
using ManageDisk_XDPM.Disks;
using ManageDisk_XDPM.Views.Charge;
using ManageDisk_XDPM.Views.Disks;
using ManageDisk_XDPM.Views.Manager;

namespace ManageDisk_XDPM
{
    public partial class frmMenu : Form
    {
        //Fileds
        private Button currentButotn;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        //Constructors
        public frmMenu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempIndex==index)
            {
               index= random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivatedButton(object btnSender)
        {
            if(btnSender!=null)
            {
                if(currentButotn!=(Button) btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButotn = (Button)btnSender;
                    currentButotn.BackColor = color;
                    currentButotn.ForeColor = Color.White;
                    currentButotn.Font= new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitle.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color,-0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor= ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control preBtn in panelMenu.Controls)
            {
                if(preBtn.GetType()==typeof(Button))
                {
                    preBtn.BackColor = Color.FromArgb(51,51,76);
                    preBtn.ForeColor = Color.Gainsboro;
                    preBtn.Font= new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm,object btnSender)
        {
            if(activeForm!=null)
            {
                activeForm.Close();
            }
            ActivatedButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(childForm);
            this.panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnRentDisk_Click(object sender, EventArgs e)
        {


            OpenChildForm(new frmRentDisk(), sender);
        }

        private void btnReturnDisk_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReturnDisk(), sender);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddCustomer(), sender);
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            ActivatedButton(sender);
        }

        private void btnDiskStatusReport_Click(object sender, EventArgs e)
        {
            ActivatedButton(sender);
        }

        private void btnTitleInfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmRemoveLateCharge(), sender);
        }

        private void btnCheckCharge_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSearchLateCharge(), sender);
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReserveDisk(), sender);
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCancelReservation(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if(activeForm!=null)
            {
                activeForm.Close();
            }
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Dịch vụ cho thuê băng đĩa IUH";
            panelTitle.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButotn = null;
            btnCloseChildForm.Visible = false;
        }

        

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
