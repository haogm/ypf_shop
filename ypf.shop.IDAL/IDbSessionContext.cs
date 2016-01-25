using System.Data.SqlClient;

namespace ypf.shop.IDAL
{
    /// <summary>
    /// 数据库通过一访问入库
    /// </summary>
    public interface IDbSessionContext
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        IUserInfoRepository UserInfoRepository { get; set; }
        /// <summary>
        /// 产品信息
        /// </summary>
        IProductRepository ProductRepository { get; set; }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sqlCommand">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        int ExcuteSql(string sqlCommand, params SqlParameter[] parameters);

        /// <summary>
        /// 更新实体数据模型
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}