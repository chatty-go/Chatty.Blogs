
namespace Chatty.Blogs.Entities.Blogs
{
	/// <summary>
	/// 专栏文章
	/// </summary>
	[SugarTable("blog_series_item")]
	public class BlogSeriesItem: BaseEntity
	{
		/// <summary>
		/// 专栏ID
		/// </summary>
		[SugarColumn(ColumnName = "series_id")]
		public int SeriesId { get; set; }

		/// <summary>
		/// 文章ID
		/// </summary>
		[SugarColumn(ColumnName = "article_id")]
		public int ArticleId { get; set; }

		/// <summary>
		/// 标题
		/// </summary>
		[SugarColumn(ColumnName = "title")]
		public string Title { get; set; } = null!;

		/// <summary>
		/// 排序号
		/// </summary>
		[SugarColumn(ColumnName = "taxis_no")]
		public int TaxisNo { get; set; }
	}
}
