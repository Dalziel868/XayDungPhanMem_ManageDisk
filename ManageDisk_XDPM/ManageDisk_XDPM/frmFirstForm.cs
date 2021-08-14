using ManageDisk_XDPM.Views.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageDisk_XDPM
{
    public partial class frmFirstForm : Form
    {
        public frmFirstForm()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "0";
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        private void chkHide_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHide.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void rdoOpenmenuemployee_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoOpenmenuemployee.Checked)
            {
               
                frmMenu frm = new frmMenu();
                frm.Show();
                this.Hide();
            }
           
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
           
            if(txtPassword.Text.Equals("17029171"))
            {
                frmRemoveLateCharge frm = new frmRemoveLateCharge();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password is incorrect", "Wrong Pass");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
