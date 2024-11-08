using Chatty.Blogs.Web.Areas.Admin.Models.Article;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class ArticleListViewModel
    {
        /// <summary>
        /// 文章列表
        /// </summary>
        public List<ArticleListItem> List { get; set; } = null!;

        /// <summary>
        /// 总文章数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime Today { get; set; } = DateTime.Now;

        /// <summary>
        /// 排序方式
        /// </summary>
        public string? Sort { get; set; } 

        /// <summary>
        /// 搜索
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// 可见范围
        /// </summary>
        public int? Range { get; set; }

        public int? Status { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 是否分页结束
        /// </summary>
        public bool Finished { get; set; }
    }
}
