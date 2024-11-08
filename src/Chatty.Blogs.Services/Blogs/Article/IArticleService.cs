using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Services.Blogs.Article.Dtos;

namespace Chatty.Blogs.Services.Blogs.Article
{
    /// <summary>
    /// 文章管理 - 服务接口
    /// </summary>
    public interface IArticleService
    {
        Task<BlogArticle> GetTopAsync();

		Task<BlogArticle> GetAsync(string rowId);

		Task<Tuple<List<BlogArticle>, int>> GetPageListAsync(BlogPageRequest request);

        Task<List<BlogArticle>> TakeTenListAsync(string homeBlock);

        Task<List<BlogArticle>> GetRecentAsync();

        Task<List<BlogArticle>> GetPopularAsync(int limit=4);

        Task<List<TagCloudCount>> GetTagCloudListAsync();

        Task<Tuple<List<BlogArticle>, int>> GetTagArticleListAsync(BlogPageRequest request);

        Task<Tuple<List<BlogArticle>, int>> GetBlockArticleListAsync(BlogPageRequest request);

    }
}
