using System.Collections.Generic;

namespace FunnyImagesViewer
{
    abstract class SiteParser
    {
        //This method should return 10 SiteImages each time it's called
        public abstract List<SiteImage> getImages();
    }
}
