using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class HomeMessageViewModel
    {
        public List<SiteMessage> Messages { get; set; } = new List<SiteMessage>();
    }
}
