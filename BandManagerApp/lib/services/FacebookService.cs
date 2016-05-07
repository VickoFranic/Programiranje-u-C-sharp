using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Facebook;
using Newtonsoft.Json;
using BandManagerApp.lib.models;

namespace BandManagerApp.lib.services
{
    class FacebookService
    {
        private FacebookClient Facebook;

        public FacebookService()
        {
            FacebookClient client = new FacebookClient();
            client.AppId = "1528884584098427";
            client.AppSecret = "be72e6242362fbe0735232e547060c3f";

            Facebook = client;
        }

        public string getLargeProfilePictureForUser(User user)
        {
            string URL = user.picture;

            Facebook.AccessToken = user.access_token;
            JsonObject response = (JsonObject)Facebook.Get("/me?fields=picture.width(300).height(300)");

            JsonTextReader reader = new JsonTextReader(new StringReader(response.ToString()));

            while (reader.Read())
            {
                if (reader.Path.ToString() == "picture.data.url" && reader.TokenType.ToString() == "String")
                {
                    URL = reader.Value.ToString();
                }
            }

            return URL;
        }
    }
}
