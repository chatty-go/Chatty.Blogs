using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chatty.Blogs.Core.Http
{
    public class BaseRequest
    {
        /// <summary>
        /// 当前页索引
        /// </summary>
        [Range(1, 99999)]
        public int Page { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        [Range(10, 500)]
        public int Limit { get; set; } = 10;
    }
}
