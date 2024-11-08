
namespace Chatty.Blogs.Web.Models
{
    public class SiteConfigModel
    {
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
    }
}
