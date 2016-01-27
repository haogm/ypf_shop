using System;
using System.Linq;
using ypf.shop.DAL;
using ypf.shop.IDAL;

namespace ypf.shop.BLL
{
    public abstract class BaseService<TG> where TG : class, new()
    {
        private IDbSessionContext _dbSessionContext;
        /// <summary>
        /// 数据访问入口
        /// </summary>
        public IDbSessionContext DbSessionContext
        {
            get
            {
                if (_dbSessionContext == null)
                {
                    _dbSessionContext = new DbSessionContextFactory().CreateDbSessionContext();
                    return _dbSessionContext;
                }
                return _dbSessionContext;
            }
            set { _dbSessionContext = value; }
        }
        /// <summary>
        /// 设置当前仓储实例类型(设置这个抽象方法就是为了让子类给父类指定类型仓储)
        /// </summary>
        protected abstract void SetCurrentRepository();


        /// <summary>
        /// 当前仓储实例
        /// </summary>
        public IBaseRepository<TG> CurrentRepository { get; set; }

        protected BaseService()
        {
            SetCurrentRepository();//在构造函数中调用虚拟方法就是为了让子类来指定类型仓储
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Delete(TG entity)
        {
            return CurrentRepository.Delete(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Modified(TG entity)
        {
            return CurrentRepository.Modified(entity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">用户</param>
        /// <returns></returns>
        public virtual bool Add(TG entity)
        {
            return CurrentRepository.Delete(entity);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IQueryable<TG> Load(Func<TG, bool> where)
        {
            return CurrentRepository.Load(where);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">按类型排序</typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="totalcount">总条数</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="desc">是降序</param>
        /// <returns></returns>
        public virtual IQueryable<TG> LoadPages<T>(int pageIndex, int pageSize, out int totalcount, Func<TG, bool> where,
            Func<TG, T> orderBy, bool desc)
        {
            return CurrentRepository.LoadPages(pageIndex, pageSize, out totalcount, where, orderBy, desc);
        }

    }
}