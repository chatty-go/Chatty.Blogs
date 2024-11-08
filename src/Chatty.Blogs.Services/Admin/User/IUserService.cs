using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.User
{
    public interface IUserService
    {
        Task<BlogUser> GetByUserName(string username);

        Task<bool> ChangeProfile(BlogUser entity);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> ChangePassword(BlogUser entity);
    }
}
