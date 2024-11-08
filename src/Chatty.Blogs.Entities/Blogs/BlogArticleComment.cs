
namespace Chatty.Blogs.Entities.Blogs
{
    /// <summary>
    /// Article Comments
    /// </summary>
    [SugarTable("blog_article_comment")]
    public class BlogArticleComment:BaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Comment
        /// </summary>
        [SugarColumn(ColumnName = "content")]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        [SugarColumn(ColumnName = "email")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Website
        /// </summary>
        [SugarColumn(ColumnName = "website")]
        public string Website { get; set; } = null!;

        /// <summary>
        /// Article Id
        /// </summary>
        [SugarColumn(ColumnName = "article_id")]
        public string ArticleId { get; set; } = null!;

        /// <summary>
        /// Status, 0=New,1=Approved
        /// </summary>
        [SugarColumn(ColumnName = "status")]
        public int Status { get; set; } = 0;
    }
}
