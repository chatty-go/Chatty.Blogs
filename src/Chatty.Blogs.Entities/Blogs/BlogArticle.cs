
namespace Chatty.Blogs.Entities.Blogs
{
	/// <summary>
	/// 文章表
	/// </summary>
	[SugarTable("blog_article")]
	public class BlogArticle : BaseEntity
	{
		/// <summary>
		/// 标题
		/// </summary>
		public string Title { get; set; } = null!;

		/// <summary>
		/// 正文
		/// </summary>
		public string Content { get; set; } = null!;

		/// <summary>
		/// 是否公开
		/// </summary>
		[SugarColumn(ColumnName = "is_public")]
		public int IsPublic { get; set; }

		/// <summary>
		/// 文章路径
		/// </summary>
		[SugarColumn(ColumnName = "parent_path")]
		public string ParentPath { get; set; } = null!;

		/// <summary>
		/// 文章标签
		/// </summary>
		[SugarColumn(ColumnName = "tags")]
		public string? Tags { get; set; }

		/// <summary>
		/// 目录
		/// </summary>

		[SugarColumn(ColumnName = "outline")]
		public string Outline { get; set; } = null!;

        /// <summary>
        /// 摘要
        /// </summary>

        [SugarColumn(ColumnName = "quote")]
        public string Quote { get; set; } = null!;

		/// <summary>
		/// 是否置顶
		/// </summary>
		[SugarColumn(ColumnName = "is_top")]
		public int IsTop { get; set; } = 0;

        /// <summary>
        /// 首页版块
        /// </summary>
        [SugarColumn(ColumnName = "home_block")]
        public string HomeBlock { get; set; } = "Default";

        /// <summary>
        /// 文章状态 0:草稿 1:发布 
        /// </summary>
        [SugarColumn(ColumnName = "status")]
        public int Status { get; set; } = 0;

        /// <summary>
        /// 分类ID
        /// </summary>
        [SugarColumn(ColumnName = "category_id")]
        public string? CategoryId { get; set; }

        /// <summary>
        /// 前台分类ID
        /// </summary>
        [SugarColumn(ColumnName = "front_category_id")]
        public string? FrontCategoryId { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        [SugarColumn(ColumnName = "cover_url")]
        public string CoverUrl{ get; set; } = null!;

		/// <summary>
		/// 专栏ID
		/// </summary>
		[SugarColumn(ColumnName = "series_id")]
		public string SeriesId { get; set; } = null!;

		/// <summary>
		/// 浏览量
		/// </summary>
		[SugarColumn(ColumnName = "view_count")]
		public int ViewCount { get; set; } 
	}
}
