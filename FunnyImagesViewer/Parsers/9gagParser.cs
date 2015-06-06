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

        public _9gagParser(Action<String> outputBoxSetter) : base(outputBoxSetter) { }

        protected override void fetchMoreImages() {
            outputBoxSetter("9gag:");

            processNodes(getImagesNodes(getNextPageAdress()));
        }

        private void processNodes(List<HtmlNode> nodes)
        {
            foreach (HtmlNode link in nodes)
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
                if (!imageString.Contains("nsfw"))
                {
                    outputBoxSetter(imageString);
                    SiteImage image = new SiteImage(imageString, imageTitle, "9gag");
                    images.Add(image);
                }
            }

            String last = images.Last().Address;
            lastImageId = last.Split('/').Last().Split('_').First();
        }

        private string getNextPageAdress()
        {
            String address;

            if (lastImageId == null)
            {
                address = baseAddress;
            }
            else
            {
                address = baseAddress + "?id=" + lastImageId + "&c=10'";
            }

            return address;
        }

        private List<HtmlNode> getImagesNodes(String address)
        {
            WebClient w = new WebClient();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(w.OpenRead(address), Encoding.UTF8);

            List<HtmlNode> results = doc.DocumentNode.Descendants().
                Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("badge-archive-box post-container"))).ToList();

            return results;
        }
    }
}
