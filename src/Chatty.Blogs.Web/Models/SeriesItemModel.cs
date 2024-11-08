namespace Chatty.Blogs.Web.Models
{
    public class SeriesItemModel
    {
        public string RowId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CoverImage { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
    }
}
