using Chatty.Blogs.Core.Utils;
using Chatty.Blogs.Services.Admin.User;
using Chatty.Blogs.Services.Admin.User.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 用户接口
    /// </summary>
    /// <param name="userService"></param>
    [Area("Admin")]
    public class LoginController(IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService;

        /// <summary>
        /// 登录页视图
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.GetByUserName(request.username);

            if (user == null) {
                return new JsonResult(new { 
                    code=0,msg="账号或密码错误"
                });
            }

            var inputPwd = MD5Encrypt.CreateToLower(request.username+request.password);

            if(inputPwd != user.Password)
            {
                return new JsonResult(new
                {
                    code = 0,
                    msg = "账号或密码错误"
                });
            }

            if(user.Status!= "Active")
            {
                return new JsonResult(new
                {
                    code = 0,
                    msg = "账号状态异常，请联系管理员"
                });
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier,user.RowId),
                new (ClaimTypes.Name, user.UserName),
                new (ClaimTypes.Role, user.Role),
                new (ClaimTypes.Uri, user.Avatar)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties {

                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),authProperties);

            // 登录成功
            return new JsonResult(new { code = 1, msg = "成功", data = user });
        }

        /// <summary>
        /// 退出请求
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SignoutAsync()
        {

            // Clear the existing external cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return LocalRedirect("~/admin/login");
        }
    }
}
