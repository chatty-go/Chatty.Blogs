using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Admin.Article;
using Chatty.Blogs.Services.Admin.Series;
using Chatty.Blogs.Web.Areas.Admin.Models;
using Chatty.Blogs.Web.Areas.Admin.Models.Series;
using Chatty.Blogs.Web.Areas.Admin.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 专栏
    /// </summary>
	[Area("Admin")]
    [Authorize]
    public class SeriesController(ISeriesService service, ISeriesOutlineService outlineService
        , IArticleService articleService) : Controller
    {
        private readonly ISeriesService _service = service;
        private readonly ISeriesOutlineService _outlineService = outlineService;
        private readonly IArticleService _articleService = articleService;
        private readonly int Limit = 10;

        public async Task<IActionResult> Index(string? sort, string? search, int page = 1)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit,
                Sort = sort ?? "created",
                Search = search
            };

            var result = await _service.GetPageListAsync(pageRequest);

            var model = new SeriesIndexViewModel()
            {
                List = result.Item1,
                TotalCount = result.Item2,
                Page = pageRequest.Page,
                Sort = pageRequest.Sort,
                Limit  = pageRequest.Limit,
                Search = pageRequest.Search,
                Finished = pageRequest.Page * pageRequest.Limit >= result.Item2
            };

            return View(model);
        }

        public async Task<HttpResult> Loadmore(string? sort, string? search, int page = 1)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit,
                Sort = sort ?? "created",
                Search = search
            };

            var result = await _service.GetPageListAsync(pageRequest);

            return new HttpResult(ResultCode.SUCCESS,new { 
                list= result.Item1,
                total = result.Item2,
                page,
                limit= Limit,
                finished = page * pageRequest.Limit>=result.Item2
            });
        }

        public IActionResult New()
        {
            return View("New");
        }

        public async Task<HttpResult> DeleteByIdAsync(string id)
        {
            Console.WriteLine("id:"+id);

            var result = await _service.DeleteAsync(id);

            return new HttpResult(ResultCode.SUCCESS);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var entity = await _service.GetByIdAsync(id);

            var model = new SeriesNewViewModel()
            {
                Series = entity.Adapt<SeriesModel>()
            };

            return View("Edit", model);
        }

        public async Task<IActionResult> Save(NewSeries dto)
        {
            var entity = dto.Adapt<BlogSeries>();

            if (!string.IsNullOrEmpty(dto.RowId))
            {
               await _service.UpdateAsync(entity);
            }
            else
            {
                entity.RowId = Guid.NewGuid().ToString("N");
                await _service.AddAsync(entity);
            }

            return RedirectToAction("Detail", new { id = entity.RowId });
        }

        public IActionResult Generate()
        {
            return View("Generate");
        }

        public async Task<IActionResult> Detail([FromRoute]string id)
        {
            var entity = await _service.GetByIdAsync(id);

            var outlines = await _outlineService.GetListAsync(id);

            var articles = await _articleService.GetSeriesListAsync(id);

			var model = new SeriesDetailViewModel()
            {
                Series = entity,
                Outlines = outlines,
                Articles = articles.Adapt<List<SeriesArticleItemModel>>()
            };

            return View("Detail",model);
        }

        public async Task<HttpResult> NewOutlineAsync(NewOutlineRequest dto)
        {
            var entity = dto.Adapt<BlogSeriesOutline>();
            entity.RowId = Guid.NewGuid().ToString("N");

            await _outlineService.AddAsync(entity);

            return new HttpResult(ResultCode.SUCCESS,new { entity.RowId });

        }

        public async Task<HttpResult> UpdateOutlineAsync(UpdateOutlineRequest dto)
        {
            var entity = dto.Adapt<BlogSeriesOutline>();

            await _outlineService.UpdateAsync(entity);

            return new HttpResult(ResultCode.SUCCESS);
        }

		public async Task<HttpResult> DeleteOutlineAsync(string outlineId)
		{
			await _outlineService.DeleteByIdAsync(outlineId);

			return new HttpResult(ResultCode.SUCCESS);

		}

		public async Task<HttpResult> GetMaxTaxisNoAsync(string seriesId,string? parentId)
		{
			var result = await _outlineService.GetMaxTaxisNoAsync(seriesId, parentId);

			return new HttpResult(ResultCode.SUCCESS,result);

		}
	}
}
