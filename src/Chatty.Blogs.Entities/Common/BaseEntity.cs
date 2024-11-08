using SqlSugar;

namespace Chatty.Blogs.Entities.Common
{

    /// <summary>
    /// Base Entity
    /// </summary>
    public class BaseEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "row_id")]
		/// <summary>
		/// ID
		/// </summary>
		public string RowId { get; set; } = null!;

		/// <summary>
		/// 创建时间
		/// </summary>
		[SugarColumn(ColumnName = "created_date", IsOnlyIgnoreUpdate=true)]
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// 创建人
		/// </summary>
		[SugarColumn(ColumnName = "created_by", IsOnlyIgnoreUpdate = true)]
		public string CreatedBy { get; set; } = null!;

		/// <summary>
		/// 最后修改人
		/// </summary>
		[SugarColumn(ColumnName = "last_upd_by")]
		public string? LastUpdBy { get; set; }

		/// <summary>
		/// 最后修改时间
		/// </summary>
		[SugarColumn(ColumnName = "last_upd_date")]
		public DateTime? LastUpdDate { get; set; }

		/// <summary>
		/// 删除标志 
		/// </summary>
		[SugarColumn(ColumnName = "delete_flag", IsOnlyIgnoreUpdate = true)]
		public string DeleteFlag { get; set; } = null!;

    }
}
