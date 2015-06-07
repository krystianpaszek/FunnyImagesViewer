using FunnyImagesViewer.Parsers;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyImagesViewer
{
    public partial class Form1 : Form
    {
        private List<SiteParser> parserObjects = new List<SiteParser>();
        private ImagesManager imagesManager;
        private SiteParser testingParser;

        public Form1()
        {
            InitializeComponent();
        }

        private void addToOutputBox(string text)
        {
            outputBox.Text += text + '\n';
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadSiteImage(imagesManager.NextImage());
                prevButton.Enabled = true;
            }
            catch (Exception exception) { pictureBox.Image = pictureBox.ErrorImage; }

        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadSiteImage(imagesManager.PrevImage());
                if (imagesManager.CurrentIndex() == 0) prevButton.Enabled = false;
                nextButton.Enabled = true;
            }
            catch (Exception exception) { pictureBox.Image = pictureBox.ErrorImage; }
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
            if (testingParser == null) testingParser = new ImgurParser(addToOutputBox);
            testingParser.getImages();
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

        private void goButton_Click(object sender, EventArgs e)
        {
            parserObjects = new List<SiteParser>();

            if (kwejkCheckBox.Checked)
            {
                parserObjects.Add(new KwejkParser(addToOutputBox));
            }

            if (demotywatoryCheckBox.Checked)
            {
                parserObjects.Add(new DemotywatoryParser(addToOutputBox));
            }

            if (gagCheckBox.Checked)
            {
                parserObjects.Add(new _9gagParser(addToOutputBox));
            }

            if (imgurCheckBox.Checked)
            {
                parserObjects.Add(new ImgurParser(addToOutputBox));
            }

            imagesManager = new ImagesManager(parserObjects);
            imagesManager.loadImages();
            loadSiteImage(imagesManager.FirstImage());
        }

        private void loadSiteImage(SiteImage siteImage)
        {
            try
            {
                pictureBox.Load(siteImage.Address);
            }
            catch (Exception exception)
            {
                pictureBox.Image = pictureBox.ErrorImage;
            }
            titleLabel.Text = WebUtility.HtmlDecode(siteImage.Title);
            int total = imagesManager.Count();
            int current = imagesManager.CurrentIndex();
            countLabel.Text = current+1 + "/" + total;
            siteLabel.Text = siteImage.Site;
        }

        private void outputBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg;";
            ImageFormat format = ImageFormat.Png;
            if (pictureBox.Image.RawFormat.Guid == ImageFormat.Gif.Guid)
            {
                MessageBox.Show("Can't save GIFs.");
                return;
            }
            
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                pictureBox.Image.Save(sfd.FileName, format);
            }
        }

        private void _9gagProcessButton_Click(object sender, EventArgs e)
        {
            if (testingParser == null) testingParser = new _9gagParser(addToOutputBox);
            testingParser.getImages();
        }

        private void kwejkProcessButton_Click(object sender, EventArgs e)
        {
            if (testingParser == null) testingParser = new KwejkParser(addToOutputBox);
            testingParser.getImages();
        }

        private void demotywatoryProcessButton_Click(object sender, EventArgs e)
        {
            if (testingParser == null) testingParser = new DemotywatoryParser(addToOutputBox);
            testingParser.getImages();
        }
    }
}
