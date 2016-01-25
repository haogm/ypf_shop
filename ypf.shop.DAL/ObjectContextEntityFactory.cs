using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using ypf.shop.IDAL;
using ypf.shop.Model;

namespace ypf.shop.DAL
{
    /// <summary>
    /// 数据访问上下文
    /// </summary>
    public class ObjectContextEntityFactory : IObjectContextEntityFactory
    {
        /// <summary>
        /// 创建数据访问上下文
        /// </summary>
        /// <returns></returns>
        public DbContext CreateEntity()
        {
            //从线程数据槽中，获取该key的数据
            DbContext context = (DbContext)CallContext.GetData(typeof(ObjectContextEntityFactory).FullName);
            if (context == null)
            {
                context = new YPF_ShopEntities();
                //设置线程槽的数据
                CallContext.SetData(typeof(ObjectContextEntityFactory).FullName, context);
            }
            return context;
        }


    }
}