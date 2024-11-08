using System.ComponentModel;

namespace Chatty.Blogs.Core.Http
{
    /// <summary>
    /// HTTP请求-系统统一业务状态码
    /// </summary>
    public enum ResultCode
    {
        /*
         *  #1000～1999 区间表示参数错误
            #2000～2999 区间表示用户错误
            #3000～3999 区间表示接口异常
            #4000～4999 区间表示数据库错误
            #5000～5999 区间表示页面错误
            #6000～6999 区间表示租户错误
         */


        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        SUCCESS = 1,

        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        FAIL = 0,

        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("系统内部错误")]
        ERROR = -1,

        #region 参数错误

        // ## 参数错误

        /// <summary>
        /// 参数无效
        /// </summary>
        [Description("请求参数无效或格式错误")]
        PARAM_IS_INVALID = 1001,

        /// <summary>
        /// 参数为空
        /// </summary>
        PARAM_IS_BLANK = 1002,

        /// <summary>
        /// 参数类型错误
        /// </summary>
        PARAM_TYPE_BIND_ERROR = 1003,

        /// <summary>
        /// 参数缺失
        /// </summary>
        PARAM_NOT_COMPLETE = 1004,

        /// <summary>
        /// 模块代码已存在
        /// </summary>
        PARAM_MODULE_CODE_EXSIT = 1005,

        /// <summary>
        /// 模块代码不存在
        /// </summary>
        PARAM_MODULE_CODE_NOT_EXSIT = 1005,

        /// <summary>
        /// 参数类型错误
        /// </summary>
        PARAM_FIELD_TYPE_ERROR = 1006,

        /// <summary>
        /// 文件扩展名不支付
        /// </summary>
        PARAM_FILE_EXTENSION_NOT_SUPPORTED = 1007,

        /// <summary>
        /// 文件大小超出
        /// </summary>
        PARAM_FILE_SIZE_OVER = 1008,

        /// <summary>
        /// 没有接收到文件
        /// </summary>
        PARAM_FILE_EMPTY = 1009,

        #endregion

        #region 用户错误

        // ## 用户错误

        /// <summary>
        /// 用户未登录
        /// </summary>
        USER_NOT_LOGGED_IN = 2001,

        /// <summary>
        /// 用户名或密码错误
        /// </summary>
        [Description("用户名或密码错误")]
        USER_LOGIN_ERROR = 2002,

        /// <summary>
        /// 账号被禁用
        /// </summary>
        USER_ACCOCUNT_FORBIDDEN = 2003,

        /// <summary>
        /// 账号不存在
        /// </summary>
        USER_NOT_EXIST = 2004,

        /// <summary>
        /// 该账号已经存在
        /// </summary>
        USER_HAS_EXISTED = 2005,

        /// <summary>
        /// 登录验证码为空
        /// </summary>
        [Description("登录验证码为空")]
        USER_LOGIN_CAPTCHA_NOT_COMPLETE = 2006,

        /// <summary>
        /// 登录验证码输入错误
        /// </summary>
        [Description("登录验证码输入错误")]
        USER_LOGIN_CAPTCHA_ERROR = 2007,

        /// <summary>
        /// 账号被锁定
        /// </summary>
        [Description("账号被锁定")]
        USER_ACCOUNT_LOCKED = 2008,

        /// <summary>
        /// 账号首次登录，请先修改密码
        /// </summary>
        [Description("账号首次登录，请先修改密码")]
        USER_ACCOUNT_FIRST_LOGIN = 2009,

        /// <summary>
        /// 账号密码已经过期，请先修改密码
        /// </summary>
        [Description("账号密码已经过期，请先修改密码")]
        USER_ACCOUNT_NEED_CHANGE_PASSWORD = 2010,

        /// <summary>
        /// 账号没有关联的角色
        /// </summary>
        USER_ACCOUNT_ROLE_NOT_COMPLETE = 2011,

        /// <summary>
        /// 账号未授权访问
        /// </summary>
        [Description("账号未授权访问")]
        USER_UNAUTHORIZED_ACCESS = 2013,

        /// <summary>
        /// 请不要设置三个月内重复的密码
        /// </summary>
        [Description("请不要设置三个月内重复的密码")]
        USER_ACCOUNT_PASSWORD_REPEAT = 2014,

        /// <summary>
        /// 账号不存在
        /// </summary>
        USER_ACCOUNT_ERROR = 2015,

        /// <summary>
        /// 账号未绑定邮箱
        /// </summary>
        USER_ACCOUNT_EMAIL_NOT_COMPLETE = 2016,

        /// <summary>
        /// 用户ID为空
        /// </summary>
        USER_ID_IS_NULL = 2018,

        #endregion

        #region 数据库错误

        // ## 数据库连接

        /// <summary>
        /// 连接数据库失败
        /// </summary>
        [Description("连接数据库失败，请检查账号状态或数据库服务")]
        DB_CONNECTION_TIMEOUT = 4001,

        /// <summary>
        /// 没有查询到数据
        /// </summary>
        DB_DATA_NOT_FOUND = 4040,

        /// <summary>
        /// 数据已经存在
        /// </summary>
        DB_DATA_EXIST = 4041,

        /// <summary>
        /// 数据库表已经存在
        /// </summary>
        DB_TABLE_EXIST = 4050,

        /// <summary>
        /// 数据库表初始化成功
        /// </summary>
        DB_TABLE_INIT_SUCCESS = 4060,

        #endregion

        #region 页面错误

        // ## 页面错误

        /// <summary>
        /// 页面过期，请刷新重试
        /// </summary>
        [Description("页面停留时间过长，请刷新重试")]
        PAGE_SESSION_TIMEOUT = 5000,

        /// <summary>
        /// 页面未授权
        /// </summary>
        PAGE_PERMISSION_DENIED = 5001,

        /// <summary>
        /// 页面已存在
        /// </summary>
        PAGE_ALREADY_EXIST = 5002,

        /// <summary>
        /// 该模块属于系统模块，无法进行生成
        /// </summary>
        PAGE_GENERATE_DENIED = 5003,

        #endregion

    }
}
