using System;
using System.IO;
using Facebook;
using WindowsFormsApplication1.lib.models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WindowsFormsApplication1.lib.services
{
    class FacebookService
    {
        private FacebookClient Facebook;

        public FacebookService()
        {
            FacebookClient client = new FacebookClient();
            client.AppId = "xxxxxxxxxxxxx";
            client.AppSecret = "xxxxxxxxxxxxxxxxxxxxxxx";

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
