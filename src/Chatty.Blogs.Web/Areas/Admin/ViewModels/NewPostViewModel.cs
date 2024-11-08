using Chatty.Blogs.Services.Admin.Article.Dtos;
using Chatty.Blogs.Web.Areas.Admin.Models.Article;
using Chatty.Blogs.Web.Areas.Admin.Models.Category;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class NewPostViewModel
    {
        public string? RowId { get; set; }

        public ArticleWithDetailDto Article { get; set; } = null!;

        public List<SeriesListItem> Series { get; set; } = new();

        public string? SeriesId { get; set; }

        public List<CategoryTreeNode> BackCategories { get; set; } = new List<CategoryTreeNode>();

		public List<CategoryTreeNode> FrontCategories { get; set; } = new List<CategoryTreeNode>();

        public CategoryTreeNode? SelectedCategory { get; set; }
	}
}
