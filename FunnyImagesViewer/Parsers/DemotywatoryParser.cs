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

        public DemotywatoryParser(Action<String> outputBoxSetter) : base(outputBoxSetter) { }

        protected override void fetchMoreImages()
        {
            String address;

            if (currentPage == 1)
            {
                address = baseAddress;
            }
            else
            {
                address = baseAddress + "/page/" + currentPage;
            }
            currentPage++;

            List<HtmlNode> results = getImagesNodes(address);

            outputBoxSetter("demotywatory.pl:");

            foreach (HtmlNode link in results)
            {
                string imageString = link.Descendants("img").ToList().First().GetAttributeValue("src", null).ToString();
                string imageTitle = link.Descendants("img").ToList().First().GetAttributeValue("alt", null).ToString();

                outputBoxSetter(imageString);
                SiteImage image = new SiteImage(imageString, imageTitle, "demotywatory.pl");
                images.Add(image);
            }
        }

        private List<HtmlNode> getImagesNodes(String address)
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
