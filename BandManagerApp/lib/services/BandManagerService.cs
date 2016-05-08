using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using BandManagerApp.lib.models;

namespace BandManagerApp.lib.services
{
    class BandManagerService
    {
        private static string _baseUrl = "http://bandmanager.dev/api";
        private static WebClient webClient = new WebClient();
        private static List<User> users;

        /**
         * Get app application users
         * API endpoint:    '/users'
         * Method:          'GET'
         */
        public static List<User> getAllUsers()
        {
            var response = webClient.DownloadString(_baseUrl + "/users");
            users = JsonConvert.DeserializeObject<List<User>>(response);
            return users;
        }

        /**
         * Get all pages for specific user. Returns empty if no pages found.
         * 
         * @param User user
         * @return List<Page>
         * 
         * API endpoint:    '/pages/{facebook_id}'
         * Params:          'facebook_id'
         * Method:          'GET'
         */
        public static List<Page> getUserPages(User user)
        {
            var response = webClient.DownloadString(_baseUrl + "/pages/" + user.facebook_id);
            List<Page> pages = JsonConvert.DeserializeObject<List<Page>>(response);
            return pages;
        }
    }
}
