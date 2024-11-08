namespace Chatty.Blogs.Web.Areas.Admin.Models.Setting
{
    public class ChangePasswordRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public required string UserName { get; set; }

        /// <summary>
        /// 老密码
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public required string NewPassword { get; set; }
    }
}
