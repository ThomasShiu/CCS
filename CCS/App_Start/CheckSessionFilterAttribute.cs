using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CCS.App_Start
{
    public class CheckSessionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext httpcontext = HttpContext.Current;
            // 確認目前要求的HttpSessionState
            if (httpcontext.Session != null)
            {
                //確認Session是否為新建立
                if (httpcontext.Session.IsNewSession)
                {
                    //確認是否已存在cookies
                    String sessioncookie = httpcontext.Request.Headers["Cookie"];
                    if ((sessioncookie != null) && (sessioncookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        Login(filterContext);
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }

        private void Login(ActionExecutingContext filterContext)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary
                (new
                {
                    controller = "Account",
                    action = "Login",
                    area = "",
                    returnUrl = filterContext.HttpContext.Request.RawUrl
                });
            filterContext.Result = new RedirectToRouteResult(dictionary);
            //filterContext.Result = new RedirectResult("http://externalSite.com/login?returnUrl=" + filterContext.HttpContext.Request.RawUrl);
        }
    }
}