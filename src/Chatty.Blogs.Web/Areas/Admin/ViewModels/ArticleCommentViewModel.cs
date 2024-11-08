using Chatty.Blogs.Services.Admin.Article.Dtos;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class ArticleCommentViewModel
    {
        public List<ArticleCommentListItem> List { get; set; } = [];

        public int Total { get; set; }

        public bool Finished { get; set; }
    }
}
