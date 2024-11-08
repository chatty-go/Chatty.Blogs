namespace Chatty.Blogs.Web.Areas.Admin.Models
{
    public class SharePostInfo
    {
        public string row_id { get; set; } = null!;
        public string title { get; set; } = null!;
        public DateTime created_date { get; set; } 

        public DateTime? last_upd_date { get; set; }
        public string content { get; set; } = null!;

        public string parent_id { get; set; } = null!;

        public string parent_path { get; set; } = null!;

        /// <summary>
        /// 访问密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 分享ID
        /// </summary>
        public string share_id { get; set; }

        /// <summary>
        /// 分享链接
        /// </summary>
        public string share_url { get; set; }
    }
}
