using ypf.shop.IBLL;
using ypf.shop.Model;

namespace ypf.shop.BLL
{
    public class ProductService : BaseService<Product>, IProductService
    {

        /// <summary>
        /// 设置父类的仓储类型
        /// </summary>
        protected override void SetCurrentRepository()
        {
            this.CurrentRepository = DbSessionContext.ProductRepository;
        }
    }
}