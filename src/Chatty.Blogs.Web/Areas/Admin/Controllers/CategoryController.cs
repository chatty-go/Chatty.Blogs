using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Admin.Article;
using Chatty.Blogs.Services.Admin.Article.Dtos;
using Chatty.Blogs.Services.Admin.Category;
using Chatty.Blogs.Web.Areas.Admin.Models.Category;
using Chatty.Blogs.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 文章分类
	/// TODO:后台分类增加路径字段，用于保存节点的层级关系
    /// </summary>
    /// <param name="service"></param>
    [Area("Admin")]
    [Authorize]
    public class CategoryController(ICategoryService service, IArticleService articleService) : Controller
	{
		private readonly ICategoryService _service = service;
		private readonly IArticleService _articleService = articleService;

		public async Task<IActionResult> Index(string type="Back")
		{
			var result = await _service.GetListByTypeAsync(type);

			var model = new CategoryIndexViewModel()
			{
				Trees = result.Adapt<List<CategoryTreeNode>>()
			};

			return View(model);
		}

		/// <summary>
		/// 创建分类 
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[ValidateAntiForgeryToken]
		public async Task<HttpResult> InsertAsync(NewCategoryRequest dto)
		{
			var entity = dto.Adapt<BlogCategory>();
			entity.RowId = Guid.NewGuid().ToString("N");

			await _service.InsertAsync(entity);

			return new HttpResult(ResultCode.SUCCESS, new { rowId = entity.RowId });

		}

		/// <summary>
		/// 修改分类 
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[ValidateAntiForgeryToken]
		public async Task<HttpResult> UpdateAsync(UpdateCategoryRequest dto)
		{
			var entity = dto.Adapt<BlogCategory>();

			await _service.UpdateAsync(entity);

			return new HttpResult(ResultCode.SUCCESS, new { rowId = entity.RowId });

		}

		/// <summary>
		/// 删除分类
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<HttpResult> DeleteAsync(string id)
		{
			await _service.DeleteAsync(id);

			return new HttpResult(ResultCode.SUCCESS);
		}

		public async Task<HttpResult> LoadArticleListAsync(int page,int limit,string categoryId)
		{
			var request = new PageByCategoryRequest() { 
				CategoryId = categoryId,
				Page  = page,
				Limit = limit
			};

			var result = await _articleService.GetPageListAsync(request);

			return new HttpResult(ResultCode.SUCCESS,new { 
				total = result.Item2,
				list = result.Item1
			});
		}

		public async Task<IActionResult> Front()
		{
			var type = "Front";
            var result = await _service.GetListByTypeAsync(type);

            var model = new CategoryFrontViewModel()
			{
				List = result.Adapt<List<CategoryTreeNode>>()
			};

            return View("Front", model);
		}

		[HttpGet]
		public async Task<HttpResult> GetByIdAsync(string id)
		{
			var result = await _service.GetByIdAsync(id);

			return new HttpResult(ResultCode.SUCCESS,result);
		}
	}
}
