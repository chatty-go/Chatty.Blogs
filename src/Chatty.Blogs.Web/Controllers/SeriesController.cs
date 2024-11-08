using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Services.Blogs.Article;
using Chatty.Blogs.Services.Blogs.Series;
using Chatty.Blogs.Web.Models;
using Chatty.Blogs.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Chatty.Blogs.Web.Controllers
{
	public class SeriesController(ISeriesService service, 
        ISeriesOutlineService seriesOutlineService, IArticleService articleService) : BaseController
	{
        private readonly ISeriesService _service = service;
        private readonly ISeriesOutlineService _seriesOutlineService = seriesOutlineService;
        private readonly IArticleService _articleService = articleService;
        private readonly int Limit = 10;

        public async Task<IActionResult> Index(int page=1)
		{
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit
            };

            var result = await _service.GetPageListAsync(pageRequest);

            var model = new SeriesIndexViewModel()
            {
                Total = result.Item2,
                List = result.Item1.Adapt<List<SeriesItemModel>>(),
                Pages = (int)Math.Ceiling((double)result.Item2 / Limit),
                Page = page
            };

            return View(model);
		}

        public async Task<IActionResult> Detail(string id,string oid="0",string articleid="0")
        {
            var entity = await _service.GetByIdAsync(id);
            var outlines = await _seriesOutlineService.GetTreeList(id);
            var articleEntity = await _articleService.GetAsync(articleid);

            var article = articleEntity.Adapt<ArticleDetailModel>();
            if (articleEntity != null)
            {
                article.TagList = articleEntity.Tags?.Split(",").ToList() ?? [];
                article.OutlineList = JsonSerializer.Deserialize<List<OutlineModel>>(articleEntity.Outline ?? "[]") ?? [];
            }

            var model = new SeriesDetailViewModel()
            {
                SeriesId = id,
                Series = entity.Adapt<SeriesItemModel>(),
                Outlines = outlines,
                Article = article,
                CurrentOutlineId = oid
			};

            return View("Detail", model);
        }

    }
}
