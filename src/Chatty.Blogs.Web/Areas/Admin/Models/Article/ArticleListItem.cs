namespace Chatty.Blogs.Web.Areas.Admin.Models.Article
{
    public class ArticleListItem
    {
        /// <summary>
        /// ID
        /// </summary>
        public string? RowId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        public string? CoverUrl { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string? Quote { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? LastUpdDate { get; set; }

        /// <summary>
        /// 文章状态 1=发布 0=草稿
        /// </summary>
        public int Status { get; set; } = 0;
    }
}
