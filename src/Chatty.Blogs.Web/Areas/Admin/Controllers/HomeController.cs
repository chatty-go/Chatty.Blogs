using Chatty.Blogs.Services.Admin.Article;
using Chatty.Blogs.Services.Admin.Message;
using Chatty.Blogs.Services.Admin.Statistics;
using Chatty.Blogs.Web.Areas.Admin.Models.Article;
using Chatty.Blogs.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController (IMessageService messageService,IStatisticsService statisticsService, IArticleService articleService, 
        IStringLocalizer<HomeController> localizer) : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer = localizer;
        private readonly IArticleService _articleService = articleService;
        private readonly IStatisticsService _statisticsService = statisticsService;
        private readonly IMessageService _messageService = messageService;

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetDraftListAsync();
            var totalArticle = await _articleService.GetCountAsync();

            var model = new HomeIndexViewModel()
            {
                Articles = articles.Adapt<List<ArticleListItem>>(),
                TotalArticle = totalArticle,
                TotalUser = await _statisticsService.GetTotalUsersAsync(),
                TotalVisitor = await _statisticsService.GetTotalVisitsAsync(),
			};

            return View(model);
        }

		[HttpPost]
		public IActionResult SetLanguage(string culture, string returnUrl)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
			);

			return LocalRedirect(returnUrl);
		}

		public IActionResult NotFound404()
        {
            return View("NotFound");
        }

        public async Task<IActionResult> SetAllReadedAsync()
        {
            await _messageService.SetAllReadedAsync();

            return Redirect("/admin/home");
        }
    }
}
