using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Services.Admin.Series
{
	/// <summary>
	/// 专栏 - 服务层
	/// TODO：专栏一键生成静态站点
	/// </summary>
	public class SeriesService(BaseRepository<BlogSeries> baseRepository) : ISeriesService
	{
		private readonly BaseRepository<BlogSeries> _baseRepository = baseRepository;

		public async Task<Tuple<List<BlogSeries>, int>> GetPageListAsync(PageRequest request)
		{
            RefAsync<int> total = 0;

			var list = await _baseRepository.AsQueryable()
                .Where(a => a.DeleteFlag == "N")
                .WhereIF(!string.IsNullOrEmpty(request.Search), a => a.Title.Contains(request.Search) || a.Description.Contains(request.Search))
                .OrderByIF(request.Sort == "created", a => a.CreatedDate, OrderByType.Desc)
                .OrderByIF(request.Sort == "updated", a => a.LastUpdDate, OrderByType.Desc)
                .ToPageListAsync(request.Page, request.Limit, total);

            return new Tuple<List<BlogSeries>, int>(list, total.Value);
		}

		public async Task<BlogSeries> GetByIdAsync(string id)
		{
			return await _baseRepository.GetByIdAsync(id);
		}

		public async Task<bool> AddAsync(BlogSeries model)
		{
			return await _baseRepository.InsertAsync(model);
		}

		public async Task<bool> UpdateAsync(BlogSeries model)
		{
			return await _baseRepository.UpdateAsync(model);
		}

		public async Task<bool> DeleteAsync(string id)
		{
			return await _baseRepository.DeleteByIdAsync(id);
		}

		public async Task<List<BlogSeries>> GetListAsync()
		{
			return await _baseRepository.AsQueryable()
				.Where(a => a.DeleteFlag == "N")
				.OrderBy(a=>a.TaxisNo, OrderByType.Asc).ToListAsync();
		}

	}
}
