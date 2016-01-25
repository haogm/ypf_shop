using System.Data.Entity;
using System.Data.SqlClient;
using ypf.shop.IDAL;

namespace ypf.shop.DAL
{
    /// <summary>
    /// 数据库访问统一入库
    /// </summary>
    public class DbSessionContext : IDbSessionContext
    {
        private DbContext _db;
        /// <summary>
        /// 访问数据库的上下文
        /// </summary>
        private DbContext Db
        {
            get
            {
                if (_db == null)
                {
                    IObjectContextEntityFactory objectContext = new ObjectContextEntityFactory();
                    _db = objectContext.CreateEntity();
                }
                return _db;
            }
            set { _db = value; }
        }
        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get { return _productRepository ?? new ProductRepository(); }

            set { _productRepository = value; }
        }

        private IUserInfoRepository _userInfoRepository;
        public IUserInfoRepository UserInfoRepository
        {
            get { return _userInfoRepository ?? new UserInfoRepository(); }

            set { _userInfoRepository = value; }
        }

        public int ExcuteSql(string sqlCommand, params SqlParameter[] parameters)
        {
            return Db.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}