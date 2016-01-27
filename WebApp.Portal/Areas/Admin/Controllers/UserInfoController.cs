using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ypf.shop.BLL;
using ypf.shop.Model;

namespace WebApp.Portal.Areas.Admin.Controllers
{
    public class UserInfoController : Controller
    {
        UserInfoService userInfoService = new UserInfoService();
        // GET: Admin/UserInfo
        public ActionResult Index()
        {
            ViewData.Model = userInfoService.Load(u => u.Id > 0);
            return View();
        }

        // GET: Admin/UserInfo/Details/5
        public ActionResult Details(int id)
        {
            ViewData.Model=userInfoService.Load(u => u.Id == id).FirstOrDefault();
            return View();
        }

        // GET: Admin/UserInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserInfo/Create
        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            try
            {
                // TODO: Add insert logic here
                userInfo.DeleteFlag = 1;
                userInfo.LoginCode = "ypftest";
                userInfo.ModifiedDateTime=DateTime.Now;
                userInfo.Password = "123456";
                userInfo.Remark = "提交数据";
                userInfo.SubmitDateTime=DateTime.Now;
                userInfo.UserStatus = 1;
                userInfoService.Add(userInfo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/UserInfo/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData.Model=userInfoService.Load(u => u.Id == id).FirstOrDefault();

            return View();
        }

        // POST: Admin/UserInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserInfo userInfo)
        {
            try
            {
                // TODO: Add update logic here
                var temp=userInfoService.Load(u => u.Id == id).FirstOrDefault();
                temp.UserName = userInfo.UserName;
                temp.Email = userInfo.Email;
                temp.Remark = userInfo.Remark;
                userInfoService.Modified(temp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/UserInfo/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData.Model=userInfoService.Load(u => u.Id == id).FirstOrDefault();
            return View();
        }

        // POST: Admin/UserInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserInfo userInfo )
        {
            try
            {
                // TODO: Add delete logic here
                userInfo.Id = id;
                userInfoService.Delete(userInfo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
