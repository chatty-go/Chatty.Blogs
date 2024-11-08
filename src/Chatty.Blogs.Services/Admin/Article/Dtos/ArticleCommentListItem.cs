
namespace Chatty.Blogs.Services.Admin.Article.Dtos
{
    public class ArticleCommentListItem
    {
        public string RowId { get; set; } = null!;

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Comment
        /// </summary>
        public string Content { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Website
        /// </summary>
        public string Website { get; set; } = null!;

        /// <summary>
        /// Article Id
        /// </summary>
        public string ArticleId { get; set; } = null!;

        public string ArticleTitle { get; set; } = null!;

        /// <summary>
        /// Status, 0=New,1=Approved
        /// </summary>
        public int Status { get; set; } = 0;

        public DateTime CreatedDate { get; set; }
    }
}
