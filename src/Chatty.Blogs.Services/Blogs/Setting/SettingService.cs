using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;
using Microsoft.Extensions.Caching.Memory;

namespace Chatty.Blogs.Services.Blogs.Setting
{
    public class SettingService(IMemoryCache memoryCache, BaseRepository<SiteConfig> baseRepository) : ISettingService
    {
        private readonly BaseRepository<SiteConfig> _baseRepository = baseRepository;
        private readonly IMemoryCache _memoryCache = memoryCache;
		private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

		public async Task<SiteConfig> GetSettingAsync()
        {
            var cacheKey = "Site_Setting";

			if (!_memoryCache.TryGetValue(cacheKey, out SiteConfig siteConfig))
			{
				try
				{
					await _semaphoreSlim.WaitAsync();

					if (!_memoryCache.TryGetValue(cacheKey, out siteConfig))
					{
						Console.WriteLine("First Visit Site Setting:");
						siteConfig = await _baseRepository.GetFirstAsync(a => 1 == 1);
						_memoryCache.Set(cacheKey, siteConfig, TimeSpan.FromDays(30));
					}

				}
				finally
				{
					_semaphoreSlim.Release();
				}
				
			}

			Console.WriteLine("读取网站配置："+siteConfig?.Keywords);

			return siteConfig;
        }
    }
}
