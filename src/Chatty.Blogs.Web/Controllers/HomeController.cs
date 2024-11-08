using Chatty.Blogs.Web.Models;
using Chatty.Blogs.Web.ViewModels;
using Chatty.Blogs.Services.Blogs.Article;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Chatty.Blogs.Services.Blogs.Category;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Caching.Memory;
using Chatty.Blogs.Services.Blogs.Setting;
using Chatty.Blogs.Core.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Chatty.Blogs.Web.Controllers
{
    public class HomeController(ISettingService settingService, IMemoryCache memoryCache, ICategoryService categoryService,
        IArticleService articleService, ILogger<HomeController> logger) : BaseController
	{
        private readonly IArticleService _articleService = articleService;
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly ISettingService _settingService = settingService;


        public async Task<IActionResult> Index()
        {
			var RecommendList = await _articleService.TakeTenListAsync("Recommand");
			var InspirationList = await _articleService.TakeTenListAsync("Inspiration");
			var TrendingList = await _articleService.TakeTenListAsync("Trending"); 
            var categories = await _categoryService.GetListAsync();
            var populars = await _articleService.GetPopularAsync();
            var recents = await _articleService.GetRecentAsync();

			var topArticle = await _articleService.GetTopAsync();

            var model = new HomeViewModel()
            {
                RecommendList = RecommendList.Adapt<List<ArticleListItemModel>>(),
                InspirationList = InspirationList.Adapt<List<ArticleListItemModel>>(),
                TrendingList = TrendingList.Adapt<List<ArticleListItemModel>>(),
                TopArticle = topArticle.Adapt<ArticleListItemModel>(),
                Categories = categories.Adapt<List<CategoryListItemModel>>(),
                PopularList = populars.Adapt<List<ArticleListItemModel>>(),
                RecentList = recents.Adapt<List<ArticleListItemModel>>()
			};

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
		public IActionResult SetLanguage(string culture,string redirect)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
			);

			return LocalRedirect(redirect);
		}

        public async Task<IActionResult> Block(string name,int page=1)
        {
            int Limit = 30;

            var request = new BlogPageRequest()
            {
                Page = page,
                Limit = Limit,
                Block = name
            };

            var result = await _articleService.GetBlockArticleListAsync(request);

            var model = new HomeBlockViewModel()
            {
                Total = result.Item2,
                Articles = result.Item1.Adapt<List<ArticleListItemModel>>(),
                Pages = (int)Math.Ceiling((double)result.Item2 / Limit),
                Page = page,
                Finished = request.Limit * request.Page >= result.Item2,
                Block = request.Block
            };

            return View("Block", model);
        }
	}
}
