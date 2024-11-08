using System.ComponentModel.DataAnnotations;

namespace Chatty.Blogs.Web.Areas.Admin.Models.Setting
{
    public class AuthorRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        public required string RowId { get; set; }

        /// <summary>
        /// 作者头像
        /// </summary>
        public string? AuthorAvatar { get; set; }

        /// <summary>
        /// 作者姓名
        /// </summary>
        public string? AuthorName { get; set; }

        /// <summary>
        /// 作者简介
        /// </summary>
        public string? AuthorDesc { get; set; }

        /// <summary>
        /// 展示作者
        /// </summary>
        public string? AuthorDisplayFlag { get; set; }
    }
}
