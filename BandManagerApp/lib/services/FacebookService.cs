using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Facebook;
using Newtonsoft.Json;
using CefSharp;
using BandManagerApp.lib.models;

namespace BandManagerApp.lib.services
{
    class FacebookService
    {
        private FacebookClient Facebook;
        private static WebClient webClient = new WebClient();

        public FacebookService()
        {
            FacebookClient client = new FacebookClient();
            client.AppId = "1528884584098427";
            client.AppSecret = "be72e6242362fbe0735232e547060c3f";

            Facebook = client;
        }

        /**
         * Get user from Facebook, with given access token
         * 
         * @param string token
         * @return User user
         */
        public User getFacebookUser(string token)
        {
            Facebook.AccessToken = token;
            JsonObject response = (JsonObject)Facebook.Get("/me?fields=id,name,picture.width(300).height(300)");

            User user = new User();

            user.facebook_id = response["id"].ToString();
            user.name = response["name"].ToString();
            user.access_token = token;

            if (response.ContainsKey("picture"))
            {
                var pictureObj = response["picture"] as JsonObject;
                var data = pictureObj["data"] as JsonObject;
                user.picture = data["url"].ToString();
            }

            return user;
        }

        public string getLargeProfilePictureForUser(User user)
        {
            string URL = user.picture;

            Facebook.AccessToken = user.access_token;
            JsonObject response = (JsonObject)Facebook.Get("/me?fields=picture.width(800).height(800)");

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

        public Uri generateLoginUrl()
        {
            var loginParams = new Dictionary<string, object>();
            loginParams["client_id"] = Facebook.AppId;
            loginParams["client_secret"] = Facebook.AppSecret;
            loginParams["response_type"] = "code token";
            loginParams["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";

            var loginUrl = Facebook.GetLoginUrl(loginParams);

            return loginUrl;
        }

        public string getAccessTokenFromCallback(Uri callback)
        {
            FacebookOAuthResult res;
            bool tryParse = Facebook.TryParseOAuthCallbackUrl(callback, out res);

            if (tryParse)
            {
                return res.AccessToken;
            }

            return String.Empty;
        }

    }
}
