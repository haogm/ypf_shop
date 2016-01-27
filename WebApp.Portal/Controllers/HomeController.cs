using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using WebApp.Portal.Models;

namespace WebApp.Portal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                int a = 0;
                int b = 1;
                int c = b / a;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Home控制器中try进行捕获异常",ex);//捕获到异常进行记录
            }
            int d = 0;
            int e = 1;
            int f = e / d;//没有捕获到的，采取全局过滤器进行异常捕获处理


            return View();
        }
    }
}