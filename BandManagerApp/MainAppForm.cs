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
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using CefSharp;

namespace BandManagerApp
{
    public partial class MainAppForm : Form
    {
        FacebookService Facebook;
        ChromiumWebBrowser Browser;
        UserProfileForm userProfileForm;

        public MainAppForm()
        {
            InitializeComponent();

            Facebook = new FacebookService();

        }

        /**
         * Show user profile form
         */
        private void showUserProfile(string accessToken)
        {
            User user = Facebook.getFacebookUser(accessToken);

            userProfileForm = new UserProfileForm(user);
            this.Visible = false;
            userProfileForm.ShowDialog();

            if (userProfileForm.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                Browser.Dispose();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uri loginUrl = Facebook.generateLoginUrl();
            Browser = new ChromiumWebBrowser(loginUrl.AbsoluteUri);

            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(Browser);

            Browser.AddressChanged += OnBrowserAddressChanged;
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            Uri callback = new Uri(args.Address);
            string accessToken = Facebook.getAccessTokenFromCallback(callback);

            if (accessToken != String.Empty)
                showUserProfile(accessToken);
        }
    }
}