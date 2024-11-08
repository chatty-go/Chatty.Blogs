using Chatty.Blogs.Core.Http;
using Chatty.Blogs.Entities.Blogs;
using Chatty.Blogs.Services.Admin.Assets;
using Chatty.Blogs.Web.Areas.Admin.Models.Assets;
using Chatty.Blogs.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AssetsController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration
        , IAssetsService assetsService) : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        private readonly IConfiguration _configuration = configuration;
        private readonly IAssetsService _service = assetsService;

        private string[] permittedExtensions = { ".png", ".jpg", "jpeg" };
        private const int Limit = 20;

        public async Task<IActionResult> Index(int page=1)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit
            };

            var result = await _service.GetPageListAsync(pageRequest);

            var model = new AssetsIndexViewModel()
            {
                List = result.Item1.Adapt<List<AssetsListItemModel>>(),
                Total = result.Item2,
                Finished = pageRequest.Page * pageRequest.Limit >= result.Item2
            };

            return View(model);
        }

        public async Task<HttpResult> Loadmore(int page)
        {
            PageRequest pageRequest = new()
            {
                Page = page,
                Limit = Limit
            };

            var result = await _service.GetPageListAsync(pageRequest);

            return new HttpResult(ResultCode.SUCCESS, new
            {
                TotalCount = result.Item2,
                List = result.Item1,
                Pgae = page,
                Limit,
                Finished = pageRequest.Page * pageRequest.Limit >= result.Item2
            });
        }

        public async Task<HttpResult> UpdateNameAsync(UpdateNameRequest request)
        {
            var result = await _service.UpdateNameAsync(request.RowId, request.Name);

            return new HttpResult(ResultCode.SUCCESS, result);
        }

        public async Task<HttpResult> DeleteAsync(string id)
        {
            var result = await _service.DeleteAsync(id);

            return new HttpResult(ResultCode.SUCCESS, result);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="avatar"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadAsync(AssetsUploadRequest request)
        {
            var fileExt = Path.GetExtension(request.File.FileName);

            if (string.IsNullOrEmpty(fileExt) || !permittedExtensions.Contains(fileExt))
            {
                return new JsonResult(new
                {
                    code = -1,
                    msg = "文件格式不受支持"
                });
            }

            Console.Write("_webHostEnvironment " + _webHostEnvironment.WebRootPath);

            var directory = Path.Combine(_webHostEnvironment.WebRootPath, "upload");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileName = Path.GetRandomFileName() + fileExt;
            var filePath = Path.Combine(directory, fileName);

            using var stream = System.IO.File.Create(filePath);
            await request.File.CopyToAsync(stream);

            var url = _configuration["HostApi"] + "/upload/" + fileName;

            var entity = new BlogAssets()
            {
                RowId = Guid.NewGuid().ToString("N"),
                Name = request.Name ?? request.File.FileName,
                Url = url,
                Format = request.Format,
                Path = filePath,
                Size = request.File.Length,
                Source = request.Source,
                Type = request.Type
            };

            await _service.AddAsync(entity);

            return new JsonResult(new
            {
                code = 1,
                msg = "ok",
                data = new
                {
                    url,
                    name = entity.Name,
                    rowId = entity.RowId,
                    size = entity.Size
                }
            });
        }
    }
}
