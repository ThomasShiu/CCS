using CCS.IDAL;
using CCS.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CCS.App_Start
{
    public class UserTraceLog : ActionFilterAttribute
    {
        [Dependency]
        public Ics_comtRepository Rep { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.UrlReferrer == null)
                return;
            //ActionLogRepository ActionLog = new ActionLogRepository();
            CCSEntities _db = new CCSEntities();
            CS_ACTIONLOG NewLog = new CS_ACTIONLOG()
            {
                Refer = filterContext.HttpContext.Request.UrlReferrer.AbsolutePath,
                Destination = filterContext.HttpContext.Request.Url.AbsolutePath,
                Method = filterContext.HttpContext.Request.HttpMethod,
                RequestTime = DateTime.Now,
                IPAddress = filterContext.HttpContext.Request.UserHostAddress,
                Operator = (HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name : "Anonymous"),
                Browser = filterContext.HttpContext.Request.Browser.Browser
            };
            _db.CS_ACTIONLOG.Add(NewLog);
            _db.SaveChanges();
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}