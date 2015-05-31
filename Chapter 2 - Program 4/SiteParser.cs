using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Chapter_2___Program_4
{
    abstract class SiteParser
    {
        public abstract List<SiteImage> getImages();
    }
}
