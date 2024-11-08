using Chatty.Blogs.Services.Blogs.Article.Dtos;
using Chatty.Blogs.Services.Blogs.Category.Dtos;
using Chatty.Blogs.Web.Models;

namespace Chatty.Blogs.Web.ViewModels
{
    public class BlogIndexViewModel
    {
        public int Total { get; set; }

        public List<ArticleListItemModel> Articles { get; set; } = [];

        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        public int Pages { get; set; }

        public List<CategoryArticleGroupItem> Categories { get; set; } = [];

        public CategoryArticleGroupItem? Filter { get; set; }

        public List<TagCloudCount> TagCloudList { get; set; } = new List<TagCloudCount>();
    }
}
