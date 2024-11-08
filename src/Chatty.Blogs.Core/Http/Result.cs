using Chatty.Blogs.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Core.Http
{
    /// <summary>
    /// 统一结果返回类
    /// </summary>
    public class HttpResult
    {
        public HttpResult(ResultCode resultCode, string msg)
        {
            code = resultCode;
            _msg = msg;
        }

        public HttpResult(ResultCode resultCode)
        {
            code = resultCode;
        }

        public HttpResult(ResultCode resultCode, object resultData)
        {
            code = resultCode;
            data = resultData;
        }

        /// <summary>
        /// 业务返回码
        /// </summary>
        public ResultCode code { get; set; } = ResultCode.SUCCESS;

        /// <summary>
        /// 业务返回说明
        /// </summary>
        private string? _msg;

        public string? msg
        {
            get
            {
                return !string.IsNullOrEmpty(_msg) ? _msg : code.GetDescription();
            }
            set => _msg = value;
        }

        /// <summary>
        /// 数据对象
        /// </summary>
        public object? data { get; set; }
    }

    /// <summary>
    /// 统一结果返回类
    /// </summary>
    public class HttpResult<T>
    {
        /// <summary>
        /// 业务返回码
        /// </summary>
        public ResultCode code { get; set; } = ResultCode.SUCCESS;

        /// <summary>
        /// 业务返回说明
        /// </summary>
        private string? _msg;

        public string? msg
        {
            get
            {
                return !string.IsNullOrEmpty(_msg) ? _msg : code.GetDescription();
            }
            set => _msg = value;
        }

        /// <summary>
        /// 业务数据
        /// </summary>
        public T? data { get; set; }


        /// <summary>
        /// 扩展方法：业务请求成功
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpResult<T> Success(T data)
        {
            return new HttpResult<T>
            {
                code = ResultCode.SUCCESS,
                data = data
            };
        }

        /// <summary>
        /// 扩展方法：业务请求失败
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static HttpResult<T> Fail(string? msg)
        {
            return new HttpResult<T>
            {
                code = ResultCode.FAIL,
                msg = msg
            };
        }

        /// <summary>
        /// 扩展方法：业务请求异常
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static HttpResult<T> Error(string? msg)
        {
            return new HttpResult<T> { code = ResultCode.ERROR, msg = msg };
        }

        /// <summary>
        /// 扩展方法：自定义返回状态
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static HttpResult<T> Create(ResultCode code, string? msg, T? Data)
        {
            return new HttpResult<T>
            {
                code = code,
                data = Data,
                msg = msg
            };
        }

        /// <summary>
        /// 扩展方法：自定义返回状态
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static HttpResult<T> Create(ResultCode code, string? msg)
        {
            return new HttpResult<T>
            {
                code = code,
                msg = msg
            };
        }

        /// <summary>
        /// 扩展方法：自定义返回状态
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static HttpResult<T> Create(ResultCode code)
        {
            return new HttpResult<T>
            {
                code = code
            };
        }

        /// <summary>
        /// 隐式将T转化为ResponseResult<T>，仅对Success状态下有效果，可以直接返回result而不需要Success包裹。
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator HttpResult<T>(T value)
        {
            return new HttpResult<T> { data = value };
        }
    }
}
