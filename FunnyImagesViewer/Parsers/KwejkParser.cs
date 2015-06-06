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

        public KwejkParser(Action<String> outputBoxSetter) : base(outputBoxSetter) { }

        protected override void fetchMoreImages()
        {
            List<HtmlNode> links = getImagesNodes();
        }

        private List<HtmlNode> getImagesNodes()
        {
            WebClient w = new WebClient();
            //String outputString = w.DownloadString(baseAddress);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(w.OpenRead(baseAddress), Encoding.UTF8);

            List<HtmlNode> results = doc.DocumentNode.Descendants().
                Where(x => (x.Name == "a" && x.Attributes["data-track-action"] != null && x.Attributes["data-track-action"].Value.IndexOf("Tre") != -1)).ToList();

            foreach (HtmlNode n in results)
            {
                System.Console.WriteLine(n.Descendants("img").ToList().First().GetAttributeValue("src", null).ToString());
                System.Console.WriteLine(n.Descendants("img").ToList().First().GetAttributeValue("alt", null).ToString());
                HtmlNode parentNode = n.Ancestors().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("media"))).ToList().First();
                HtmlNode voteNode = parentNode.Descendants().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("vote"))).ToList().First();
                HtmlNode bubbleNode = voteNode.Descendants().Where(x => (x.Name == "span" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("bubble"))).ToList().First();
                System.Console.WriteLine(bubbleNode.InnerHtml);

            }

            return results;
        }
    }
}
