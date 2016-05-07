using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.lib.models;
using WindowsFormsApplication1.lib.services;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //            FacebookService Facebook = new FacebookService();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userFacebookID = facebookIDTextBox.Text.ToString();
            // var password = passwordTextBox.Text; // TO DO on backend

            // Get all users from API
            List<User> users = BandManagerService.getAllUsers();

            // Check user credentials - add password (TO DO)
            User loggedInUser = users.Find(item => item.facebook_id == userFacebookID);

            if (loggedInUser != null)
            {
                BandManagerService.CURRENT_USER = loggedInUser;

                this.Visible = false;
                UserProfile userProfileForm = new UserProfile();
                userProfileForm.ShowDialog();
                this.Close();

            }
        }

    }
}
