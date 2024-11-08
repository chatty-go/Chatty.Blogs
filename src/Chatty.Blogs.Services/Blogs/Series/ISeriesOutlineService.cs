using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Series
{
    public interface ISeriesOutlineService
    {
        Task<List<BlogSeriesOutlineTree>> GetTreeList(string seriesId);
    }
}
