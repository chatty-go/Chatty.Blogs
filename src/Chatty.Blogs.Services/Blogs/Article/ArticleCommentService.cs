using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Article
{
    public class ArticleCommentService(BaseRepository<BlogArticleComment> baseRepository) : IArticleCommentService
    {
        private readonly BaseRepository<BlogArticleComment> _baseRepository = baseRepository;

        public async Task<List<BlogArticleComment>> TakeTenAsync(string articleId)
        {
            return await _baseRepository.AsQueryable()
               .Take(10)
                .Where(a => a.ArticleId == articleId)
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .ToListAsync();

        }

        public async Task<bool> InsertAsync(BlogArticleComment blogArticleComment)
        {
            return await _baseRepository.InsertAsync(blogArticleComment);
        }
    }
}
