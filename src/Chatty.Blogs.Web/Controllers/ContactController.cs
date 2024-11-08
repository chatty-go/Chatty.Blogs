using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Blogs.Contact;
using Chatty.Blogs.Web.Models;
using Chatty.Blogs.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chatty.Blogs.Web.Controllers
{
	public class ContactController (IContactService service) : BaseController
	{
		private readonly IContactService _service = service;

        public async Task<IActionResult> Index()
		{
			var entity = await _service.GetAsync();

			var model = new ContactIndexViewModel()
			{
				Contact = entity.Adapt<ContactModel>()
			};


            return View(model);
		}

		[ValidateAntiForgeryToken]
		public async Task<HttpResult> SendMessage(SendMessageRequest request)
		{
			var entity = new SiteMessage()
			{
				Type="user",
				Content = $"{request.Content} 联系邮箱：{request.Email}",
				Title = $"{request.Name}:{request.Subject}",
				IsReaded=0
			};

			await _service.AddAsync(entity);

			return new HttpResult(ResultCode.SUCCESS);
		}
	}
}
