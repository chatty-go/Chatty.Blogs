using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.User
{
    /// <summary>
    /// 用户管理服务
    /// </summary>
    /// <param name="baseRepository"></param>
    public class UserService(BaseRepository<BlogUser> baseRepository):IUserService
    {
        private readonly BaseRepository<BlogUser> _baseRepository = baseRepository;

        public async Task<BlogUser> GetByUserName(string userName)
        {
            return await _baseRepository.GetFirstAsync(a=>a.UserName== userName);
        }

        public async Task<bool> ChangeProfile(BlogUser entity)
        {
            return await _baseRepository.AsUpdateable()
                .SetColumns(a => new BlogUser() { 
                    Nickname = entity.Nickname, 
                    Avatar = entity.Avatar,
                    Email = entity.Email
                })
                .Where(a => a.UserName == entity.UserName)
                .ExecuteCommandAsync() > 0;
        }

        public async Task<bool> ChangePassword(BlogUser entity)
        {
            return await _baseRepository.AsUpdateable()
                .SetColumns(a => new BlogUser() { Password = entity.Password })
                .Where(a => a.UserName == entity.UserName)
                .ExecuteCommandAsync() > 0;
        }
    }
}
