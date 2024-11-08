namespace Chatty.Blogs.Web.Areas.Admin.Models.Series
{
    public class SeriesModel
    {
        public string RowId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CoverImage { get; set; } = null!;

        public int TaxisNo { get; set; }

        public int IsPublic { get; set; }
    }
}
