using System.ComponentModel.DataAnnotations;

namespace Chatty.Blogs.Web.Areas.Admin.Models.Series
{
	public class UpdateOutlineRequest
	{
		/// <summary>
		/// ID
		/// </summary>
		[Required]
		public required string RowId { get; set; }

		/// <summary>
		/// Name
		/// </summary>
		[Required]
		public required string Name { get; set; }

		/// <summary>
		/// 序号
		/// </summary>
		public int TaxisNo { get; set; }

		/// <summary>
		/// 专栏ID
		/// </summary>
		[Required]
		public required string SeriesId { get; set; }

		/// <summary>
		/// 关联文章ID
		/// </summary>
		public string? ArticleId { get; set; }

		/// <summary>
		/// 栏目类型
		/// </summary>
		public string? Type { get; set; }

		/// <summary>
		/// 外部链接
		/// </summary>
		public string? Href { get; set; }

		/// <summary>
		/// Parent Id
		/// </summary>
		public string? ParentId { get; set; }
	}
}
