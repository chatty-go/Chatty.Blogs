using Chatty.Blogs.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Services.Admin.Setting
{
    /// <summary>
    /// 设置 - 服务接口
    /// </summary>
    public interface ISettingService
    {
        Task<bool> UpdateSeoAsync(SiteConfig entity);

        Task<bool> UpdateContactAsync(SiteConfig entity);

		Task<SiteConfig> GetSiteConfigAsync();

        Task<bool> UpdateAuthorAsync(SiteConfig entity);

        Task<bool> UpdateCopyrightAsync(SiteConfig entity);

        Task<bool> UpdateSocialAsync(SiteConfig entity);
    }
}
