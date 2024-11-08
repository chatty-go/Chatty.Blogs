namespace Chatty.Blogs.Web.Areas.Admin.Models.Series
{
	public class SeriesArticleItemModel
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
		/// 文章状态 1=发布 0=草稿
		/// </summary>
		public int Status { get; set; } = 0;

		/// <summary>
		/// 是否公开 1=公开 0=私有
		/// </summary>
		public int IsPublic { get; set; } = 0;
	}
}
