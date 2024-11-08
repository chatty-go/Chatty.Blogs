using System.ComponentModel.DataAnnotations;

namespace Chatty.Blogs.Web.Areas.Admin.Models.Setting
{
    public class CopyrightRequst
    {
        [Required]
        public required string RowId { get; set; }

        public  string? CopyrightDesc { get; set; }

        public  string? CopyrightUrl { get; set; }
    }
}
