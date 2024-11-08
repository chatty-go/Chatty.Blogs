using Microsoft.AspNetCore.Mvc;

namespace Chatty.Blogs.Web.Controllers
{
	public class ErrorController : Controller
	{

		[Route("/error/404")]
		public IActionResult Error404()
		{
			Console.WriteLine("404");

			//跳转到404错误页
			if (Response.StatusCode == 404)
			{
				return View("/Views/Error/404.cshtml");
			}

			return View();
		}
	}
}
