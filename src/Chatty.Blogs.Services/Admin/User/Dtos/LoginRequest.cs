using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Services.Admin.User.Dtos
{
    /// <summary>
    /// 用户登录 - 请求DTO
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        [Required]
        public required string username { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Required]
        public required string password { get; set; }
    }
}
