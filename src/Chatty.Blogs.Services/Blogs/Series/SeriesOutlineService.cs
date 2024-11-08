using Chatty.Blogs.Entities.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Services.Blogs.Series
{
    public class SeriesOutlineService(ISqlSugarClient sqlSugarClient): ISeriesOutlineService
    {
        private readonly ISqlSugarClient _sqlSugarClient = sqlSugarClient;

        public async Task<List<BlogSeriesOutlineTree>> GetTreeList(string seriesId)
        {
            var list = await _sqlSugarClient.Queryable<BlogSeriesOutlineTree>()
                .Where(a => a.SeriesId == seriesId)
                .OrderBy(a => a.TaxisNo, OrderByType.Asc)
                .ToTreeAsync(a => a.Children, a => a.ParentId, 0);

            return list;
        }
    }
}
