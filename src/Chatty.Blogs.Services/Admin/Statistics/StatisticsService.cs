using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Admin.Statistics
{
	public class StatisticsService(BaseRepository<SiteVisitRecord> baseRepository): IStatisticsService
	{
		private readonly BaseRepository<SiteVisitRecord> _baseRepository = baseRepository;

		public  async Task<int> GetTotalVisitsAsync()
		{
			return await _baseRepository.AsQueryable().CountAsync();
		}

		public async Task<int> GetTotalUsersAsync()
		{
			var result = await _baseRepository
				.AsQueryable().Distinct().Select(it => new { it.IpAddress }).CountAsync();

			return result;
		}
	}
}
