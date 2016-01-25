using System;
using System.Linq;

namespace ypf.shop.IBLL
{
    public interface IBaseService<TG> where TG : class, new()
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(TG entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Modified(TG entity);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">用户</param>
        /// <returns></returns>
        bool Add(TG entity);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IQueryable<TG> Load(Func<TG, bool> where);

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
        IQueryable<TG> LoadPages<T>(int pageIndex, int pageSize, out int totalcount, Func<TG, bool> where,
            Func<TG, T> orderBy, bool desc);


    }
}