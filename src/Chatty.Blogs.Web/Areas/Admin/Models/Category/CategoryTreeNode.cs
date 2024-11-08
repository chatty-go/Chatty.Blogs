namespace Chatty.Blogs.Web.Areas.Admin.Models.Category
{
    public class CategoryTreeNode
    {
        public string RowId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string ParentId { get; set; } = null!;

        public int TaxisNo { get; set; }

        public int IsPublic { get; set; }

        public string? Path { get; set; }

    }
}
