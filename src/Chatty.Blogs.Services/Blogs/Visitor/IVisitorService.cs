using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Visitor
{
	public interface IVisitorService
	{
		Task<bool> InsertAsync(SiteVisitRecord siteVisitRecord);
	}
}
