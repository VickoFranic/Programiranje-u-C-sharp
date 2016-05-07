using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using WindowsFormsApplication1.lib.models;

namespace WindowsFormsApplication1.lib.services
{
    static class BandManagerService
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
