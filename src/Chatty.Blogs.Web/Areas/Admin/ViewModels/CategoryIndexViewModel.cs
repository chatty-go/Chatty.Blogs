using Chatty.Blogs.Web.Areas.Admin.Models.Category;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class CategoryIndexViewModel
	{
		public List<CategoryTreeNode> Trees { get; set; } = new List<CategoryTreeNode>();
	}
}
