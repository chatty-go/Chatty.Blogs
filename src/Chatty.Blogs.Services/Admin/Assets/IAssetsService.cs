using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.Assets
{
    public interface IAssetsService
    {
        Task<Tuple<List<BlogAssets>, int>> GetPageListAsync(PageRequest request);

        Task<bool> AddAsync(BlogAssets blogAssets);

        Task<bool> DeleteAsync(string id);

        Task<bool> UpdateNameAsync(string id, string name);
    }
}
