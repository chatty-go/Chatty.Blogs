namespace Chatty.Blogs.Web.Areas.Admin.Models.Article
{
    public class ArticlePreviewModel
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
        /// 正文
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        public string? Outline { get; set; }

        /// <summary>
        /// 是否公开
        /// </summary>
        public int IsPublic { get; set; }

        /// <summary>
        /// 是否头条
        /// </summary>
        public int IsTop { get; set; }

        /// <summary>
        /// 专栏ID
        /// </summary>
        public string? SeriesId { get; set; }

        /// <summary>
        /// 首页版块
        /// </summary>
        public string HomeBlock { get; set; } = "Default";

        /// <summary>
        /// 文章状态 0:草稿 1:已发布 
        /// </summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// 分类ID
        /// </summary>
        public string? CategoryId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 文章标签
        /// </summary>
        public string? Tags { get; set; }
    }
}
