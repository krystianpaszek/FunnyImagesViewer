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
        private string nextPageAddress;

        public KwejkParser(Action<String> outputBoxSetter) : base(outputBoxSetter) { }

        protected override void fetchMoreImages()
        {
            outputBoxSetter("9gag:");
            processNodes(getImagesNodes(getNextPageAdress()));
        }

        private string getNextPageAdress()
        {
            String address;

            if (nextPageAddress == null)
            {
                address = baseAddress;
            }
            else
            {
                address = nextPageAddress;
            }

            return address;
        }

        private List<HtmlNode> getImagesNodes(string address)
        {
            WebClient w = new WebClient();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(w.OpenRead(address), Encoding.UTF8);

            List<HtmlNode> results = doc.DocumentNode.Descendants().
                Where(x => (x.Name == "a" && x.Attributes["data-track-action"] != null && x.Attributes["data-track-action"].Value.IndexOf("Tre") != -1)).ToList();

            HtmlNode nextPageNode = doc.DocumentNode.Descendants().
                FirstOrDefault(x => (x.Name == "a" && x.Attributes["data-track-action"] != null && x.Attributes["data-track-action"].Value.IndexOf("Nast") != -1));

            nextPageAddress = nextPageNode.GetAttributeValue("href", null);

            return results;
        }

        private void processNodes(List<HtmlNode> nodes) {
            foreach (HtmlNode n in nodes)
            {
                string link = n.Descendants("img").ToList().First().GetAttributeValue("src", null).ToString();
                string title = n.Descendants("img").ToList().First().GetAttributeValue("alt", null).ToString();
                HtmlNode parentNode = n.Ancestors().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("media"))).ToList().First();
                HtmlNode voteNode = parentNode.Descendants().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("vote"))).ToList().First();
                HtmlNode bubbleNode = voteNode.Descendants().Where(x => (x.Name == "span" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("bubble"))).ToList().First();

                int rating = Convert.ToInt32(bubbleNode.InnerHtml);

                if (rating > 0)
                {
                    outputBoxSetter(link);
                    SiteImage image = new SiteImage(link, title, "kwejk.pl");
                    images.Add(image);
                }
            }
        }
    }
}
