using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.Series
{
	public interface ISeriesOutlineService
	{
		Task<List<BlogSeriesOutline>> GetListAsync(string seriesId);

		Task<bool> AddAsync(BlogSeriesOutline entity);

		Task<bool> UpdateAsync(BlogSeriesOutline entity);

		Task<bool> DeleteByIdAsync(string id);

		Task<int> GetMaxTaxisNoAsync(string seriesId,string? parentId);
	}
}
