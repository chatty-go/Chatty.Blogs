using Microsoft.AspNetCore.Mvc;

namespace Chatty.Blogs.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    /// <summary>
    /// 文件上传
    /// </summary>
    public class UploadController(IWebHostEnvironment webHostEnvironment, IConfiguration  configuration) : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        private readonly IConfiguration _configuration = configuration;

        private string[] permittedExtensions = { ".png", ".jpg","jpeg" };

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="avatar"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] IFormFile formFile)
        {
            if (formFile == null)
            {
                return new JsonResult(new { 
                    code=-1,
                    msg="请上传文件"
                });
            }

            var fileExt = Path.GetExtension(formFile.FileName);

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

            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            var fileName = Path.GetRandomFileName() + fileExt;
            var filePath = Path.Combine(directory, fileName);

            using var stream = System.IO.File.Create(filePath);
            await formFile.CopyToAsync(stream);

            var url = _configuration["HostApi"] + "/upload/"+ fileName;

            return new JsonResult(new { 
                code=1,
                msg= "ok",
                data = new
                {
                    url
                }
            });
        }
    }
}
