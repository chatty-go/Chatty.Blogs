using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Series
{
    public interface ISeriesService
    {
        Task<Tuple<List<BlogSeries>, int>> GetPageListAsync(PageRequest request);

        Task<BlogSeries> GetByIdAsync(string id);

	}
}
