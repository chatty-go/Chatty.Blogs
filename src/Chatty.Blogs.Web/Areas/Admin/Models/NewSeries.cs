namespace Chatty.Blogs.Web.Areas.Admin.Models
{
    public class NewSeries
    {
        /// <summary>
        /// ID
        /// </summary>
        public string? RowId { get; set; }

        /// <summary>
        /// 专栏名称
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// 专栏简介
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int TaxisNo { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        public required string CoverImage { get; set; }

        /// <summary>
        /// 是否公开
        /// </summary>
        public int IsPublic { get; set; }
    }
}
