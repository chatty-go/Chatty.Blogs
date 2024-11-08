using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Admin.Article.Dtos;

namespace Chatty.Blogs.Services.Admin.Article
{
    public class ArticleService(BaseRepository<BlogArticle> baseRepository) : IArticleService
    {
        private readonly BaseRepository<BlogArticle> _baseRepository = baseRepository;

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<List<BlogArticle>, int>> GetPageListAsync(PageRequest request)
        {
            RefAsync<int> total = 0;

            var list = await _baseRepository
                .AsQueryable()
                .Where(a => a.DeleteFlag == "N")
                .WhereIF(request.Status != null, a => a.Status == request.Status)
                .WhereIF(request.Range !=null, a=>a.IsPublic ==request.Range)
                .WhereIF(!string.IsNullOrEmpty(request.Search), a => a.Title.Contains(request.Search) || a.Quote.Contains(request.Search))
                .OrderByIF(request.Sort=="created", a => a.CreatedDate, OrderByType.Desc)
                .OrderByIF(request.Sort == "updated", a => a.LastUpdDate, OrderByType.Desc)
                .Select(a=>new BlogArticle
                {
                    RowId = a.RowId,
                    Title = a.Title,
                    CoverUrl = a.CoverUrl,
                    CreatedDate = a.CreatedDate,
                    LastUpdDate = a.LastUpdDate,
                    Quote = a.Quote,
                    Status = a.Status,
                })
                .ToPageListAsync(request.Page, request.Limit,total);

            return Tuple.Create(list, total.Value);
        }

		/// <summary>
		/// 根据分类获取分页列表
		/// </summary>
		/// <returns></returns>
		public async Task<Tuple<List<BlogArticle>, int>> GetPageListAsync(PageByCategoryRequest request)
		{
			var pgae = new PageModel()
			{
				PageIndex = request.Page,
				PageSize = request.Limit
			};

			var list = await _baseRepository
				.GetPageListAsync(a => a.DeleteFlag == "N" && a.CategoryId==request.CategoryId, pgae, a => a.CreatedDate, OrderByType.Desc);

			return Tuple.Create(list, pgae.TotalCount);
		}

		/// <summary>
		/// 获取草稿列表
		/// </summary>
		/// <returns></returns>
		public async Task<List<BlogArticle>> GetDraftListAsync()
        {
            var list = await _baseRepository.AsQueryable()
                .Where(a => a.DeleteFlag == "N" && a.Status == 0)
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .ToListAsync();

            return list;
        }

		/// <summary>
		/// 获取专栏文章列表
		/// </summary>
		/// <returns></returns>
		public async Task<List<BlogArticle>> GetSeriesListAsync(string seriesId)
		{
			var list = await _baseRepository.AsQueryable()
				.Where(a => a.DeleteFlag == "N" && a.SeriesId == seriesId)
				.OrderBy(a => a.CreatedDate, OrderByType.Desc)
				.ToListAsync();

			return list;
		}

		public async Task<BlogArticle> GetByIdAsync(string rowId)
		{
			return await _baseRepository.GetByIdAsync(rowId);
		}

		/// <summary>
		/// 查询明细
		/// </summary>
		/// <param name="rowId"></param>
		/// <returns></returns>
		public async Task<ArticleWithDetailDto> GetAsync(string rowId)
        {
            return await _baseRepository.AsQueryable()
                .LeftJoin<BlogCategory>((a, b) => a.CategoryId == b.RowId)
                .Where(a => a.RowId == rowId)
                .Select((a, b) => new ArticleWithDetailDto
                {
                    CategoryId = a.CategoryId,
                    CategoryName = b.Name,
                    Content = a.Content,
                    CoverUrl = a.CoverUrl,
                    IsTop = a.IsTop,
                    Title = a.Title,
                    HomeBlock = a.HomeBlock,
                    IsPublic = a.IsPublic,
                    Outline = a.Outline,
                    ParentPath = a.ParentPath,
                    Quote = a.Quote,
                    SeriesId = a.SeriesId,
                    Status = a.Status,
                    Tags = a.Tags,
                    RowId = a.RowId,
                    CreatedDate = a.CreatedDate,
                    FrontCategoryId = a.FrontCategoryId
                })
                .FirstAsync();
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(BlogArticle entity)
        {
            await _baseRepository.InsertAsync(entity);

            if (entity.IsTop == 1)
            {
                await SetTopAsync(entity.RowId);
            }

            return true;
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
		public async Task<bool> SaveChangeAsync(BlogArticle entity)
        {
            await _baseRepository.UpdateAsync(entity);

            if (entity.IsTop == 1)
            {
                await SetTopAsync(entity.RowId);
            }

            return true;
        }

        /// <summary>
        /// 设置为头条
        /// </summary>
        /// <param name="rowId"></param>
        /// <returns></returns>
        public async Task<bool> SetTopAsync(string rowId)
        {
            await _baseRepository.AsUpdateable()
                .SetColumns(a => a.IsTop == 0)
                .Where(a => a.IsTop == 1)
                .ExecuteCommandAsync();

            await _baseRepository.AsUpdateable()
                .SetColumns(a => a.IsTop == 1)
                .Where(a => a.RowId == rowId)
                .ExecuteCommandAsync();

            return true;
        }

        /// <summary>
        /// 获取头条
        /// </summary>
        /// <returns></returns>
        public async Task<BlogArticle> GetTopAsync()
        {
            return await _baseRepository.AsQueryable()
                .FirstAsync(a => a.IsTop == 1);
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="rowId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteByIdAsync(string rowId)
        {
            await _baseRepository.DeleteByIdAsync(rowId);

            return true;
        }

        public async Task<bool> Offline(string rowId)
        {
            return await _baseRepository.AsUpdateable()
                .SetColumns(a => a.Status == 0)
                .Where(a => a.RowId == rowId)
                .ExecuteCommandAsync() > 0;
        }

        public async Task<int> GetCountAsync()
        {
            return await _baseRepository.AsQueryable()
                .Where(a=>a.DeleteFlag=="N")
                .CountAsync();
        }

    }
}
