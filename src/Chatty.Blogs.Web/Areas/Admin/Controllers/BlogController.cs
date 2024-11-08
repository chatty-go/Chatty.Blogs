using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Admin.Category;
using Chatty.Blogs.Services.Admin.Series;
using Chatty.Blogs.Services.Admin.Article;
using Chatty.Blogs.Web.Areas.Admin.Models.Article;
using Chatty.Blogs.Web.Areas.Admin.Models.Category;
using Chatty.Blogs.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Chatty.Blogs.Services.Admin.Article.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Chatty.Blogs.Core.Consts;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 博客管理
    /// </summary>
    /// <param name="articleService"></param>
    [Area("Admin")]
    [Authorize]
    public class BlogController(IArticleService service, ISeriesService seriesService, 
        ICategoryService categoryService, IArticleCommentService articleCommentService) : Controller
    {
        private readonly IArticleService _service = service;
        private readonly ISeriesService _seriesService = seriesService;
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IArticleCommentService _articleCommentService = articleCommentService;
        private readonly int Limit = 30;
        private readonly int CommentLimit = 6;


        public async Task<IActionResult> Index(string? sort,string? search,int? status,int? range, int page=1)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit,
                Sort = sort ?? "created",
                Search = search,
                Range = range,
                Status = status
            };

            var result = await _service.GetPageListAsync(pageRequest);
            var list = result.Item1.Adapt<List<ArticleListItem>>();

            ArticleListViewModel model = new()
            {
                List = list,
                TotalCount = result.Item2,
                Sort = pageRequest.Sort,
                Range = pageRequest.Range,
                Page= pageRequest.Page,
                Limit = pageRequest.Limit,
                Search = pageRequest.Search,
                Finished = pageRequest.Page * pageRequest.Limit >= result.Item2
            };

            Console.WriteLine($"{result.Item2}");

            return View(model);
        }

        public async Task<HttpResult> Loadmore(string? sort, string? search, int page = 1)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit,
                Sort = sort ?? "created",
                Search = search
            };

            var result = await _service.GetPageListAsync(pageRequest);
            var list = result.Item1.Adapt<List<ArticleListItem>>();

            return new HttpResult(ResultCode.SUCCESS,new {
                TotalCount = result.Item2,
                List = list,
                Pgae = page,
                Limit,
                Finished = pageRequest.Page * pageRequest.Limit >= result.Item2
            });
        }

        /// <summary>
        /// New Post
        /// </summary>
        /// <param name="id">Post Id</param>
        /// <param name="sid">Series Id</param>
        /// <param name="cid">Category Id</param>
        /// <returns></returns>
        public async Task<IActionResult> NewPost(string? id, string? sid,string? cid)
        {
            var article = new ArticleWithDetailDto();

            if (!string.IsNullOrEmpty(id))
            {
				article = await _service.GetAsync(id);
            }

            var series = await _seriesService.GetListAsync(); 
            var categories = await _categoryService.GetListAsync();

            var frontCategories = categories.FindAll(x=>x.Type=="Front");
            var backCategories = categories.FindAll(x => x.Type == "Back");

            var model = new NewPostViewModel()
            {
                Article = article,
                Series = series.Adapt<List<SeriesListItem>>(),
                SeriesId = sid ?? article.SeriesId,
                BackCategories = backCategories.Adapt<List<CategoryTreeNode>>(),
                FrontCategories = frontCategories.Adapt<List<CategoryTreeNode>>(),
                RowId = id
            };

            if(!string.IsNullOrEmpty(article.RowId))
            {
                model.SelectedCategory = new CategoryTreeNode()
                {
                    RowId = article.CategoryId,
                    Name = article.CategoryName
                };
            }
            else
            {
				model.SelectedCategory = model.BackCategories.Find(x => x.RowId == cid);
			}

            return View("New", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<HttpResult> SaveAsync(NewArticle dto)
		{
            if (!User.IsInRole(UserRole.Administrator) && dto.IsPublic==1){
				return new HttpResult(ResultCode.FAIL,"该用户非管理员，无法发布公开的文章，请关闭 [公开] 属性。");
			}

			var entity = dto.Adapt<BlogArticle>();

            if (!string.IsNullOrEmpty(dto.RowId))
            {
                // Update
                await _service.SaveChangeAsync(entity);
            }
            else
            {
				// 获取当前用户的身份对象
				var identity = User.Identity as ClaimsIdentity;
				var userId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

				// Insert
				entity.RowId = Guid.NewGuid().ToString("N");
                entity.CreatedBy = userId;
                await _service.SaveAsync(entity);
            }

            return new HttpResult(ResultCode.SUCCESS,new { 
                rowId = entity.RowId
            });
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<HttpResult> SaveChangeAsync(ChangeArticle dto)
		{
			if (!User.IsInRole(UserRole.Administrator) && dto.IsPublic == 1)
			{
				return new HttpResult(ResultCode.FAIL, "该用户非管理员，无法发布公开的文章，请关闭公开属性。");
			}

			var entity = dto.Adapt<BlogArticle>();

			var result = await _service.SaveChangeAsync(entity);

			return new HttpResult(ResultCode.SUCCESS,new { 
                entity.RowId
            });
		}

		public async Task<IActionResult> Detail(string id)
        {
            var entity = await _service.GetAsync(id);

            var model = new ArticleDetailViewModel()
            {
                Article = entity.Adapt<NewArticle>()
            };

            return View("Detail", model);
        }

        public async Task<IActionResult> Preview(string id)
        {
            var entity = await _service.GetAsync(id);

            var model = new ArticlePreviewViewModel()
            {
                Article = entity.Adapt<ArticlePreviewModel>()
            };

            return View("Preview", model);
        }

        public async Task<HttpResult> DeleteAsync([Required]string id)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResult(ResultCode.ERROR, "参数错误");
            }

			// 获取当前用户的身份对象
			var identity = User.Identity as ClaimsIdentity;
			var userId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			var entity = await _service.GetByIdAsync(id);

            if (!User.IsInRole(UserRole.Administrator) && entity.CreatedBy!= userId)
            {
				return new HttpResult(ResultCode.FAIL, "该用户非管理员，无法删除其他用户创建的文章。");
			}

            await _service.DeleteByIdAsync(id);

            return new HttpResult(ResultCode.SUCCESS, "ok");

        }

        public IActionResult Template()
        {
            return View("Template");
        }

        public async Task<IActionResult> Comment(int page=1)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = CommentLimit
            };

            var result = await _articleCommentService.GetPageListAsync(pageRequest);

            var model = new ArticleCommentViewModel()
            {
                List = result.Item1,
                Total = result.Item2,
                Finished =  page * pageRequest.Limit >= result.Item2
            };

            return View("Comment",model);
        }

        public async Task<HttpResult> LoadMoreCommentAsync(int page = 1)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = CommentLimit
            };

            var result = await _articleCommentService.GetPageListAsync(pageRequest);

            var model = new ArticleCommentViewModel()
            {
                List = result.Item1,
                Total = result.Item2,
                Finished = page * pageRequest.Limit >= result.Item2
            };

            return new HttpResult(ResultCode.SUCCESS, new
            {
                TotalCount = result.Item2,
                List = result.Item1,
                Pgae = page,
                Limit,
                Finished = pageRequest.Page * pageRequest.Limit >= result.Item2
            });
        }

        public async Task<HttpResult> RejectAsync([Required]string id)
        {
            var result = await _articleCommentService.RejectAsync(id);

            return new HttpResult(ResultCode.SUCCESS, result);
        }

        public async Task<HttpResult> ApprovalAsync([Required] string id)
        {
            var result = await _articleCommentService.ApprovalAsync(id);

            return new HttpResult(ResultCode.SUCCESS, result);
        }

        public async Task<HttpResult> DeleteCommentAsync([Required] string id)
        {
            var result = await _articleCommentService.DeleteAsync(id);

            return new HttpResult(ResultCode.SUCCESS, result);
        }
    }
}
