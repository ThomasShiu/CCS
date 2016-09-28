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
 * 系統日誌
 * 
 */
namespace CCS.Areas.System.Controllers
{
    [UserTraceLog]
    public class SYS01Controller : BaseController
    {
        // GET: Admin/ADM01

        [Dependency]
        public Ics_syslogBLL logBLL { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<CS_SYSLOG> list = logBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_syslogModel()
                        {

                            Id = r.Id,
                            Operator = r.Operator,
                            Message = r.Message,
                            Result = r.Result,
                            Type = r.Type,
                            Module = r.Module,
                            CreateTime = r.CreateTime

                        }).ToArray()

            };

            return Json(json);
        }


        #region 詳細

        public ActionResult Details(string id)
        {

            CS_SYSLOG entity = logBLL.GetById(id);
            cs_syslogModel info = new cs_syslogModel()
            {
                Id = entity.Id,
                Operator = entity.Operator,
                Message = entity.Message,
                Result = entity.Result,
                Type = entity.Type,
                Module = entity.Module,
                CreateTime = entity.CreateTime,
            };
            return View(info);
        }

        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (logBLL.Delete(id))
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion


      
    }
}