
namespace Chatty.Blogs.Entities.Blogs
{
	/// <summary>
	/// 专栏目录
	/// </summary>
	[SugarTable("blog_series_outline")]
	public class BlogSeriesOutline:BaseEntity
	{
		/// <summary>
		/// 名称
		/// </summary>
		[SugarColumn(ColumnName = "name")]
		public string Name { get; set; } = null!;

		/// <summary>
		/// 排序号
		/// </summary>
		[SugarColumn(ColumnName = "taxis_no")]
		public int TaxisNo { get; set; }

		/// <summary>
		/// 上级ID
		/// </summary>
		[SugarColumn(ColumnName = "parent_id")]
		public string ParentId { get; set; } = "0";

		/// <summary>
		/// 目录类型
		/// </summary>
		[SugarColumn(ColumnName = "type")]
		public string Type { get; set; } = null!;

		/// <summary>
		/// 跳转链接
		/// </summary>
		[SugarColumn(ColumnName = "href")]
		public string Href { get; set; } = null!;

		/// <summary>
		/// 专栏ID
		/// </summary>
		[SugarColumn(ColumnName = "series_id")]
		public string SeriesId  { get; set; } = null!;

		/// <summary>
		/// 打开方式
		/// </summary>
		[SugarColumn(ColumnName = "open_target")]
		public string OpenTarget { get; set; } = null!;

		/// <summary>
		/// 关联文章ID
		/// </summary>
		[SugarColumn(ColumnName = "article_id")]
		public string ArticleId { get; set; } = null!;

		/// <summary>
		/// 关联文章名称
		/// </summary>
		[SugarColumn(IsIgnore = true)]
		public string ArticleName { get; set; } = null!;
	}
}
