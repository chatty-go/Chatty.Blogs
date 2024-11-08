using Chatty.Blogs.Web.Areas.Admin.Models.Assets;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class AssetsIndexViewModel
    {
        public List<AssetsListItemModel> List { get; set; } =  [];

        public int Total { get; set; }

        public bool Finished { get; set; } = false;

    }
}
