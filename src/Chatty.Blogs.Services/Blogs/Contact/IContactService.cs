using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Contact
{
    public interface IContactService
    {
        Task<SiteConfig> GetAsync();

        Task<bool> AddAsync(SiteMessage entity);
    }
}
