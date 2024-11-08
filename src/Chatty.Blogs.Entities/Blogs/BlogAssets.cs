
namespace Chatty.Blogs.Entities.Blogs
{

    [SugarTable("blog_assets")]
    public class BlogAssets:BaseEntity
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// 文件类型 image/jpeg
        /// </summary>
        [SugarColumn(ColumnName = "type")]
        public string Type { get; set; } = null!;

        /// <summary>
        /// 文件大小 
        /// </summary>
        [SugarColumn(ColumnName = "size")]
        public long Size { get; set; }

        /// <summary>
        /// 本地存储路径 - 本地资源时存在
        /// </summary>
        [SugarColumn(ColumnName = "path")]
        public string Path { get; set; } = null!;

        /// <summary>
        /// 文件访问地址
        /// </summary>
        [SugarColumn(ColumnName = "url")]
        public string Url { get; set; } = null!;

        /// <summary>
        /// 文件格式  image/audio/video
        /// </summary>
        [SugarColumn(ColumnName = "format")]
        public string Format { get; set; } = null!;

        /// <summary>
        /// 文件来源  local - 本地资源  qiniu - 七牛云 aliyun - 阿里云
        /// </summary>
        [SugarColumn(ColumnName = "source")]
        public string Source { get; set; } = null!;

        /// <summary>
        /// 云存储文件id
        /// </summary>
        [SugarColumn(ColumnName = "oss_file_id")]
        public string OssFileId { get; set; } = null!;

    }
}
