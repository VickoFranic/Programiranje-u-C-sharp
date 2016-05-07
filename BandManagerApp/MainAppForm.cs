using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BandManagerApp.lib.models;
using BandManagerApp.lib.services;

namespace BandManagerApp
{
    public partial class MainAppForm : Form
    {
        public MainAppForm()
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
                UserProfileForm userProfileForm = new UserProfileForm();
                userProfileForm.ShowDialog();
                this.Close();

            }
        }
    }
}