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
        private static string _baseUrl = "http://bandmanager.dev/api/";
        private static WebClient webClient = new WebClient();
        private static List<User> users;
        public static User CURRENT_USER;

        /**
         * Get app application users
         * API endpoint: '/users
         */
        public static List<User> getAllUsers()
        {
            var response = webClient.DownloadString(_baseUrl + "users");
            users = JsonConvert.DeserializeObject<List<User>>(response);
            return users;
        }
    }
}
