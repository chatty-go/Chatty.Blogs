
namespace Chatty.Blogs.Entities.Blogs
{
    /// <summary>
    /// 站点配置
    /// </summary>
    [SugarTable("site_config")]
    public class SiteConfig: BaseEntity
    {
        /// <summary>
        /// 版权描述
        /// </summary>
		[SugarColumn(ColumnName = "copyright_desc")]
        public string CopyrightDesc { get; set; } = null!;

        /// <summary>
        /// 版权链接
        /// </summary>
		[SugarColumn(ColumnName = "copyright_url")]
        public string CopyrightUrl { get; set; } = null!;

        /// <summary>
        /// 作者姓名
        /// </summary>
		[SugarColumn(ColumnName = "author_name")]
        public string AuthorName { get; set; } = null!;

        /// <summary>
        /// 作者简介
        /// </summary>
		[SugarColumn(ColumnName = "author_desc")]
        public string AuthorDesc { get; set; } = null!;

        /// <summary>
        /// 作者头像
        /// </summary>
		[SugarColumn(ColumnName = "author_avatar")]
        public string AuthorAvatar { get; set; } = null!;

        /// <summary>
        /// 展示作者
        /// </summary>
		[SugarColumn(ColumnName = "author_display_flag")]
        public int AuthorDisplayFlag { get; set; }

        /// <summary>
        /// Twitter
        /// </summary>
        [SugarColumn(ColumnName = "social_twitter")]
        public string SocialTwitter { get; set; }= null!;

        /// <summary>
        /// Instagram
        /// </summary>
		[SugarColumn(ColumnName = "social_instagram")]
        public string SocialInstagram { get; set; }= null!;

        /// <summary>
        /// Facebook
        /// </summary>
        [SugarColumn(ColumnName = "social_facebook")]
        public string SocialFacebook { get; set; }= null!;

        /// <summary>
        /// Github
        /// </summary>
        [SugarColumn(ColumnName = "social_github")]
        public string SocialGithub { get; set; }= null!;

		/// <summary>
		/// 联系电话
		/// </summary>
		[SugarColumn(ColumnName = "contact_phone")]
		public string ContactPhone { get; set; } = null!;

		/// <summary>
		/// 联系邮箱
		/// </summary>
		[SugarColumn(ColumnName = "contact_email")]
		public string ContactEmail { get; set; } = null!;


		/// <summary>
		/// 联系地址
		/// </summary>
		[SugarColumn(ColumnName = "contact_address")]
		public string ContactAddress { get; set; } = null!;


        [SugarColumn(ColumnName = "home_title")]
        public string? HomeTitle { get; set; }


        [SugarColumn(ColumnName = "meta_description")]
        public string? MetaDescription { get; set; }


        [SugarColumn(ColumnName = "keywords")]
        public string? Keywords { get; set; }

    }
}
