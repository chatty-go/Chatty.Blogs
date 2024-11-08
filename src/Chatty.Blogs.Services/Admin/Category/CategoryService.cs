using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Services.Admin.Category
{
	/// <summary>
	/// 文章分类 服务
	/// </summary>
	public class CategoryService(BaseRepository<BlogCategory> baseRepository) : ICategoryService
	{
		private readonly BaseRepository<BlogCategory> _baseRepository = baseRepository;

		public async Task<List<BlogCategory>> GetListByTypeAsync(string type)
		{
			return await _baseRepository.AsQueryable()
				.Where(x => x.Type == type)
				.OrderBy(x=>x.TaxisNo,OrderByType.Asc)
				.ToListAsync();
		}

		public async Task<List<BlogCategory>> GetListAsync()
		{
			return await _baseRepository.AsQueryable()
				.OrderBy(x => x.TaxisNo, OrderByType.Asc)
				.ToListAsync();
		}

		#region 创建
		public async Task<bool> InsertAsync(BlogCategory model)
		{
			return await _baseRepository.InsertAsync(model);
		}
		#endregion

		#region 修改	

		public async Task<bool> UpdateAsync(BlogCategory model)
		{
			return await _baseRepository.UpdateAsync(model);
		}

		#endregion

		#region 删除		

		public async Task<bool> DeleteAsync(string id)
		{
			return await _baseRepository.DeleteByIdAsync(id);
		}
		#endregion

		public async Task<BlogCategory> GetByIdAsync(string id)
		{
			return await _baseRepository.GetByIdAsync(id);
		}
	}
}
