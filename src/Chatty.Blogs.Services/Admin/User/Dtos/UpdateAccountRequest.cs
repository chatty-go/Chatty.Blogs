using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Services.Admin.User.Dtos
{
    /// <summary>
    /// 更新账户 - 请求DTO
    /// </summary>
    public class UpdateAccountRequest
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public required string name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public required string nickname { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public required string headimgurl { get; set; }
    }
}
