
namespace Chatty.Blogs.Services.Admin.Statistics
{
	public interface IStatisticsService
	{
		Task<int> GetTotalUsersAsync();

		Task<int> GetTotalVisitsAsync();
	}
}
