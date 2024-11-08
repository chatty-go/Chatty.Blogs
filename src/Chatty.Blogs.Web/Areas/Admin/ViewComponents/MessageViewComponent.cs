using Chatty.Blogs.Services.Admin.Message;
using Chatty.Blogs.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chatty.Blogs.Web.Areas.Admin.ViewComponents
{
    public class MessageViewComponent(IMessageService messageService) : ViewComponent
    {
        private readonly IMessageService _messageService = messageService;

        /// <summary>
        /// Find New Message
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _messageService.GetNewListAsync();

            var model = new HomeMessageViewModel()
            {
                Messages = list
            };

            return View(model);
        }
    }
}
