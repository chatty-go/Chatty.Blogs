using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.Category
{
	/// <summary>
	/// 文章分类 服务接口
	/// </summary>
	public interface ICategoryService
	{
		Task<List<BlogCategory>> GetListAsync();

		/// <summary>
		/// 获取分类列表
		/// </summary>
		/// <returns></returns>
		Task<List<BlogCategory>> GetListByTypeAsync(string type);

		/// <summary>
		/// 创建分类
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<bool> InsertAsync(BlogCategory model);

		/// <summary>
		/// 修改分类
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<bool> UpdateAsync(BlogCategory model);

		/// <summary>
		/// 删除分类
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> DeleteAsync(string id);

		/// <summary>
		/// Get By ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<BlogCategory> GetByIdAsync(string id);
	}
}
