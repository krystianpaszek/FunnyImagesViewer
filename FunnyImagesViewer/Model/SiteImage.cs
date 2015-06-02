using System.Runtime.Serialization;

namespace FunnyImagesViewer
{
    [DataContract]
    class SiteImage
    {
        [DataMember (Name = "link")]
        public string Address { get; private set; }

        [DataMember(Name = "title")]
        public string Title { get; private set; }

        public string Site { get; set; }

        public SiteImage(string address, string title, string site)
        {
            Address = address;
            Title = title;
            Site = Site;
        }
    }
}
