﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FunnyImagesViewer.Parsers
{
    class ImgurParser : SiteParser
    {
        private static string client_id = "4619cb2dd0598ff";
        private static string baseUrl = "https://api.imgur.com/3/";

        public ImgurParser(Action<String> outputBoxSetter) : base(outputBoxSetter) { }

        protected override void fetchMoreImages()
        {
            WebRequest req = WebRequest.Create(baseUrl + "gallery/t/funny/viral/" + currentPage/60);
            req.Method = "GET";
            req.Headers["Authorization"] = "Client-ID " + client_id;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

            Stream stream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            String responseString = reader.ReadToEnd();

            JObject joResponse = JObject.Parse(responseString);
            JArray array = (JArray)joResponse["data"]["items"];

            outputBoxSetter("Imgur:");

            foreach (JToken jToken in array)
            {
                SiteImage siteImage = JsonConvert.DeserializeObject<SiteImage>(jToken.ToString());
                siteImage.Site = "Imgur";
                images.Add(siteImage);
                outputBoxSetter(siteImage.Address);
            }
        }
    }
}
