using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_2___Program_4
{
    class ImagesManager
    {
        private List<SiteParser> parsers;
        private List<SiteImage> images = new List<SiteImage>();

        public ImagesManager(List<SiteParser> siteParsers) {
            parsers = siteParsers;
        }

        public List<SiteImage> getImages()
        {
            foreach (SiteParser parser in parsers) {
                List<SiteImage> l = parser.getImages();
                images.AddRange(l);
            }

            return images;
        }
    }
}
