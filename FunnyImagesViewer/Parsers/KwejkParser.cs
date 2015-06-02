using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FunnyImagesViewer.Parsers
{
    class KwejkParser : SiteParser
    {
        private const string baseAddress = "http://m.kwejk.pl";
        private Action<String> outputBoxSetter;

        public KwejkParser(Action<String> outputBoxSetter)
        {
            this.outputBoxSetter = outputBoxSetter;
        }

        public override List<SiteImage> getImages()
        {
            getImagesLinks(baseAddress);
            return null;

            //String address;
            //List<SiteImage> localImages = new List<SiteImage>();

            //if (lastImageId == null)
            //{
            //    address = baseAddress;
            //}
            //else
            //{
            //    address = baseAddress + "?id=" + lastImageId + "&c=10'";
            //}

            //List<HtmlNode> results = getImagesLinks(address);

            //outputBoxSetter("9gag:");

            //foreach (HtmlNode link in results)
            //{
            //    HtmlNode img = link.Descendants("img").ToList()[0];
            //    HtmlNode a = link.Descendants("a").ToList()[0];
            //    String imageString = img.GetAttributeValue("src", null);
            //    String imageTitle = img.GetAttributeValue("alt", null);
            //    String classString = a.GetAttributeValue("class", "no class");
            //    if (classString.Equals("badge-animated-cover"))
            //    {
            //        imageString = a.Descendants("div").ToList()[0].GetAttributeValue("data-image", null);
            //    }
            //    if (!imageString.Substring(0, 4).Equals("http")) { imageString = "http:" + imageString; }
            //    outputBoxSetter(imageString);
            //    SiteImage image = new SiteImage(imageString, imageTitle, "9gag");
            //    localImages.Add(image);
            //}
            //String last = localImages.Last().Address;
            //lastImageId = last.Split('/').Last().Split('_').First();

            //return localImages;
        }

        private List<HtmlNode> getImagesLinks(String address)
        {
            WebClient w = new WebClient();
            String outputString = w.DownloadString(address);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(w.OpenRead(address), Encoding.UTF8);

            List<HtmlNode> results = doc.DocumentNode.Descendants().
                Where(x => (x.Name == "a" && x.Attributes["data-track-action"] != null && x.Attributes["data-track-action"].Value.IndexOf("Tre") != -1)).ToList();

            foreach (HtmlNode n in results)
            {
                System.Console.WriteLine(n.Descendants("img").ToList().First().GetAttributeValue("src", null).ToString());
                System.Console.WriteLine(n.Descendants("img").ToList().First().GetAttributeValue("alt", null).ToString());
                HtmlNode parentNode = n.Ancestors().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("media"))).ToList().First();
                HtmlNode voteNode = parentNode.Descendants().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("vote"))).ToList().First();//parentNode.Descendants() Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("vote"))).ToList().First;
                HtmlNode bubbleNode = voteNode.Descendants().Where(x => (x.Name == "span" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("bubble"))).ToList().First();
                System.Console.WriteLine(bubbleNode.InnerHtml);

            }

            return results;
        }
    }
}
