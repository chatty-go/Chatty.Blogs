
namespace Chatty.Blogs.Web.Areas.Admin.Models.Setting
{
    public class SocialRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public required string RowId { get; set; }

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
    }
}
