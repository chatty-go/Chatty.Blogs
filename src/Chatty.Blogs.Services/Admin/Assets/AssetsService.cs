using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.Assets
{
    public class AssetsService(BaseRepository<BlogAssets> baseRepository): IAssetsService
    {
        private readonly BaseRepository<BlogAssets> _baseRepository = baseRepository;

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<List<BlogAssets>, int>> GetPageListAsync(PageRequest request)
        {
            RefAsync<int> total = 0;

            var list = await _baseRepository
                .AsQueryable()
                .Where(a => a.DeleteFlag == "N")
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .ToPageListAsync(request.Page, request.Limit, total);

            return Tuple.Create(list, total.Value);
        }

        public async Task<bool> AddAsync(BlogAssets blogAssets)
        {
            return await _baseRepository.InsertAsync(blogAssets);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _baseRepository.DeleteAsync(a => a.RowId == id);
        }

        public async Task<bool> UpdateNameAsync(string id,string name)
        {
            return await _baseRepository.AsUpdateable()
                .SetColumns(a => a.Name == name)
                .Where(a => a.RowId == id)
                .ExecuteCommandAsync() > 0;
        }
    }
}
