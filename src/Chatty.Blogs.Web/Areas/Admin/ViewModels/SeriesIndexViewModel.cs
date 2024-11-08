using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class SeriesIndexViewModel
    {
        public int TotalCount { get; set; }

        public List<BlogSeries> List { get; set; } = new();

        public int Page { get; set; }

        public int Limit { get; set; }

        public bool Finished { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public string? Sort { get; set; }

        /// <summary>
        /// 搜索
        /// </summary>
        public string? Search { get; set; }
    }
}
