using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Chatty.Blogs.Core.Http;

namespace Chatty.Blogs.Web.Filters
{
    /// <summary>
    /// 自定义模型验证过滤器
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(new
                {
                    Code = ResultCode.PARAM_IS_INVALID,
                    Errors = errors,
                    Msg = "参数验证失败",
                    Details = string.Join(";", errors),
                });
            }
        }
    }
}
