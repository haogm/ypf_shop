namespace ypf.shop.IDAL
{
    /// <summary>
    /// 数据库统一访问入口（工厂）
    /// </summary>
    public interface IDbSessionContextFactory
    {
        /// <summary>
        /// 创建一个数据库统一访问入口
        /// </summary>
        /// <returns></returns>
        IDbSessionContext CreateDbSessionContext();
    }
}