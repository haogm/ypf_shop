using System.Web.Mvc;
using log4net;

namespace WebApp.Portal.Models
{
    /// <summary>
    /// 自定义全局过滤器
    /// </summary>
    public class MyHandlerExceptionAttribute:HandleErrorAttribute
    {
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //记录错误信息
            LogHelper.WriteLog("我是过滤器邪恶", filterContext.Exception);
            //让当前请求 跳转到首页，或者错误页面
            filterContext.HttpContext.Response.Redirect("/Error.html");
        }
    }
}