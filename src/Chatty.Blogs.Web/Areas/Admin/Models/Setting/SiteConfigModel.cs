
using SqlSugar;

namespace Chatty.Blogs.Web.Areas.Admin.Models.Setting
{
    public class SiteConfigModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public string RowId { get; set; } = null!;

        /// <summary>
        /// 版权描述
        /// </summary>
        public string CopyrightDesc { get; set; } = null!;

        /// <summary>
        /// 版权链接
        /// </summary>
        public string CopyrightUrl { get; set; } = null!;

        /// <summary>
        /// 作者姓名
        /// </summary>
        public string AuthorName { get; set; } = null!;

        /// <summary>
        /// 作者简介
        /// </summary>
        public string AuthorDesc { get; set; } = null!;

        /// <summary>
        /// 作者头像
        /// </summary>
        public string AuthorAvatar { get; set; } = null!;

        /// <summary>
        /// 展示作者
        /// </summary>
        public int AuthorDisplayFlag { get; set; }

        /// <summary>
        /// Twitter
        /// </summary>
        public string SocialTwitter { get; set; } = null!;

        /// <summary>
        /// Instagram
        /// </summary>
        public string SocialInstagram { get; set; } = null!;

        /// <summary>
        /// Facebook
        /// </summary>
        public string SocialFacebook { get; set; } = null!;

        /// <summary>
        /// Github
        /// </summary>
        public string SocialGithub { get; set; } = null!;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhone { get; set; } = null!;

		/// <summary>
		/// 联系邮箱
		/// </summary>
		public string ContactEmail { get; set; } = null!;

		/// <summary>
		/// 联系地址
		/// </summary>
		public string ContactAddress { get; set; } = null!;


        /****SEO****/

        public string? HomeTitle { get; set; }

        public string? MetaDescription { get; set; }

        public string? Keywords { get; set; }

    }
}
