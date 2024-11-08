using Chatty.Blogs.Web.Models;
using Chatty.Blogs.Web.ViewModels;
using Chatty.Blogs.Services.Blogs.Article;
using Chatty.Blogs.Services.Blogs.Setting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Blogs.Category;
using Mapster;

namespace Chatty.Blogs.Web.Controllers
{
	public class BlogController(IArticleService articleService, IArticleCommentService articleCommentService, 
		IMemoryCache memoryCache, ISettingService settingService, ICategoryService categoryService) : BaseController
	{
		private readonly IArticleService _articleService = articleService;
		private readonly IMemoryCache _memoryCache = memoryCache;
		private readonly ISettingService _settingService = settingService;
		private readonly IArticleCommentService _articleCommentService = articleCommentService;
		private readonly ICategoryService _categoryService = categoryService;
        private readonly int Limit = 10;

		public async Task<IActionResult> Index(int page=1, string? cateid = null)
		{
			var siteConfig = await _settingService.GetSettingAsync();
			ViewData["MetaDescription"] = siteConfig?.MetaDescription;
			ViewData["Keywords"] = siteConfig?.Keywords;

			var request = new BlogPageRequest()
			{
				Page = page,
				Limit = Limit,
				FrontCategoryId = cateid
            };

            var result = await _articleService.GetPageListAsync(request);
			var categories = await _categoryService.GetGroupListAsync();
			var tagClound = await _articleService.GetTagCloudListAsync();

			var model = new BlogIndexViewModel()
			{
				Total = result.Item2,
				Articles = result.Item1.Adapt<List<ArticleListItemModel>>(),
				Pages = (int)Math.Ceiling((double)result.Item2 / Limit),
				Categories = categories,
				Page = page,
				Filter = categories.Find(c => c.RowId == cateid),
                TagCloudList = tagClound
            };

            return View(model);
		}

		public async Task<IActionResult> Detail(string id)
		{
            var siteConfig = await _settingService.GetSettingAsync();
			var articleEntity = await _articleService.GetAsync(id);

			if(articleEntity == null)
			{
				return View("404");
			}

			var comments = await _articleCommentService.TakeTenAsync(id);
			var populars = await _articleService.GetPopularAsync();

			var article = articleEntity.Adapt<ArticleDetailModel>();
            article.TagList = articleEntity.Tags?.Split(",").ToList() ?? [];
			article.OutlineList = JsonSerializer.Deserialize<List<OutlineModel>>(articleEntity.Outline ?? "[]") ?? [];

            return View("Detail",new ArticleDetailViewModel { 
				Article = article,
				SiteConfig = siteConfig.Adapt<SiteConfigModel>(),
				Comments = comments.Adapt<List<ArticleCommentModel>>(),
				PopularArticles = populars.Adapt<List<ArticleListItemModel>>()
			});
		}

		public IActionResult DetailAlt(int id)
		{
			return View("Detail-alt");
		}

		public IActionResult Category(int id)
		{
			return View("Category");
		}

        [ValidateAntiForgeryToken]
        public async Task<HttpResult> CommentAsync(NewCommentRequest request)
		{
			var entity = request.Adapt<BlogArticleComment>();
			entity.RowId = Guid.NewGuid().ToString("N");

			var result = await _articleCommentService.InsertAsync(entity);

			return new HttpResult(ResultCode.SUCCESS,new { entity.RowId });

		}

        public async Task<IActionResult> Tags(string? tag,int page=1)
        {
            var request = new BlogPageRequest()
            {
                Page = page,
                Limit = Limit,
                Tags = tag
            };

            var result = await _articleService.GetTagArticleListAsync(request);

			var model = new BlogTagsViewModel()
			{
                Total = result.Item2,
                Articles = result.Item1.Adapt<List<ArticleListItemModel>>(),
                Pages = (int)Math.Ceiling((double)result.Item2 / Limit),
                Page = page,
				Finished =  request.Limit * request.Page >= result.Item2,
				Tag = tag
            };

            return View("Tags", model);
        }

    }
}
