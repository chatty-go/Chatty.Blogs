using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Blogs.Category.Dtos;

namespace Chatty.Blogs.Services.Blogs.Category
{
    public class CategoryService(BaseRepository<BlogCategory> baseRepository): ICategoryService
    {
        private readonly BaseRepository<BlogCategory> _baseRepository = baseRepository;

        public async Task<List<BlogCategory>> GetListAsync()
        {
            return await _baseRepository.AsQueryable().
                Where(x => x.Type == "Front")
                .OrderBy(x => x.TaxisNo, OrderByType.Asc)
                .ToListAsync();
        }

        public async Task<List<CategoryArticleGroupItem>> GetGroupListAsync()
        {
            var result = await _baseRepository.AsQueryable()
                .LeftJoin<BlogArticle>((x,y)=>x.RowId==y.FrontCategoryId && y.Status == 1 && y.IsPublic == 1 && y.DeleteFlag == "N")
                .GroupBy((x,y)=>new { x.RowId,x.Name})
                .Where((x,y) => x.Type == "Front")
                .Select((x,y) => new CategoryArticleGroupItem
                {
                    RowId = x.RowId,
                    Name = x.Name,
                    Count = SqlFunc.AggregateCount(y.RowId)
                })
                .MergeTable()
                .OrderBy(x => x.Count, OrderByType.Asc)
                .ToListAsync();

            return result;
        }

    }
}
