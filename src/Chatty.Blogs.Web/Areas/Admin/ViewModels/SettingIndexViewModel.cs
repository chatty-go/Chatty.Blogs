using Chatty.Blogs.Web.Areas.Admin.Models.Setting;
using Chatty.Blogs.Web.Areas.Admin.Models.User;

namespace Chatty.Blogs.Web.Areas.Admin.ViewModels
{
    /// <summary>
    /// 设置
    /// </summary>
    public class SettingIndexViewModel
    {
        public SiteConfigModel SiteConfig { get; set; } = null!;

        public UserProfileModel User { get; set; } = null!;
    }
}
