using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Web.Areas.Admin.Models.Series;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    public class SeriesDetailViewModel
    {
        public BlogSeries Series { get; set; } = null!;

        public object Outlines { get; set; } = new List<object>();

        public List<SeriesArticleItemModel> Articles { get; set; } = new List<SeriesArticleItemModel>();
    }
}
