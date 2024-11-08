using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Admin.Article.Dtos;

namespace Chatty.Blogs.Services.Admin.Article
{
    public class ArticleCommentService(BaseRepository<BlogArticleComment> baseRepository): IArticleCommentService
    {
        private readonly BaseRepository<BlogArticleComment> _baseRepository = baseRepository;

        public async Task<Tuple<List<ArticleCommentListItem>, int>> GetPageListAsync(PageRequest request)
        {
            RefAsync<int> total = 0;

            var list = await _baseRepository
                .AsQueryable()
                .LeftJoin<BlogArticle>((a, b) => a.ArticleId == b.RowId)
                .Where(a => a.DeleteFlag == "N")
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .Select((a,b)=>new ArticleCommentListItem
                {
                    ArticleId = a.ArticleId,
                    Content = a.Content,
                    Email = a.Email,
                    Name = a.Name,
                    Status = a.Status,
                    Website = a.Website,
                    ArticleTitle= b.Title,
                    CreatedDate = a.CreatedDate,
                    RowId = a.RowId
                })
                .ToPageListAsync(request.Page, request.Limit, total);

            return Tuple.Create(list, total.Value);
        }

        public async Task<bool> RejectAsync(string id)
        {
            return await _baseRepository
                .AsUpdateable()
                .SetColumns(a=>a.Status==2)
                .Where(a => a.RowId == id)
                .ExecuteCommandAsync()>0;
        }

        public async Task<bool> ApprovalAsync(string id)
        {
            return await _baseRepository
                .AsUpdateable()
                .SetColumns(a => a.Status == 1)
                .Where(a => a.RowId == id)
                .ExecuteCommandAsync() > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _baseRepository
                .AsDeleteable()
                .Where(a => a.RowId == id)
                .ExecuteCommandAsync() > 0;
        }
    }
}
