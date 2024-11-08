using System.ComponentModel.DataAnnotations;

namespace Chatty.Blogs.Web.Areas.Admin.Models.Setting
{
    public class ContactRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required]
        public required string RowId { get; set; }

        /// <summary>
        /// 联系邮箱
        /// </summary>
        public  string? ContactEmail { get; set; }

        /// <summary>
        /// 联系手机
        /// </summary>
        public  string? ContactPhone { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public  string? ContactAddress { get; set; }
    }
}
