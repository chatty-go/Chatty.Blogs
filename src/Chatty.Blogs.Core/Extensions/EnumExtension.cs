using System.ComponentModel;

namespace Chatty.Blogs.Core.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举描述文字扩展方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var name = value.ToString();
            var field = value.GetType().GetField(name);
            if (field == null)
            {
                return name;
            }
            var att = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);

            return att == null ? field.Name : ((DescriptionAttribute)att).Description;
        }
    }
}
