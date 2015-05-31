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
        }

        private void addToOutputBox(string text) {
            outputBox.Text += text + '\n';
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            index++;
            if (index > 0) prevButton.Enabled = true;
            if (index == imagesArray.Count()) ;
            try { pictureBox.Load(); }
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
                parserObjects.Add(new _9gagParser(addToOutputBox));
            }
            else
            {
                foreach (SiteParser parser in parserObjects)
                {
                    if (parser is _9gagParser) parserObjects.Remove(parser);
                }
            }
            
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            imagesManager = new ImagesManager(parserObjects);
            this.images = imagesManager.getImages();
        }

        private void outputBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
