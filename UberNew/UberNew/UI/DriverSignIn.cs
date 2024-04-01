using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberNew.DL;

namespace UberNew.UI
{
    public partial class DriverSignIn : Form
    {
        public DriverSignIn()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify the Instagram URL you want to open
                string instagramUrl = "https://www.instagram.com/";

                // Open the Instagram page in the default web browser
                Process.Start(instagramUrl);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur while opening the URL
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void signInBtn1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverRegistration dr=new DriverRegistration();
            dr.Show();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            Driver dr = new Driver(userNmtxt.Text,idtxt.Text);
            Driver CheckDriver = DriverCrud.SignIn(dr, Utility.ConnectionString());
           
             if (CheckDriver != null )
            {
                this.Hide();
                DriverWaitingPage dwp = new DriverWaitingPage();
                dwp.Show();

            }
            else
            {
                MessageBox.Show("User Not Found");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverRegistration dr=new DriverRegistration();
            dr.Show();
        }
    }
}
