namespace Chatty.Blogs.Web.Areas.Admin.Models.Assets
{
    public class AssetsUploadRequest
    {
        /// <summary>
        /// 文件对象
        /// </summary>
        public required IFormFile File { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 文件类型 image/png image/jpeg image/gif video/mp4 audio/mp3
        /// </summary>
        public required string Type { get; set; }

        /// <summary>
        /// 文件大小 B
        /// </summary>
        public required int Size { get; set; }

        /// <summary>
        /// 文件格式 image=图片 video=视频 audio=音频
        /// </summary>
        public required string Format { get; set; }

        /// <summary>
        /// 存储源：本地存储=local 七牛云存储=qiniu 阿里云存储=aliyun
        /// </summary>
        public required string Source { get; set; } = "local";

    }
}
