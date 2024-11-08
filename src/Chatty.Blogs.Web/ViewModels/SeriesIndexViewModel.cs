using Chatty.Blogs.Web.Models;

namespace Chatty.Blogs.Web.ViewModels
{
    public class SeriesIndexViewModel
    {
        public int Total { get; set; }

        public List<SeriesItemModel> List { get; set; } = null!;

        /// <summary>
        /// 总页数
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; }
    }
}
