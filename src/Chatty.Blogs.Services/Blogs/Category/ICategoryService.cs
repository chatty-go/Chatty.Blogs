using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Blogs.Category.Dtos;

namespace Chatty.Blogs.Services.Blogs.Category
{
    public interface ICategoryService
    {
        Task<List<BlogCategory>> GetListAsync();

        Task<List<CategoryArticleGroupItem>> GetGroupListAsync();
    }
}
