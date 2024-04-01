using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberNew.UI
{
    public partial class RiderSignUp : Form
    {
        

        public RiderSignUp()
        {
            InitializeComponent();
        }

        private void userNmtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void RiderSignUp_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 main=new Form1();
            main.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RiderSignIn s = new RiderSignIn();
            s.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signInBtn1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RiderSignIn si = new RiderSignIn();
            si.Show();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            Rider rd = new Rider(userNmtxt.Text, emailtxt.Text, passtxt.Text, addresstxt.Text, phonetxt.Text);
            bool c = RiderCrud.StoreUserIntoDb(rd, Utility.ConnectionString());
            if(c==true)
            {
                MessageBox.Show("user sign up successfully");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void userNmtxt_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        private void emailtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void DriveBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverRegistration dr = new DriverRegistration();
            dr.Show();
        }
    }
}
