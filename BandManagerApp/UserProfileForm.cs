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
    public partial class UserProfileForm : Form
    {
        User loggedInUser;
        private FacebookService Facebook = new FacebookService();

        public UserProfileForm()
        {
            InitializeComponent();

            loggedInUser = BandManagerService.CURRENT_USER;

            string largerProfilePictureURL = Facebook.getLargeProfilePictureForUser(loggedInUser);

            pictureBox1.Load(largerProfilePictureURL);
            label4.Text = loggedInUser.facebook_id;
            label3.Text = loggedInUser.name;
        }
    }
}
