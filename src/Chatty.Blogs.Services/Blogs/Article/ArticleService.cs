using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Blogs.Article.Dtos;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace Chatty.Blogs.Services.Blogs.Article
{
    /// <summary>
    /// 文章管理 - 服务
    /// </summary>
    /// <param name="baseRepository"></param>
    public class ArticleService(BaseRepository<BlogArticle> baseRepository, IMemoryCache memoryCache) : IArticleService
    {
        private readonly BaseRepository<BlogArticle> _baseRepository = baseRepository;
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<List<BlogArticle>, int>> GetPageListAsync(BlogPageRequest request)
        {
            RefAsync<int> total = 0;

            var list = await _baseRepository
                .AsQueryable()
                .Where(a => a.DeleteFlag == "N" && a.Status == 1)
                .WhereIF(!string.IsNullOrEmpty(request.FrontCategoryId),a=>a.FrontCategoryId == request.FrontCategoryId)
                .WhereIF(!string.IsNullOrEmpty(request.HomeBlock), a => a.HomeBlock == request.HomeBlock)
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .Select(a => new BlogArticle
                {
                    RowId = a.RowId,
                    Title = a.Title,
                    CreatedDate = a.CreatedDate,
                    LastUpdDate = a.LastUpdDate,
                    CoverUrl = a.CoverUrl,
                    Quote = a.Quote
                })
                .ToPageListAsync(request.Page, request.Limit, total);

            return Tuple.Create(list, total.Value);
        }

		public async Task<List<BlogArticle>> TakeTenListAsync(string homeBlock)
        {
            var list = await _baseRepository.AsQueryable()
                .Take(10)
                .Where(a=>a.HomeBlock== homeBlock)
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .Select(a=>new BlogArticle
                {
                    RowId = a.RowId,
                    Title = a.Title,
                    CreatedDate = a.CreatedDate,
                    LastUpdDate = a.LastUpdDate,
                    CoverUrl = a.CoverUrl,
                    Quote = a.Quote
                })
                .ToListAsync();

            return list;
        }

		/// <summary>
		/// 查询明细
		/// </summary>
		/// <param name="rowId"></param>
		/// <returns></returns>
		public async Task<BlogArticle> GetAsync(string rowId)
        {
            return await _baseRepository.AsQueryable()
               .FirstAsync(a=>a.RowId== rowId && a.DeleteFlag == "N" && a.Status == 1 && a.IsPublic==1);
        }

        /// <summary>
        /// Top Article
        /// </summary>
        /// <returns></returns>
        public async Task<BlogArticle> GetTopAsync()
        {
            return await _baseRepository.AsQueryable()
                .Select(a => new BlogArticle
                {
                    RowId = a.RowId,
                    Title = a.Title,
                    CreatedDate = a.CreatedDate,
                    LastUpdDate = a.LastUpdDate,
                    CoverUrl = a.CoverUrl,
                    Quote = a.Quote
                })
                .FirstAsync(a => a.IsTop == 1 && a.DeleteFlag == "N" && a.Status == 1 && a.IsPublic == 1);
        }

        public async Task<List<BlogArticle>> GetRecentAsync()
        {
            return await _baseRepository.AsQueryable()
                .Where(a=> a.DeleteFlag == "N" && a.Status == 1 && a.IsPublic == 1)
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .Take(4)
                .Select(a => new BlogArticle
                {
                    RowId = a.RowId,
                    Title = a.Title,
                    CreatedDate = a.CreatedDate,
                    LastUpdDate = a.LastUpdDate,
                    CoverUrl = a.CoverUrl,
                    Quote = a.Quote
                })
                .ToListAsync();
        }

		public async Task<List<BlogArticle>> GetPopularAsync(int limit=4)
		{
			return await _baseRepository.AsQueryable()
				.Where(a => a.DeleteFlag == "N" && a.Status == 1 && a.IsPublic == 1)
				.OrderBy(a => a.ViewCount, OrderByType.Desc)
				.Take(limit)
                .Select(a => new BlogArticle
                {
                    RowId = a.RowId,
                    Title = a.Title,
                    CreatedDate = a.CreatedDate,
                    LastUpdDate = a.LastUpdDate,
                    CoverUrl = a.CoverUrl,
                    Quote = a.Quote
                })
                .ToListAsync();
		}

		public async Task<List<TagCloudCount>> GetTagCloudListAsync()
        {
            var cacheKey = "Site_TagClouds";
            List<TagCloudCount> tagClouds = [];

            if (!_memoryCache.TryGetValue(cacheKey, out tagClouds))
            {
                try
                {
                    await _semaphoreSlim.WaitAsync();

                    if (!_memoryCache.TryGetValue(cacheKey, out tagClouds))
                    {
                        Console.WriteLine("First Visit Site Setting:");

                        var list = await _baseRepository
                            .AsQueryable()
                            .Where(a=>a.DeleteFlag=="N" && a.IsPublic==1 && a.Status==1)
                            .GroupBy(a => a.Tags)
                            .Select(a => new TagCloudCount { Count = SqlFunc.AggregateCount(a.RowId), Tags = a.Tags })
                            .ToListAsync();

                        List<TagCloudCount> result = new List<TagCloudCount>();

                        foreach (var item in list)
                        {
                            var tags = item.Tags?.Split(',').ToList();

                            if (tags != null && tags.Count > 0)
                            {
                                foreach (var tag in tags)
                                {
                                    var find = result.Find(x => x.Tags == tag);
                                    if (find == null)
                                    {
                                        result.Add(new TagCloudCount { Tags = tag, Count = item.Count });
                                    }
                                    else
                                    {
                                        find.Count += item.Count;
                                    }
                                }
                            }
                        }

                        tagClouds = result;

                        _memoryCache.Set(cacheKey, tagClouds, TimeSpan.FromDays(30));
                    }

                }
                finally
                {
                    _semaphoreSlim.Release();
                }

            }

            

            return tagClouds;
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<List<BlogArticle>, int>> GetTagArticleListAsync(BlogPageRequest request)
        {
            RefAsync<int> total = 0;

            var list = await _baseRepository
                .AsQueryable()
                .Where(a => a.DeleteFlag == "N" && a.IsPublic==1 && a.Status == 1 && a.Tags.Contains(request.Tags))
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .Select(a => new BlogArticle
                {
                    RowId = a.RowId,
                    Title = a.Title,
                    CreatedDate = a.CreatedDate,
                    LastUpdDate = a.LastUpdDate,
                    CoverUrl = a.CoverUrl,
                    Quote = a.Quote
                })
                .ToPageListAsync(request.Page, request.Limit, total);

            return Tuple.Create(list, total.Value);
        }

        public async Task<Tuple<List<BlogArticle>, int>> GetBlockArticleListAsync(BlogPageRequest request)
        {
            RefAsync<int> total = 0;

            var list = await _baseRepository
                .AsQueryable()
                .Where(a => a.DeleteFlag == "N" && a.IsPublic == 1 && a.Status == 1 && a.HomeBlock==request.Block)
                .OrderBy(a => a.CreatedDate, OrderByType.Desc)
                .Select(a => new BlogArticle
                {
                    RowId = a.RowId,
                    Title = a.Title,
                    CreatedDate = a.CreatedDate,
                    LastUpdDate = a.LastUpdDate,
                    CoverUrl = a.CoverUrl,
                    Quote = a.Quote
                })
                .ToPageListAsync(request.Page, request.Limit, total);

            return Tuple.Create(list, total.Value);
        }

    }
}
