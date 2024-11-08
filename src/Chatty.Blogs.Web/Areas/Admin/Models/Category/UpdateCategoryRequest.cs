using System.ComponentModel.DataAnnotations;

namespace Chatty.Blogs.Web.Areas.Admin.Models.Category
{
	public class UpdateCategoryRequest
	{
		/// <summary>
		/// ID
		/// </summary>
		[Required]
		public required string RowId { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		[Required]
		public required string Name { get; set; }

		/// <summary>
		/// 排序号
		/// </summary>
		[Required]
		public required int TaxisNo { get; set; }

		/// <summary>
		/// 上级ID
		/// </summary>
		public string? ParentId { get; set; }

		/// <summary>
		/// 是否公开
		/// </summary>
		public int IsPublic { get; set; } = 0;

		/// <summary>
		/// 类型
		/// </summary>
		public required string Type { get; set; }

	}
}
