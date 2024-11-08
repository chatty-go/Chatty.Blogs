using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Article
{
    public interface IArticleCommentService
    {
        Task<List<BlogArticleComment>> TakeTenAsync(string articleId);

        Task<bool> InsertAsync(BlogArticleComment blogArticleComment);
    }
}
