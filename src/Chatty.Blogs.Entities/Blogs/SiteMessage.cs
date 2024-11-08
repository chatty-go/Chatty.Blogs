
namespace Chatty.Blogs.Entities.Blogs
{
    [SugarTable("site_message")]
    public class SiteMessage: BaseEntity
    {

        [SugarColumn(ColumnName = "title")]
        public string Title { get; set; } = null!;


        [SugarColumn(ColumnName = "content")]
        public string Content { get; set; } = null!;


        [SugarColumn(ColumnName = "type")]
        public string Type { get; set; } = null!;


        [SugarColumn(ColumnName = "is_readed")]
        public int IsReaded { get; set; } = 0;

        [SugarColumn(ColumnName = "more_url")]
        public string MoreUrl { get; set; } = null!;

    }
}
