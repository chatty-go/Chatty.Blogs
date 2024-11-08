using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class MessageIndexViewModel
    {
        public List<SiteMessage> List { get; set; } = [];

        public int TotalMessage { get; set; }

        public bool Finished { get; set; } = false;
    }
}
