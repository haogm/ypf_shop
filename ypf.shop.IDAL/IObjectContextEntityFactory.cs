using System.Data.Entity;

namespace ypf.shop.IDAL
{
    /// <summary>
    /// 线程数据槽内的上下文工厂接口
    /// </summary>
    public interface IObjectContextEntityFactory
    {
        DbContext CreateEntity();
    }
}