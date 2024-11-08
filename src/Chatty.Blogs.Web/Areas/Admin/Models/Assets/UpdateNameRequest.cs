namespace Chatty.Blogs.Web.Areas.Admin.Models.Assets
{
    public class UpdateNameRequest
    {
        public required string RowId { get; set; }

        public required string Name { get; set; }
    }
}
