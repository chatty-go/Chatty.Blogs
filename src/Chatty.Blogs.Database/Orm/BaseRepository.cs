using SqlSugar;

namespace Chatty.Blogs.Database.Orm
{
    public class BaseRepository<T> : SimpleClient<T> where T : class, new()
    {
        public BaseRepository(ISqlSugarClient db)
        {
            base.Context = db;

        }

        /// <summary>
        /// 扩展方法，自带方法不能满足的时候可以添加新方法
        /// </summary>
        /// <returns></returns>
        public List<T> CommQuery(string json)
        {
            //base.Context.Queryable<T>().ToList();可以拿到SqlSugarClient 做复杂操作
            throw new NotImplementedException();
        }
    }
}
