﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyImagesViewer
{
    class SiteImage
    {
        public string Address { get; private set; }
        public string Title { get; private set; }

        public SiteImage(string address, string title)
        {
            Address = address;
            Title = title;
        }
    }
}
