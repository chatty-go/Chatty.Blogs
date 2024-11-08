using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Web.Models;

namespace Chatty.Blogs.Web.ViewModels
{
    public class SeriesDetailViewModel
    {
        public string SeriesId { get; set; } = null!;

        public SeriesItemModel? Series { get; set; }

        public ArticleDetailModel Article { get; set; } = null!;

        public string CurrentOutlineId { get; set; } = null!;

        public List<BlogSeriesOutlineTree> Outlines { get; set; } = new List<BlogSeriesOutlineTree>();

    }
}
