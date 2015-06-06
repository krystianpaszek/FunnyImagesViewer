using System;
using System.Collections.Generic;

namespace FunnyImagesViewer
{
    abstract class SiteParser
    {
        protected List<SiteImage> images = new List<SiteImage>();
        protected Action<String> outputBoxSetter;
        protected int currentPage = 0;
        const int howManyImages = 10;

        //This method should return 10 SiteImages each time it's called
        //public abstract List<SiteImage> getImages();

        public SiteParser(Action<String> outputBoxSetter)
        {
            this.outputBoxSetter = outputBoxSetter;
        }

        public List<SiteImage> getImages()
        {
            currentPage++;
            int amount = currentPage * howManyImages;
            while (images.Count < amount)
            {
                fetchMoreImages();
            }

            return images.GetRange(amount - howManyImages, howManyImages);
        }

        protected abstract void fetchMoreImages();
    }
}
