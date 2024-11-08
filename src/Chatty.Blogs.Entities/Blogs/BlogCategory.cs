
namespace Chatty.Blogs.Entities.Blogs
{
	/// <summary>
	/// 文章分类
	/// </summary>

	[SugarTable("blog_category")]
	public class BlogCategory: BaseEntity
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
		public string ParentId { get; set; } = null!;

		/// <summary>
		/// 是否公开
		/// </summary>
		[SugarColumn(ColumnName = "is_public")]
		public int IsPublic { get; set; }

		/// <summary>
		/// 类型 Back=后台, Front=前台
		/// </summary>
		[SugarColumn(ColumnName = "type")]
		public string Type { get; set; } = null!;

    }
}
