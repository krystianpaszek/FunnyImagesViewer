using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace FunnyImagesViewer
{
    abstract class SiteParser
    {
        public abstract List<SiteImage> getImages();
    }
}
