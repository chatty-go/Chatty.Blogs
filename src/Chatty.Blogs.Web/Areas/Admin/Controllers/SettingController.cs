using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Core.Utils;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Admin.Setting;
using Chatty.Blogs.Services.Admin.User;
using Chatty.Blogs.Web.Areas.Admin.Models.Setting;
using Chatty.Blogs.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Chatty.Blogs.Web.Areas.Admin.Models.User;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 网站设置
    /// </summary>
    [Area("Admin")]
    [Authorize]
    public class SettingController(ISettingService service, IUserService userService) : Controller
    {
        private readonly ISettingService _service = service;
        private readonly IUserService _userService = userService;

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetSiteConfigAsync();

            BlogUser user = new();

            if (User.Identity !=null && !string.IsNullOrEmpty(User.Identity.Name))
            {
                user = await _userService.GetByUserName(User.Identity.Name);
            }

            var model = new SettingIndexViewModel()
            {
                SiteConfig = result.Adapt<SiteConfigModel>(),
                User = user.Adapt<UserProfileModel>()
            };

            return View(model);
        }

        #region 更新SEO

        [ValidateAntiForgeryToken]
        public async Task<HttpResult> UpdateSeoAsync(SeoRequest dto)
        {
            var entity = dto.Adapt<SiteConfig>();
            var result = await _service.UpdateSeoAsync(entity);

            return new HttpResult(ResultCode.SUCCESS);
        }

        #endregion

        #region 更新联系我们

        [ValidateAntiForgeryToken]
		public async Task<HttpResult> UpdateContactAsync(ContactRequest dto)
		{
			var entity = dto.Adapt<SiteConfig>();
			var result = await _service.UpdateContactAsync(entity);

			return new HttpResult(ResultCode.SUCCESS);
		}

		#endregion

		#region 更新社交媒体

		[ValidateAntiForgeryToken]
        public async Task<HttpResult> UpdateSocialAsync(SocialRequest dto)
        {
            var entity = dto.Adapt<SiteConfig>();
            var result = await _service.UpdateSocialAsync(entity);

            return new HttpResult(ResultCode.SUCCESS);
        }

        #endregion

        #region 更新版权信息

        [ValidateAntiForgeryToken]
        public async Task<HttpResult> UpdateCopyright(CopyrightRequst dto)
        {
            var entity = dto.Adapt<SiteConfig>();
            var result = await _service.UpdateCopyrightAsync(entity);

            return new HttpResult(ResultCode.SUCCESS);
        }

        #endregion

        #region 更新作者信息

        [ValidateAntiForgeryToken]
        public async Task<HttpResult> UpdateAuthor(AuthorRequest dto)
        {
            var entity = dto.Adapt<SiteConfig>();
            var result = await _service.UpdateAuthorAsync(entity);

            return new HttpResult(ResultCode.SUCCESS);
        }

        #endregion

        #region 修改密码

        [ValidateAntiForgeryToken]
        public async Task<HttpResult> ChangePassword(ChangePasswordRequest dto)
        {
            var entity = await _userService.GetByUserName(dto.UserName);

            var password = MD5Encrypt.CreateToLower(dto.UserName + dto.Password);

            if (entity.Password != password)
            {
                return new HttpResult(ResultCode.ERROR,"账号或密码错误");
            }

            entity.Password = MD5Encrypt.CreateToLower(dto.UserName + dto.NewPassword);

            var result = await _userService.ChangePassword(entity);

            // Clear the existing external cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return new HttpResult(ResultCode.SUCCESS,result);
        }
        #endregion

        #region 修改账号基本信息

        [ValidateAntiForgeryToken]
        public async Task<HttpResult> ChangeProfile(ChangeProfileRequest dto)
        {
            var entity = dto.Adapt<BlogUser>();

            var result = await _userService.ChangeProfile(entity);

            return new HttpResult(ResultCode.SUCCESS, result);
        }

        #endregion
    }
}
