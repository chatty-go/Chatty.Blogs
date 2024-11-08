using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Core.Http
{
    /// <summary>
    /// 分页请求 - DTO
    /// </summary>
    public class PageRequest: BaseRequest
    {
        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; } = "created"; // updated

        /// <summary>
        /// 搜索
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// Range
        /// </summary>
        public int? Range { get; set; }

        public int? Status { get; set; }
    }
}
