using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FunnyImagesViewer
{
    class _9gagParser : SiteParser
    {
        private string lastImageId;
        private const string baseAddress = "http://m.9gag.com";
        private Action<String> outputBoxSetter;

        public _9gagParser(Action<String> outputBoxSetter)
        {
            this.outputBoxSetter = outputBoxSetter;
        }

        public override List<SiteImage> getImages() {
            String address;
            List<SiteImage> localImages = new List<SiteImage>();

            if (lastImageId == null)
            {
                address = baseAddress;
            }
            else
            {
                address = baseAddress + "?id=" + lastImageId + "&c=10'";
            }

            List<HtmlNode> results = getImagesLinks(address);

            outputBoxSetter("9gag:");

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
                SiteImage image = new SiteImage(imageString, imageTitle, "9gag");
                localImages.Add(image);
            }
            String last = localImages.Last().Address;
            lastImageId = last.Split('/').Last().Split('_').First();

            return localImages;
        }

        private List<HtmlNode> getImagesLinks(String address)
        {
            WebClient w = new WebClient();
            String outputString = w.DownloadString(address);


            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(outputString);
            doc.Load(w.OpenRead(address), Encoding.UTF8);

            List<HtmlNode> results = doc.DocumentNode.Descendants().
                Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("badge-archive-box post-container"))).ToList();

            return results;
        }
    }
}
