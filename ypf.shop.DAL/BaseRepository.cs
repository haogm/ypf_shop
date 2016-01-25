using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using ypf.shop.IDAL;

namespace ypf.shop.DAL
{
    /// <summary>
    /// 根据上下文访问数据库实现基类
    /// </summary>
    /// <typeparam name="TG"></typeparam>
    public class BaseRepository<TG> where TG : class, new()
    {
        /// <summary>
        /// 访问数据库的上下文
        /// </summary>
        private DbContext _db;

        /// <summary>
        /// 访问数据库的上下文
        /// </summary>
        public DbContext Db
        {
            get
            {
                if (_db == null)
                {
                    IObjectContextEntityFactory objectContextEntityFactory = new ObjectContextEntityFactory();
                    _db = objectContextEntityFactory.CreateEntity();
                }
                return _db;
            }
            set { _db = value; }
        }
        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Add(TG entity)
        {
            if (entity != null)
            {
                Db.Entry(entity).State = EntityState.Added;

                return Db.SaveChanges() > 0;

            }
            return false;
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public virtual bool Delete(TG entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            if (Db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>

        public virtual IQueryable<TG> Load(Func<TG, bool> where)
        {
            //思路：这里将DBContext转为ObjectContext，主要是为了能进行查询操作。由于DBContext的我还不知道怎么进行查询
            //            Db.UserInfo.Where(where)  如何改为  Db.T.Where(where)

            //            将DBContext转为ObjectContext
            ObjectContext context = ((IObjectContextAdapter)Db).ObjectContext;
            return context.CreateObjectSet<TG>().Where(where).AsQueryable();
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="totalcount">总条数</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="desc">是否降序</param>
        /// <returns></returns>

        public virtual IQueryable<TG> LoadPages<T>(int pageIndex, int pageSize, out int totalcount, Func<TG, bool> where, Func<TG, T> orderBy, bool desc)
        {
            ObjectContext context = ((IObjectContextAdapter)Db).ObjectContext;

            var temp = context.CreateObjectSet<TG>().Where(where);
            totalcount = temp.Count();
            if (desc)
            {
                temp = temp.OrderByDescending<TG, T>(orderBy)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);
            }
            else
            {
                temp = temp.OrderBy<TG, T>(orderBy)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);
            }
            return temp.AsQueryable();
        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Modified(TG entity)
        {
            if (entity != null)
            {
                Db.Entry(entity).State = EntityState.Modified;
                return Db.SaveChanges() > 0;
            }
            return false;
        }
    }
}