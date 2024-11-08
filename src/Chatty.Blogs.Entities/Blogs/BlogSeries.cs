
namespace Chatty.Blogs.Entities.Blogs
{
	/// <summary>
	/// 专栏
	/// </summary>
	[SugarTable("blog_series")]
	public class BlogSeries: BaseEntity
	{
		/// <summary>
		/// 专栏标题
		/// </summary>
		[SugarColumn(ColumnName = "title")]
		public string Title { get; set; } = null!;

		/// <summary>
		/// 专栏简介
		/// </summary>
		[SugarColumn(ColumnName = "description")]
		public string Description { get; set; } = null!;

		/// <summary>
		/// 专栏封面
		/// </summary>
		[SugarColumn(ColumnName = "cover_image")]
		public string CoverImage { get; set; } = null!;

		/// <summary>
		/// 专栏排序号
		/// </summary>
		[SugarColumn(ColumnName = "taxis_no")]
		public int TaxisNo { get; set; }

        /// <summary>
        /// 是否公开 
        /// </summary>
        [SugarColumn(ColumnName = "is_public")]
        public int IsPublic { get; set; }

    }
}
