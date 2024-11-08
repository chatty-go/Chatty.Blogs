using Chatty.Blogs.Services.Blogs.Setting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chatty.Blogs.Web.Controllers
{
	public class BaseController : Controller
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			var baseRepository = HttpContext.RequestServices.GetService(typeof(ISettingService)) as ISettingService;
			var siteConfig = baseRepository.GetSettingAsync().Result;

			ViewBag.SiteConfig = siteConfig;
		}
	}
}
