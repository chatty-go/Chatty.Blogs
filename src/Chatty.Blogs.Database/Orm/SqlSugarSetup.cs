using Chatty.Blogs.Entities.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Blogs.Database.Orm
{
    /// <summary>
    /// SqlSugar初始化
    /// </summary>
    public static class SqlSugarSetup
    {
        /// <summary>
        /// SqlSugar初始化
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqlSugarContext(this IServiceCollection services, IConfiguration configuration)
        {
            //注册SqlSugar用AddScoped
            services.AddScoped<ISqlSugarClient>(s =>
            {
                var configs = configuration.GetSection("ConnectionConfigs").Get<List<ConnectionConfig>>();

                //Scoped用SqlSugarClient 
                SqlSugarClient sqlSugar = new SqlSugarClient(configs,
               db =>
               {
                   //每次上下文都会执行

                   //获取IOC对象不要求在一个上下文
                   //var log=s.GetService<Log>()

                   //获取IOC对象要求在一个上下文
                   //var appServive = s.GetService<IHttpContextAccessor>();
                   //var log= appServive?.HttpContext?.RequestServices.GetService<Log>();

                   db.Aop.OnLogExecuting = (sql, pars) =>
                   {
                       //Console.WriteLine($"执行SQL：{sql}{Environment.NewLine}");
                   };

                   // 插入和更新过滤器
                   db.Aop.DataExecuting = (oldValue, entityInfo) =>
                   {
                       // 新增
                       if (entityInfo.OperationType == DataFilterType.InsertByObject)
                       {
                           // 1-默认ID设置默认值
                           if (entityInfo.EntityColumnInfo.IsPrimarykey
                               && entityInfo.PropertyName == nameof(BaseEntity.RowId))
                           {
                               var id = entityInfo.EntityColumnInfo.PropertyInfo.GetValue(entityInfo.EntityValue);
                               if (id == null)
                               {
                                   entityInfo.SetValue(Guid.NewGuid().ToString("N"));
                               }
                           }

                           // 2-设置默认创建时间
                           if (entityInfo.PropertyName == nameof(BaseEntity.CreatedDate))
                           {
                               entityInfo.SetValue(DateTime.Now);
                           }

                           // 3-设置创建人
                           if (entityInfo.PropertyName == nameof(BaseEntity.CreatedBy))
                           {
                               //entityInfo.SetValue(AppCore.GetUserId());
                           }

                           // 4-删除标志
                           if(entityInfo.PropertyName == nameof(BaseEntity.DeleteFlag))
                           {
                               entityInfo.SetValue("N");
                           }

                       }

                       // 更新操作
                       else if (entityInfo.OperationType == DataFilterType.UpdateByObject)
                       {
                           // 1-设置更新时间
                           if (entityInfo.PropertyName == nameof(BaseEntity.LastUpdDate))
                           {
                               entityInfo.SetValue(DateTime.Now);
                           }

                           // 2-设置修改人
                           if (entityInfo.PropertyName == nameof(BaseEntity.LastUpdBy))
                           {
                               //entityInfo.SetValue(AppCore.GetUserId());
                           }
                       }


                   };
               });
                return sqlSugar;
            });

            return services;
        }
    }
}
