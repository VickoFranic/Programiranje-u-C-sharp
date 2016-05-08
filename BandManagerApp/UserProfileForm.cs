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
    // Get all users from API
    //List<User> users = BandManagerService.getAllUsers();
    //User loggedInUser = users.Find(item => item.facebook_id == userFacebookID);

    public partial class UserProfileForm : Form
    {
        private User USER;
        private FacebookService Facebook = new FacebookService();

        public UserProfileForm(User user)
        {
            InitializeComponent();

            USER = user;
            pictureBox1.Load(USER.picture);
            label4.Text = USER.facebook_id;
            label3.Text = USER.name;

            createUserPagesPanel();
        }

        public void createUserPagesPanel()
        {
            List<Page> pages = BandManagerService.getUserPages(USER);

           if (pages.Count != 0)
           {
               ListViewItem lvi = new ListViewItem(pages[0].name);
               foreach (Page page in pages)
               {
                   listView1.Items.Add(new ListViewItem(page.name));
               }
           }
        }
    }
}
