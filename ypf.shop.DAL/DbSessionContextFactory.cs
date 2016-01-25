using System.Runtime.Remoting.Messaging;
using ypf.shop.IDAL;

namespace ypf.shop.DAL
{
    /// <summary>
    /// 数据库统一访问入口（工厂）
    /// </summary>
    public class DbSessionContextFactory : IDbSessionContextFactory
    {
        public IDbSessionContext CreateDbSessionContext()
        {
            IDbSessionContext dbSessionContext = (IDbSessionContext)CallContext.GetData(typeof(DbSessionContextFactory).FullName);
            if (dbSessionContext == null)
            {
                dbSessionContext = new DbSessionContext();
                CallContext.SetData(typeof(DbSessionContextFactory).FullName, dbSessionContext);
            }
            return dbSessionContext;
        }
    }
}