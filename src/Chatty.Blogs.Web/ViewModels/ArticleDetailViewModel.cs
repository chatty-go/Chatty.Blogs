using Chatty.Blogs.Web.Models;

namespace Chatty.Blogs.Web.ViewModels
{
	public class ArticleDetailViewModel
	{
		/// <summary>
		/// 文章内容
		/// </summary>
		public ArticleDetailModel Article { get; set; } = null!;

		/// <summary>
		/// 站点配置
		/// </summary>
		public SiteConfigModel? SiteConfig { get; set; } = null!;

		/// <summary>
		/// Comments
		/// </summary>
		public List<ArticleCommentModel> Comments { get; set; } = new List<ArticleCommentModel>();

		public List<ArticleListItemModel> PopularArticles { get; set; } = [];

    }
}
