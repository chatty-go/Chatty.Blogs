using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Core.Http
{
    public class BlogPageRequest: BaseRequest
    {
        /// <summary>
        /// 首页版块
        /// Default=默认，
        /// Inspiration=灵感
        /// Recommand=编辑推荐
        /// Trending=趋势
        /// </summary>
        public string? HomeBlock { get; set; }

        public string? FrontCategoryId { get; set; }

        public string? Tags { get; set; }

        public string? Block { get; set; }
    }
}
