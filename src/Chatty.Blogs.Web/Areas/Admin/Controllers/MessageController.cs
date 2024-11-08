using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Services.Admin.Message;
using Chatty.Blogs.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MessageController(IMessageService service) : Controller
    {
        private readonly IMessageService _service = service;
        private const int Limit = 20;

        public async Task<IActionResult> Index(int page=1)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit,
                Search= "system"
            };

            var result= await _service.GetPageListAsync(pageRequest);

            var model = new MessageIndexViewModel()
            {
                List = result.Item1,
                TotalMessage = result.Item2,
                Finished = pageRequest.Page * pageRequest.Limit >= result.Item2
            };

            return View(model);
        }

        public async Task<HttpResult> Loadmore(int page,[Required]string msgType)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit,
                Search = msgType
            };

            var result = await _service.GetPageListAsync(pageRequest);

            return new HttpResult(ResultCode.SUCCESS,new {
                TotalCount = result.Item2,
                List = result.Item1,
                Pgae = page,
                Limit,
                Finished = pageRequest.Page * pageRequest.Limit >= result.Item2
            });
        }

        public async Task<IActionResult> UserMessage(int page=1)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit,
                Search = "user"
            };

            var result = await _service.GetPageListAsync(pageRequest);

            var model = new MessageIndexViewModel()
            {
                List = result.Item1,
                TotalMessage = result.Item2,
                Finished = pageRequest.Page * pageRequest.Limit >= result.Item2
            };

            return View("UserMessage", model);
        }
    }
}
