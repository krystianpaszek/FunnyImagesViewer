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

            List<SiteImage> temp = new List<SiteImage>();
            int count = 10;
            foreach (SiteParser parser in parsers) {
                List<SiteImage> l = parser.getImages();
                if (l != null) {
                    temp.AddRange(l);
                    count = l.Count;
                }
            }

            //zrobić foreacha
            //where(co dziesiąty) 1, 11, 21, 31
            //where(co dziesiąty+1) 2, 12, 22, 32
            //itd i będzie dobrze
            for (int i = 0; i < count; i++)
            {
                int j = i;
                while (j < temp.Count)
                {
                    images.Add(temp[j]);
                    j += count;
                }
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
