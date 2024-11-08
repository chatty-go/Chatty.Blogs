namespace Chatty.Blogs.Web.Models
{
    public class ArticleListItemModel
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

    }
}
