using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Services.Admin.Article.Dtos;

namespace Chatty.Blogs.Services.Admin.Article
{
    public interface IArticleCommentService
    {
        Task<Tuple<List<ArticleCommentListItem>, int>> GetPageListAsync(PageRequest request);

        Task<bool> RejectAsync(string id);

        Task<bool> ApprovalAsync(string id);

        Task<bool> DeleteAsync(string id);
    }
}
