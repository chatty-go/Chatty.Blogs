namespace Chatty.Blogs.Web.Models
{
    public class SendMessageRequest
    {
        /// <summary>
        /// Name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public required string Content { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public required string Subject { get; set; }
    }
}
