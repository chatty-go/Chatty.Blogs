using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Series
{
    public class SeriesService(BaseRepository<BlogSeries> baseRepository) : ISeriesService
    {
        private readonly BaseRepository<BlogSeries> _baseRepository = baseRepository;

        public async Task<Tuple<List<BlogSeries>, int>> GetPageListAsync(PageRequest request)
        {
            var pgae = new PageModel()
            {
                PageIndex = request.Page,
                PageSize = request.Limit
            };

            var list = await _baseRepository
                .GetPageListAsync(a => a.DeleteFlag == "N", pgae, a => a.TaxisNo, OrderByType.Asc);

            return new Tuple<List<BlogSeries>, int>(list, pgae.TotalCount);
        }

        public async Task<BlogSeries> GetByIdAsync(string id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

	}
}
