﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace Chapter_2___Program_4
{
    class _9gagParser : SiteParser
    {
        private List<SiteImage> images = new List<SiteImage>();
        private const string baseAddress = "http://m.9gag.com";
        private Action<String> outputBoxSetter;

        public _9gagParser(Action<String> outputBoxSetter)
        {
            this.outputBoxSetter = outputBoxSetter;
        }

        public override List<SiteImage> getImages() {
            String address;
            List<SiteImage> localImages = new List<SiteImage>();

            if (images.Count == 0)
            {
                address = baseAddress;
            }
            else
            {
                String last = images.Last().Title;
                String id = last.Split('/').Last().Split('_').First();
                address = baseAddress + "?id=" + id + "&c=10'";
            }

            List<HtmlNode> results = getImagesLinks(address);

            foreach (HtmlNode link in results)
            {
                HtmlNode img = link.Descendants("img").ToList()[0];
                HtmlNode a = link.Descendants("a").ToList()[0];
                String imageString = img.GetAttributeValue("src", null);
                String imageTitle = img.GetAttributeValue("alt", null);
                String classString = a.GetAttributeValue("class", "no class");
                if (classString.Equals("badge-animated-cover"))
                {
                    imageString = a.Descendants("div").ToList()[0].GetAttributeValue("data-image", null);
                }
                if (!imageString.Substring(0, 4).Equals("http")) { imageString = "http:" + imageString; }
                outputBoxSetter(imageString);
                SiteImage image = new SiteImage(imageString, imageTitle);
                localImages.Add(image);
            }
            images = localImages;

            return localImages;
        }

        private List<HtmlNode> getImagesLinks(String address)
        {
            WebClient w = new WebClient();
            String outputString = w.DownloadString(address);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(outputString);

            List<HtmlNode> results = doc.DocumentNode.Descendants().
                Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("badge-archive-box post-container"))).ToList();

            return results;
        }
    }
}
