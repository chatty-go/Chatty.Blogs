using Chatty.Blogs.Entities.Common;
using SqlSugar;

namespace Chatty.Blogs.Entities.Blogs
{
	/// <summary>
	/// 用户表
	/// </summary>
	[SugarTable("blog_user")]
	public class BlogUser:BaseEntity
	{
		/// <summary>
		/// 用户名
		/// </summary>
		[SugarColumn(ColumnName = "username")]
		public string UserName { get; set; } = null!;

		/// <summary>
		/// 登录密码
		/// </summary>
		[SugarColumn(ColumnName = "password")]
		public string Password { get; set; } = null!;

		/// <summary>
		/// 角色
		/// </summary>
		[SugarColumn(ColumnName = "role")]
		public string Role { get; set; } = null!;

        /// <summary>
        /// 用户头像
        /// </summary>
        [SugarColumn(ColumnName = "avatar")]
        public string Avatar { get; set; } = null!;

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "nickname")]
        public string Nickname { get; set; } = null!;

		/// <summary>
		/// 邮箱
		/// </summary>
		[SugarColumn(ColumnName = "email")]
		public string Email { get; set; } = null!;

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnName = "status")]
        public string Status { get; set; } = null!;

    }
}
