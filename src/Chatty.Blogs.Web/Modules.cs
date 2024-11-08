using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Admin.Article;
using Chatty.Blogs.Services.Admin.Assets;
using Chatty.Blogs.Services.Admin.Category;
using Chatty.Blogs.Services.Admin.Message;
using Chatty.Blogs.Services.Admin.Series;
using Chatty.Blogs.Services.Admin.Setting;
using Chatty.Blogs.Services.Admin.Statistics;
using Chatty.Blogs.Services.Admin.User;

namespace Chatty.Blogs.Web
{
	/// <summary>
	/// 模块注册
	/// </summary>
	public static class Modules
	{
		/// <summary>
		/// 注册博客模块
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterBlogsWebModule(this IServiceCollection services)
		{
			// 注册仓储
			services.AddScoped(typeof(BaseRepository<BlogArticle>));
			services.AddScoped(typeof(BaseRepository<BlogUser>));
			services.AddScoped(typeof(BaseRepository<BlogSeries>));
			services.AddScoped(typeof(BaseRepository<BlogCategory>));
            services.AddScoped(typeof(BaseRepository<SiteConfig>));
			services.AddScoped(typeof(BaseRepository<BlogSeriesOutline>));
			services.AddScoped(typeof(BaseRepository<BlogArticleComment>));
			services.AddScoped(typeof(BaseRepository<SiteVisitRecord>));
            services.AddScoped(typeof(BaseRepository<SiteMessage>));
            services.AddScoped(typeof(BaseRepository<BlogAssets>));

            // 管理后台
            services.AddScoped<IArticleService, ArticleService>();  
			services.AddScoped<IUserService, UserService>();       
			services.AddScoped<ISeriesService, SeriesService>();   
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ISettingService, SettingService>(); 
			services.AddScoped<ISeriesOutlineService, SeriesOutlineService>(); 
			services.AddScoped<IStatisticsService, StatisticsService>();
			services.AddScoped<IMessageService, MessageService>(); 
			services.AddScoped<IAssetsService, AssetsService>();
			services.AddScoped<IArticleCommentService, ArticleCommentService>();

			// 前台
			services.AddScoped<Chatty.Blogs.Services.Blogs.Setting.ISettingService, Chatty.Blogs.Services.Blogs.Setting.SettingService>();
			services.AddScoped<Chatty.Blogs.Services.Blogs.Contact.IContactService, Chatty.Blogs.Services.Blogs.Contact.ContactService>();
			services.AddScoped<Chatty.Blogs.Services.Blogs.Article.IArticleService, Chatty.Blogs.Services.Blogs.Article.ArticleService>();
			services.AddScoped<Chatty.Blogs.Services.Blogs.Series.ISeriesService, Chatty.Blogs.Services.Blogs.Series.SeriesService>();
			services.AddScoped<Chatty.Blogs.Services.Blogs.Series.ISeriesOutlineService, Chatty.Blogs.Services.Blogs.Series.SeriesOutlineService>();
			services.AddScoped<Chatty.Blogs.Services.Blogs.Article.IArticleCommentService, Chatty.Blogs.Services.Blogs.Article.ArticleCommentService>();
            services.AddScoped<Chatty.Blogs.Services.Blogs.Category.ICategoryService, Chatty.Blogs.Services.Blogs.Category.CategoryService>();
			services.AddScoped<Chatty.Blogs.Services.Blogs.Visitor.IVisitorService, Chatty.Blogs.Services.Blogs.Visitor.VisitorService>();

            return services;
		}
	}
}
