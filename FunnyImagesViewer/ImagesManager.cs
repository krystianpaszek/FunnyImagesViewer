using System;
using System.Collections.Generic;
using System.Linq;

namespace FunnyImagesViewer
{
    class ImagesManager
    {
        private List<SiteParser> parsers;
        private List<SiteImage> images = new List<SiteImage>();
        private int index = 0;

        public ImagesManager(List<SiteParser> siteParsers) {
            parsers = siteParsers;
        }

        public void loadImages()
        {
            foreach (SiteParser parser in parsers) {
                List<SiteImage> l = parser.getImages();
                images.AddRange(l);
            }
        }

        public SiteImage FirstImage()
        {
            index = 0;
            return images.First();
        }

        public SiteImage NextImage()
        {
            if (index < images.Count - 1) index++;
            else
            {
                loadImages();
                index++;
            }
            return images[index];
        }

        public SiteImage PrevImage()
        {
            if (index > 0) index--;
            else throw new Exception();
            return images[index];
        }

        public int Count()
        {
            return images.Count;
        }

        public int CurrentIndex()
        {
            return index;
        }
    }
}
