using System.ComponentModel.DataAnnotations;

namespace Chatty.Blogs.Web.Areas.Admin.Models.Series
{
	public class NewOutlineRequest
	{
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
		/// 上级ID
		/// </summary>
		public string ParentId { get; set; } = "0";

		/// <summary>
		/// 专栏ID
		/// </summary>
		[Required]
		public required string SeriesId { get; set; }
	}
}
