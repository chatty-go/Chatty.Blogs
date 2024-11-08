using Chatty.Blogs.Database.Orm;
using Chatty.Blogs.Entities.Blogs;

namespace Chatty.Blogs.Services.Blogs.Contact
{
    public class ContactService(BaseRepository<SiteConfig> baseRepository) : IContactService
    {
        private readonly BaseRepository<SiteConfig> _baseRepository = baseRepository;

        public async Task<SiteConfig> GetAsync()
        {
            return await _baseRepository.GetFirstAsync(a => 1 == 1);
        }

        public async Task<bool> AddAsync(SiteMessage entity)
        {
            return await _baseRepository.ChangeRepository<BaseRepository<SiteMessage>>().AsInsertable(entity)
                .ExecuteCommandAsync() > 0;        
        }
    }
}
