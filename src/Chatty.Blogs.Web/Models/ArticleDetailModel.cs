
namespace Chatty.Blogs.Web.Models
{
    public class ArticleDetailModel
    {
        public string RowId { get; set; } = null!;

        /// <summary>
		/// 标题
		/// </summary>
		public string Title { get; set; } = null!;

        /// <summary>
        /// 正文
        /// </summary>
        public string Content { get; set; } = null!;

        /// <summary>
        /// 是否公开
        /// </summary>
        public int IsPublic { get; set; }

        /// <summary>
        /// 文章路径
        /// </summary>
        public string ParentPath { get; set; } = null!;

        /// <summary>
		/// 标签列表
		/// </summary>
		public List<string> TagList { get; set; } = new List<string>();

        /// <summary>
		/// 文章大纲
		/// </summary>
		public List<OutlineModel> OutlineList { get; set; } = new List<OutlineModel>();

        /// <summary>
        /// 摘要
        /// </summary>

        public string Quote { get; set; } = null!;

        /// <summary>
        /// 是否置顶
        /// </summary>
        public int IsTop { get; set; } = 0;

        /// <summary>
        /// 首页版块
        /// </summary>
        public string HomeBlock { get; set; } = "Default";

        /// <summary>
        /// 文章状态 0:草稿 1:发布 
        /// </summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// 分类ID
        /// </summary>
        public string? CategoryId { get; set; }

        /// <summary>
        /// 封面
        /// </summary>
        public string CoverUrl { get; set; } = null!;

        /// <summary>
        /// 专栏ID
        /// </summary>
        public string SeriesId { get; set; } = null!;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
