using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Visitor
{
	public class VisitorService(BaseRepository<SiteVisitRecord> baseRepository): IVisitorService
	{
		private readonly BaseRepository<SiteVisitRecord> _baseRepository = baseRepository;

		public async Task<bool> InsertAsync(SiteVisitRecord siteVisitRecord)
		{
			return await _baseRepository.InsertAsync(siteVisitRecord);
		}
	}
}
