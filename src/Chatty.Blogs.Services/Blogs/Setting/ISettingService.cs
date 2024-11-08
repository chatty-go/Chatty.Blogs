using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Setting
{
    public interface ISettingService
    {
        Task<SiteConfig> GetSettingAsync();
    }
}
