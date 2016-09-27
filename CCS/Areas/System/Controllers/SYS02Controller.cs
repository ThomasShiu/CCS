using CCS.App_Start;
using CCS.Common;
using CCS.IBLL;
using CCS.Models;
using CCS.Models.SYS;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
 * 系統錯誤
 * 
 */
namespace CCS.Areas.System.Controllers
{
    [UserTraceLog]
    public class SYS02Controller : Controller
    {
        [Dependency]
        public ISysExceptionBLL exceptionBLL { get; set; }

        // GET: Admin/ADM02
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<CS_SYSEXCEPTION> list = exceptionBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new CS_SYSEXCEPTION()
                        {
                            Id = r.Id,
                            HelpLink = r.HelpLink,
                            Message = r.Message,
                            Source = r.Source,
                            StackTrace = r.StackTrace,
                            TargetSite = r.TargetSite,
                            Data = r.Data,
                            CreateTime = r.CreateTime
                        }).ToArray()

            };
            return Json(json);
        }


        #region 詳細

        public ActionResult Details(string id)
        {

            CS_SYSEXCEPTION entity = exceptionBLL.GetById(id);
            cs_sysexceptionModel info = new cs_sysexceptionModel()
            {
                Id = entity.Id,
                HelpLink = entity.HelpLink,
                Message = entity.Message,
                Source = entity.Source,
                StackTrace = entity.StackTrace,
                TargetSite = entity.TargetSite,
                Data = entity.Data,
                CreateTime = entity.CreateTime,
            };
            return View(info);
        }

        #endregion
    }
}