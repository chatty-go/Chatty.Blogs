namespace Chatty.Blogs.Web.Models
{
	public class ArticleCommentModel
	{
		/// <summary>
		/// ID
		/// </summary>
		public string RowId { get; set; } = null!;

		/// <summary>
		/// Created Date
		/// </summary>
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// Name
		/// </summary>
		public required string Name { get; set; }

		/// <summary>
		/// Email
		/// </summary>
		public required string Email { get; set; }

		/// <summary>
		/// Website
		/// </summary>
		public required string Website { get; set; }

		/// <summary>
		/// Content
		/// </summary>
		public required string Content { get; set; }

		/// <summary>
		/// Article Id
		/// </summary>
		public required string ArticleId { get; set; }
	}
}
