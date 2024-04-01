using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberNew.DL;

namespace UberNew.UI
{
    public partial class DriverRegistration : Form
    {
        public DriverRegistration()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverSignIn ds = new DriverSignIn();
            ds.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Driver dr = new Driver(userNmtxt.Text, phntxt.Text, carModeltxt.Text, licensetxt.Text, idtxt.Text);
               bool Storedr=DriverCrud.StoreDriverInDb(dr);
                if (Storedr ==true)
                {
                    //this.Hide();
                    MessageBox.Show("Registration Successfull");
                    
                }
                              
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
    }
}
