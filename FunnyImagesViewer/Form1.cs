using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Chapter_2___Program_4
{
    public partial class Form1 : Form
    {

        private List<String> imagesArray = new List<String>();
        private List<SiteImage> images = new List<SiteImage>();
        private int index = 0;
        private List<SiteParser> parserObjects = new List<SiteParser>();
        private ImagesManager imagesManager;

        public Form1()
        {
            InitializeComponent();

            //String address = addressTextBox.Text;
            //List<HtmlNode> results = getImagesLinks(address);
            //getImages();
            //pictureBox.Load(imagesArray[index]);
        }

        private void outputTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
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

        private void addToOutputBox(string text) {
            outputBox.Text += text;
        }

        private void getImages()
        {
            String address;

            if (imagesArray.Count == 0)
            {
                address = addressTextBox.Text;
            }
            else
            {
                String last = imagesArray.Last();
                String id = last.Split('/').Last().Split('_').First();
                address = addressTextBox.Text + "?id=" + id + "&c=10'";
            }

            List<HtmlNode> results = getImagesLinks(address);

            foreach (HtmlNode link in results)
            {
                String imageString = link.Descendants("img").ToList()[0].GetAttributeValue("src", null);
                if (!imageString.Substring(0, 4).Equals("http")) { imageString = "http:" + imageString; }
                //outputTextBox.Text += imageString + "\n";
                imagesArray.Add(imageString);
            }

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            index++;
            if (index > 0) prevButton.Enabled = true;
            if (index == imagesArray.Count()) getImages();
            try { pictureBox.Load(imagesArray[index]); }
            catch (Exception exception) { pictureBox.Image = pictureBox.ErrorImage; }

        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                pictureBox.Load(imagesArray[index]);
            }

            if (index == 0) prevButton.Enabled = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    nextButton.PerformClick();
                    break;
                case Keys.Left:
                    prevButton.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            //WebClient w = new WebClient();
            //String outputString = w.DownloadString(address);

            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(outputString);

            RunAsync();
        }

        async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                // TODO - Send HTTP requests

                client.BaseAddress = new Uri("http://api.openweathermap.org/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("data/2.5/weather?q=London,uk");
                if (response.IsSuccessStatusCode)
                {
                    outputBox.Text = await response.Content.ReadAsStringAsync();
                }
            }
        }

        private void gagCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gagCheckBox.Checked) {
                //System.Console.WriteLine("9gag selected");
                parserObjects.Add(new _9gagParser(addToOutputBox));
            }
            else
            {
                foreach (SiteParser parser in parserObjects)
                {
                    if (parser is _9gagParser) parserObjects.Remove(parser);
                }
                //System.Console.WriteLine("9gag removed");
            }
            
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            imagesManager = new ImagesManager(parserObjects);
            this.images = imagesManager.getImages();
        }
    }
}
