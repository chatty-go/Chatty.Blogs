using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.Series
{
	/// <summary>
	/// 专栏 - 服务层接口
	/// </summary>
	public interface ISeriesService
	{
        Task<Tuple<List<BlogSeries>, int>> GetPageListAsync(PageRequest request);

		Task<BlogSeries> GetByIdAsync(string id);

		Task<bool> AddAsync(BlogSeries model);

		Task<bool> UpdateAsync(BlogSeries model);

		Task<bool> DeleteAsync(string id);

		Task<List<BlogSeries>> GetListAsync();

	}
}
