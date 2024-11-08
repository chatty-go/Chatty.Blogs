using Chatty.Blogs.Web.Models;

namespace Chatty.Blogs.Web.ViewModels
{
    public class BlogTagsViewModel
    {
        public string? Tag { get; set; }
        public bool Finished { get; set; }

        public int Total { get; set; }

        public List<ArticleListItemModel> Articles { get; set; } = [];

        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        public int Pages { get; set; }
    }
}
