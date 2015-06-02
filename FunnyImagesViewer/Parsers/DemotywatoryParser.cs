using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FunnyImagesViewer.Parsers
{
    class DemotywatoryParser : SiteParser
    {
        private const string baseAddress = "http://m.demotywatory.pl";
        private Action<String> outputBoxSetter;
        private int page = 1;
        private int count = 0;
        List<SiteImage> images = new List<SiteImage>();

        public DemotywatoryParser(Action<String> outputBoxSetter)
        {
            this.outputBoxSetter = outputBoxSetter;
        }

        public override List<SiteImage> getImages()
        {
            count++;
            while (images.Count < count*10) {
                images.AddRange(m());
            }

            return images.GetRange(count*10-10, 10);
        }

        private List<SiteImage> m()
        {
            String address;
            List<SiteImage> localImages = new List<SiteImage>();

            if (page == 1)
            {
                address = baseAddress;
            }
            else
            {
                address = baseAddress + "/page/" + page;
            }
            page++;

            List<HtmlNode> results = getImagesLinks(address);

            outputBoxSetter("demotywatory.pl:");

            foreach (HtmlNode link in results)
            {
                string imageString = link.Descendants("img").ToList().First().GetAttributeValue("src", null).ToString();
                string imageTitle = link.Descendants("img").ToList().First().GetAttributeValue("alt", null).ToString();

                outputBoxSetter(imageString);
                SiteImage image = new SiteImage(imageString, imageTitle, "demotywatory.pl");
                localImages.Add(image);
            }

            return localImages;
        }

        private List<HtmlNode> getImagesLinks(String address)
        {
            WebClient w = new WebClient();
            String outputString = w.DownloadString(address);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(w.OpenRead(address), Encoding.UTF8);

            List<HtmlNode> results = doc.DocumentNode.Descendants().
                Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("image") && !x.Attributes["class"].Value.Contains("image_gallery"))).ToList();

            foreach (HtmlNode n in results)
            {
                System.Console.WriteLine(n.Descendants("img").ToList().First().GetAttributeValue("src", null).ToString());
                System.Console.WriteLine(n.Descendants("img").ToList().First().GetAttributeValue("alt", null).ToString());
            }

            return results;
        }
    }
}
