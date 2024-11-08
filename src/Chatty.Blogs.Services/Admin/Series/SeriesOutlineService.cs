using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.Series
{
	public class SeriesOutlineService(BaseRepository<BlogSeriesOutline> baseRepository) : ISeriesOutlineService
	{
		private readonly BaseRepository<BlogSeriesOutline> _baseRepository = baseRepository;

		public async Task<List<BlogSeriesOutline>> GetListAsync(string seriesId)
		{
			return await _baseRepository.AsQueryable()
				.LeftJoin<BlogArticle>((x,a)=>x.ArticleId==a.RowId)
				.Where(x => x.SeriesId == seriesId)
				.OrderBy(x => x.TaxisNo, OrderByType.Asc)
				.Select((x,a)=>new BlogSeriesOutline
				{
					RowId = x.RowId,
					ArticleId = x.ArticleId,
					ArticleName = a.Title,
					CreatedDate = x.CreatedDate,
					Name = x.Name,
					OpenTarget = x.OpenTarget,
					ParentId = x.ParentId,
					Type = x.Type,
					Href = x.Href,
					TaxisNo = x.TaxisNo,
					SeriesId = x.SeriesId
				})
				.ToListAsync();
		}

		public async Task<bool> AddAsync(BlogSeriesOutline entity)
		{
			return await _baseRepository.InsertAsync(entity);
		}

		public async Task<bool> UpdateAsync(BlogSeriesOutline entity)
		{
			return await _baseRepository.UpdateAsync(entity);
		}

		public async Task<bool> DeleteByIdAsync(string id)
		{
			return await _baseRepository.DeleteByIdAsync(id);
		}

		public async Task<int> GetMaxTaxisNoAsync(string seriesId,string? parentId)
		{
			var result = await _baseRepository.AsQueryable()
				.Where(a => a.SeriesId == seriesId)
				.WhereIF(!string.IsNullOrEmpty(parentId), a => a.ParentId == parentId)
				.MaxAsync(a => a.TaxisNo);

			if (!string.IsNullOrEmpty(parentId))
			{
				return result;
			}

			return result + 1000;
		}
	}
}
