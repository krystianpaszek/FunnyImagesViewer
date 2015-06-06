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
        private int page = 0;

        public DemotywatoryParser(Action<String> outputBoxSetter) : base(outputBoxSetter) { }

        protected override void fetchMoreImages()
        {
            outputBoxSetter("demotywatory.pl:");
            processNodes(getImagesNodes(getNextPageAddress()));
        }

        private string getNextPageAddress()
        {
            String address;
            page++;

            if (page == 1)
            {
                address = baseAddress;
            }
            else
            {
                address = baseAddress + "/page/" + page;
            }

            return address;
        }

        private List<HtmlNode> getImagesNodes(String address)
        {
            WebClient w = new WebClient();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(w.OpenRead(address), Encoding.UTF8);

            List<HtmlNode> results = doc.DocumentNode.Descendants().
                Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("image") && !x.Attributes["class"].Value.Contains("image_gallery"))).ToList();

            return results;
        }

        private void processNodes(List<HtmlNode> nodes)
        {
            foreach (HtmlNode link in nodes)
            {
                string imageString = link.Descendants("img").ToList().First().GetAttributeValue("src", null).ToString();
                string imageTitle = link.Descendants("img").ToList().First().GetAttributeValue("alt", null).ToString();

                outputBoxSetter(imageString);
                SiteImage image = new SiteImage(imageString, imageTitle, "demotywatory.pl");
                images.Add(image);
            }
        }
    }
}
