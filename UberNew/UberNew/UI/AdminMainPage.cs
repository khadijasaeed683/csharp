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
    public partial class AdminMainPage : Form
    {
        public AdminMainPage()
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
            Form1 form = new Form1();
            form.Show();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            if(userNmtxt.Text=="khadija" && emailtxt.Text=="k@gmail.com")
            {
                this.Hide();
                AdminHomePage ah=new AdminHomePage();
                ah.Show();
            }
        }
    }
}
