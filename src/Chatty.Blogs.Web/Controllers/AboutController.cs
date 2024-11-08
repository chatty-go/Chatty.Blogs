using Chatty.Blogs.Services.Blogs.Article;
using Chatty.Blogs.Services.Blogs.Category;
using Chatty.Blogs.Web.Models;
using Chatty.Blogs.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chatty.Blogs.Web.Controllers
{
	public class AboutController(IArticleService articleService, ICategoryService categoryService) : BaseController
	{
		private readonly IArticleService _articleService = articleService;
        private readonly ICategoryService _categoryService = categoryService;

        public async Task<IActionResult> Index()
		{
            var populars = await _articleService.GetPopularAsync();
            var categories = await _categoryService.GetListAsync();

            var model = new AboutIndexViewModel()
			{
                PopularArticles = populars.Adapt<List<ArticleListItemModel>>(),
                Categories = categories.Adapt<List<CategoryListItemModel>>(),
            };

            return View(model);
		}
	}
}
