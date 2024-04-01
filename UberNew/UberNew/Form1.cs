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
using UberNew.UI;

namespace UberNew
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RiderSignUp rs=new RiderSignUp();
            rs.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DriveBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverSignIn dm=new DriverSignIn();
            dm.Show();
        }

        private void signInBtn1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RiderSignIn rsi=new RiderSignIn();
            rsi.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainPage dm=new AdminMainPage();
            dm.Show();
        }
    }
}
