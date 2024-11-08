using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Core.Utils
{
    /// <summary>
    /// MD5帮助类
    /// </summary>
    public static class MD5Encrypt
    {
        /// <summary>
        /// 创建加密
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>返回大写MD5</returns>
        public static string Create(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = MD5.HashData(inputBytes);
            return Convert.ToHexString(hashBytes);
        }

        /// <summary>
        /// 创建加密
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>返回小写MD5</returns>
        public static string CreateToLower(string input)
        {
            var result = Create(input);
            return result.ToLower();
        }
    }
}
