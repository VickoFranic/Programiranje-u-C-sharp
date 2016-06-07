using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HTTP
{
    class Program
    {
        /**
         * Example GET request with HttpWebRequest
         */
        public static void httpWebRequestExample()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.gigspy.vfdesign.org/generate_link");
            var response = httpWebRequest.GetResponse();

            /**
             * System.IO StreamReader
             */
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);

            Console.WriteLine(sr.ReadToEnd() + Environment.NewLine);
        }

        /**
         * Example GET request with WebClient
         */
        public static void webClientExample()
        {
            var webClient = new WebClient();
            var response = webClient.DownloadString("http://api.gigspy.vfdesign.org/generate_link");

            Console.WriteLine(response + Environment.NewLine);
        }

        static void Main(string[] args)
        {
            httpWebRequestExample();
            webClientExample();
        }
    }
}
