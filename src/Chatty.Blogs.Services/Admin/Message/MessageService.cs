using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.Message
{
    public class MessageService(BaseRepository<SiteMessage> baseRepository): IMessageService
    {
        private readonly BaseRepository<SiteMessage> _baseRepository = baseRepository;

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<List<SiteMessage>, int>> GetPageListAsync(PageRequest request)
        {
            RefAsync<int> total = 0;

            var list = await _baseRepository
                .AsQueryable()
                .Where(a => a.DeleteFlag == "N" && a.Type==request.Search)
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .ToPageListAsync(request.Page, request.Limit, total);

            return Tuple.Create(list, total.Value);
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<SiteMessage>> GetNewListAsync()
        {
            var list = await _baseRepository
                .AsQueryable()
                .Where(a => a.DeleteFlag == "N" && a.IsReaded == 0)
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .ToListAsync();

            return list;
        }

        public async Task<bool> SetAllReadedAsync()
        {
            return await _baseRepository
                .AsUpdateable()
                .SetColumns(a => a.IsReaded == 1)
                .Where(a => a.IsReaded == 0)
                .ExecuteCommandAsync() > 0;
        }

    }
}
