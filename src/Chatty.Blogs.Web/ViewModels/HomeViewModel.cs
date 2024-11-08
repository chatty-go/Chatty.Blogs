using Chatty.Blogs.Web.Models;

namespace Chatty.Blogs.Web.ViewModels
{
    public class HomeViewModel
    {
		/// <summary>
		/// 编辑推荐-文章列表
		/// </summary>
		public List<ArticleListItemModel> RecommendList { get; set; } = [];

		/// <summary>
		/// 灵感-文章列表
		/// </summary>
		public List<ArticleListItemModel> InspirationList { get; set; } = [];

		/// <summary>
		/// 趋势-文章列表
		/// </summary>
		public List<ArticleListItemModel> TrendingList { get; set; } = [];

		/// <summary>
		/// 头条文章
		/// </summary>
		public ArticleListItemModel? TopArticle { get; set; }

		/// <summary>
		/// Categories
		/// </summary>
		public List<CategoryListItemModel> Categories { get; set; } = [];

		/// <summary>
		/// Popular Posts
		/// </summary>
		public List<ArticleListItemModel> PopularList { get; set; } = [];

		/// <summary>
		/// Recent Posts
		/// </summary>
		public List<ArticleListItemModel> RecentList { get; set; } = [];
	}
}
