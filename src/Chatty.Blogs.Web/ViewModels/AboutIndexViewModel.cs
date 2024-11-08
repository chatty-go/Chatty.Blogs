using Chatty.Blogs.Web.Models;

namespace Chatty.Blogs.Web.ViewModels
{
    public class AboutIndexViewModel
    {
        public List<ArticleListItemModel> PopularArticles { get; set; } = [];

        public List<CategoryListItemModel> Categories { get; set; } = [];
    }
}
