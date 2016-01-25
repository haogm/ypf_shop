using ypf.shop.DAL;
using ypf.shop.IBLL;
using ypf.shop.IDAL;
using ypf.shop.Model;

namespace ypf.shop.BLL
{
    public class UserInfoService : BaseService<UserInfo>, IUserService
    {
        /// <summary>
        /// 设置父类的仓储类型
        /// </summary>
        protected override void SetCurrentRepository()
        {
            this.CurrentRepository = DbSessionContext.UserInfoRepository;
        }
    }
}