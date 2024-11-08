using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Services.Admin.Setting
{
    /// <summary>
    /// 网站设置 - 服务
    /// </summary>
    public class SettingService(BaseRepository<SiteConfig> baseRepository) : ISettingService
    {
        private readonly BaseRepository<SiteConfig> _baseRepository = baseRepository;

        #region 查询

        /// <summary>
        /// 查询网站设置信息，本表中只有一条数据
        /// </summary>
        /// <returns></returns>
        public async Task<SiteConfig> GetSiteConfigAsync()
        {
            return await _baseRepository.GetFirstAsync(a=>1==1);
        }
        #endregion

        #region 更新作者信息

        public async Task<bool> UpdateAuthorAsync(SiteConfig entity)
        {
            return await _baseRepository.AsUpdateable().
               SetColumns(a => new SiteConfig(){
                   AuthorAvatar = entity.AuthorAvatar,
                   AuthorDesc = entity.AuthorDesc,
                   AuthorDisplayFlag = entity.AuthorDisplayFlag,
                   AuthorName = entity.AuthorName 
               })
               .Where(a => a.RowId == entity.RowId)
               .ExecuteCommandAsync()>0 ;
        }

        #endregion

        #region 更新版权信息

        public async Task<bool> UpdateCopyrightAsync(SiteConfig entity)
        {
            return await _baseRepository.AsUpdateable().
               SetColumns(a => new SiteConfig(){
                   CopyrightUrl = entity.CopyrightUrl,
                   CopyrightDesc = entity.CopyrightDesc
               })
               .Where(a=>a.RowId==entity.RowId)
               .ExecuteCommandAsync() > 0;
        }

        #endregion

        #region 更新社交媒体

        public async Task<bool> UpdateSocialAsync(SiteConfig entity)
        {
            return await _baseRepository.AsUpdateable().
               SetColumns(a => new SiteConfig()
               {
                   SocialFacebook = entity.SocialFacebook,
                   SocialGithub = entity.SocialGithub,
                   SocialInstagram = entity.SocialInstagram,
                   SocialTwitter = entity.SocialTwitter
               })
               .Where(a => a.RowId == entity.RowId)
               .ExecuteCommandAsync() > 0;
        }

		#endregion

		#region 更新联系我们

		public async Task<bool> UpdateContactAsync(SiteConfig entity)
		{
			return await _baseRepository.AsUpdateable().
			   SetColumns(a => new SiteConfig()
			   {
				   ContactAddress = entity.ContactAddress,
				   ContactEmail = entity.ContactEmail,
				   ContactPhone = entity.ContactPhone
               })
			   .Where(a => a.RowId == entity.RowId)
			   .ExecuteCommandAsync() > 0;
		}

        #endregion

        #region 更新SEO

        public async Task<bool> UpdateSeoAsync(SiteConfig entity)
        {
            return await _baseRepository.AsUpdateable().
               SetColumns(a => new SiteConfig()
               {
                   HomeTitle = entity.HomeTitle,
                   MetaDescription = entity.MetaDescription,
                   Keywords = entity.Keywords
               })
               .Where(a => a.RowId == entity.RowId)
               .ExecuteCommandAsync() > 0;
        }

        #endregion
    }
}
