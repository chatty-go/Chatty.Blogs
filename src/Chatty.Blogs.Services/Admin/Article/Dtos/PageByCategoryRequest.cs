using Chatty.Blogs.Core.Http;

namespace Chatty.Blogs.Services.Admin.Article.Dtos
{
	public class PageByCategoryRequest: PageRequest
	{
		public required string CategoryId { get; set; }
	}
}
