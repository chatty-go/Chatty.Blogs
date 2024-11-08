namespace Chatty.Blogs.Web.Areas.Admin.Models.Setting
{
    /// <summary>
    /// SEO
    /// </summary>
    public class SeoRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public required string RowId { get; set; }

        public string? HomeTitle { get; set; }

        public string? MetaDescription { get; set; }

        public string? Keywords { get; set; }
    }
}
