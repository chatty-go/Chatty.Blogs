namespace Chatty.Blogs.Web.Areas.Admin.Models.Setting
{
    public class ChangeProfileRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public required string UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public required string Nickname { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public required string Avatar { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public required string Email { get; set; }
    }
}
