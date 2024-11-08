using Microsoft.AspNetCore.Mvc;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
