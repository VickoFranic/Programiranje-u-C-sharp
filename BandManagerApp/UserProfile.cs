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
    public partial class UserProfile : Form
    {
        private User loggedInUser;
        private FacebookService Facebook = new FacebookService();

        public UserProfile()
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
