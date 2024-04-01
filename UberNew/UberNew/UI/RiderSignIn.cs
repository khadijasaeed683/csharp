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
    public partial class RiderSignIn : Form
    {
        public RiderSignIn()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f=new Form1();
            f.Show();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            Rider rd=new Rider();
            rd.setName(userNmtxt.Text);
            rd.setEmail(emailtxt.Text);
            rd.setPassword(passtxt.Text);
            Rider CheckRider = RiderCrud.SignIn(rd, Utility.ConnectionString());
            if (CheckRider!=null)
            {
                this.Hide();
                RiderHomePage rh=new RiderHomePage();
                rh.Show();
            }
            else
            {
                MessageBox.Show("User Not Found");
            }
        }

        private void userNmtxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
