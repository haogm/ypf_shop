using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ypf.shop.Model;

namespace ypf.shop.BLL.test
{
    [TestClass]
    public class UserInfoServiceTest
    {
        [TestMethod]
        public void Add()
        {
            UserInfoService userInfoService=new UserInfoService();
            UserInfo userInfo = new UserInfo()
            {
                DeleteFlag = 1,
                Email = "ypf@126.com",
                LoginCode = "ypf",
                ModifiedDateTime = DateTime.Now,
                Password = "123123"
          ,
                Remark = "test data",
                SubmitDateTime = DateTime.Now,
                UserName = "yangpengfei",
                UserStatus = 1
            };
            Assert.AreEqual(true, userInfoService.Add(userInfo)); 
        }
    }
}
