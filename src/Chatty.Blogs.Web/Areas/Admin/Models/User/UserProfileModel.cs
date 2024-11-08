namespace Chatty.Blogs.Web.Areas.Admin.Models.User
{
    public class UserProfileModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// 用户头像
        /// </summary>
        public string Avatar { get; set; } = null!;

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nickname { get; set; } = null!;

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; } = null!;

        /// <summary>
        /// 状态  Active=正常 Blocked=禁用
        /// </summary>
        public string Status { get; set; } = "Active";
    }
}
