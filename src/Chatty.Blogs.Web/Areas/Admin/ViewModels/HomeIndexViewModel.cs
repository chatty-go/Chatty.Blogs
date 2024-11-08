using Chatty.Blogs.Web.Areas.Admin.Models.Article;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class HomeIndexViewModel
    {
        /// <summary>
        /// Drafts
        /// </summary>
        public List<ArticleListItem> Articles { get; set; } = new List<ArticleListItem>();

        public int TotalArticle { get; set; }

        public int TotalVisitor { get; set; }

        public int TotalUser { get; set; }
    }
}
