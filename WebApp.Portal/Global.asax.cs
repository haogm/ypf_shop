using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApp.Portal.Models;

namespace WebApp.Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //初始化log4net配置
            log4net.Config.XmlConfigurator.Configure();
            GlobalFilters.Filters.Add(new MyHandlerExceptionAttribute());//注册全局的自定义过滤器
        }
    }
}
