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
    public partial class DriverWaitingPage : Form
    {
        public DriverWaitingPage()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void signInBtn1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverSignIn ds=new DriverSignIn();
            ds.Show();
        }
    }
}
