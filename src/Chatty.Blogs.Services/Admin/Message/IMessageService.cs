using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.Message
{
    public interface IMessageService
    {
        Task<Tuple<List<SiteMessage>, int>> GetPageListAsync(PageRequest request);

        Task<List<SiteMessage>> GetNewListAsync();

        Task<bool> SetAllReadedAsync();

    }
}
