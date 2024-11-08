using Chatty.Blogs.Web.Areas.Admin.Models.Category;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class CategoryFrontViewModel
    {
        public List<CategoryTreeNode> List { get; set; } = new List<CategoryTreeNode>();
    }
}
