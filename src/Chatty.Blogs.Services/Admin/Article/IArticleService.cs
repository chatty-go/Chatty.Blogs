using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Admin.Article.Dtos;

namespace Chatty.Blogs.Services.Admin.Article
{
    public interface IArticleService
    {
        Task<BlogArticle> GetByIdAsync(string rowId);

		Task<int> GetCountAsync();

		Task<List<BlogArticle>> GetSeriesListAsync(string seriesId);

		Task<BlogArticle> GetTopAsync();

        Task<ArticleWithDetailDto> GetAsync(string rowId);

        Task<Tuple<List<BlogArticle>, int>> GetPageListAsync(PageRequest request);

        Task<bool> SaveAsync(BlogArticle entity);

        Task<bool> SaveChangeAsync(BlogArticle entity);

        Task<bool> DeleteByIdAsync(string rowId);

        Task<List<BlogArticle>> GetDraftListAsync();

        Task<bool> Offline(string rowId);

        Task<Tuple<List<BlogArticle>, int>> GetPageListAsync(PageByCategoryRequest request);

	}
}
