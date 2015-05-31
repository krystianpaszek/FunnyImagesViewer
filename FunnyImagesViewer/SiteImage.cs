
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
