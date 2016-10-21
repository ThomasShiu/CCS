using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.MAN;
using CCS.Models.PUB;
using CCS.Models.WIR;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
 * 成型-生產記錄
 */
namespace CCS.Areas.Manufact.Controllers
{
    public class MAN02Controller : BaseController
    {
        [Dependency]
        public Ics_wipfBLL m_BLL { get; set; }

        [Dependency]
        public Ics_momtBLL csmomt_BLL { get; set; }

        [Dependency]
        public Ics_wireReciptBLL cswireRecipt_BLL { get; set; }

        [Dependency]
        public IEMPNOBLL empno_BLL { get; set; }

        [Dependency]
        public IitemBLL item_BLL { get; set; }

        ValidationErrors errors = new ValidationErrors();

        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<cs_wipfModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_wipfModel()
                        {
                            Id = r.Id,
                            LOT_NO = r.LOT_NO,
                            HEAT_NO = r.HEAT_NO,
                            KEG_NO = r.KEG_NO,
                            PRCS_TY = r.PRCS_TY,
                            PRCS_NO = r.PRCS_NO,
                            EMP_NO = r.EMP_NO,
                            EMP_NM = r.EMP_NM,
                            MACHINE = r.MACHINE,
                            BDT = r.BDT,
                            EDT = r.EDT,
                            WEIGHT = r.WEIGHT,
                            UNIT_WT = r.UNIT_WT,
                            COUNT_QTY = r.COUNT_QTY,
                            END_CODE = r.END_CODE,
                            EXC_INSDBID = r.EXC_INSDBID,
                            EXC_INSDATE = r.EXC_INSDATE,
                            EXC_UPDDBID = r.EXC_UPDDBID,
                            EXC_UPDDATE = r.EXC_UPDDATE,
                            EXC_SYSOWNR = r.EXC_SYSOWNR,
                            EXC_ISLOCKED = r.EXC_ISLOCKED,
                            EXC_COMPANY = r.EXC_COMPANY

                        }).ToArray()

            };

            return Json(json);
        }

        #region 創建
        [SupportFilter]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(cs_wipfModel model)
        {

            model.Id = ResultHelper.NewId;
            model.EXC_INSDBID = GetUserId();
            model.EXC_INSDATE = DateTime.Now;
            model.EXC_UPDDBID = GetUserId();
            model.EXC_UPDDATE = DateTime.Now;
            //model.EXC_ISLOCKED = GetUserId();
            model.EXC_COMPANY = "CCS";

            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",LOT_NO:" + model.LOT_NO, "成功", "創建", "CS_WIP_F");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",LOT_NO:" + model.LOT_NO + "," + ErrorCol, "失敗", "創建", "CS_WIP_F");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
            }
        }
        #endregion

        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            cs_wipfModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_wipfModel model)
        {
            model.EXC_UPDDBID = GetUserId();
            model.EXC_UPDDATE = DateTime.Now;

            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {

                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",LOT_NO:" + model.LOT_NO, "成功", "修改", "CS_WIP_F");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",LOT_NO:" + model.LOT_NO + "," + ErrorCol, "失敗", "修改", "CS_WIP_F");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail));
            }
        }
        #endregion

        #region 詳細
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Perm = GetPermission();
            cs_wipfModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 刪除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "CS_WIP_F");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id + "," + ErrorCol, "失敗", "刪除", "CS_WIP_F");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }


        }
        #endregion

        #region 有領料製令(未結案)，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetMomtList(GridPager pager, string queryStr)
        {
            pager.rows = 999999;
            pager.page = 1;
            pager.order = "desc";

            List<itemModel> itemlist = item_BLL.GetList(queryStr); // 料品主檔
            //itemlist = (from r in itemlist
            //            where r.ITEM_NO.StartsWith("6")
            //            select new itemModel
            //            {
            //                ITEM_NO = r.ITEM_NO,
            //                ITEM_NM = r.ITEM_NM,
            //                ITEM_SP = r.ITEM_SP
            //            }).ToList();

            pager.sort = "VCH_NO";
            List<cs_momtModel> list = csmomt_BLL.GetList(ref pager, queryStr);  //製令

             var model = (from r in list
                          from r1 in itemlist
                         where  r.C_CLS == "N"      // 未結案
                         && r.ITEM_NO == r1.ITEM_NO.TrimEnd()
                         select new cs_momtModel()
                         {
                             Id = r.Id,
                             VCH_NO = r.VCH_NO,
                             VCH_DT = r.VCH_DT,
                             FA_NO = r.FA_NO,
                             ITEM_NO = r.ITEM_NO,
                             ITEM_NM = r1.ITEM_NM,
                             IMG_NO = r.IMG_NO,
                             PLAN_BDT = r.PLAN_BDT,
                             PLAN_EDT = r.PLAN_EDT,
                             PLAN_QTY = r.PLAN_QTY,
                             CO_NO = r.CO_NO,
                             CO_SR = r.CO_SR,
                             HEAD_MARK = r.HEAD_MARK,
                             THREAD = r.THREAD,
                             RAWMTRL = r.RAWMTRL,
                             DIAMETER = r.DIAMETER,
                             HEAT_NO = r.HEAT_NO,
                             PLATING = r.PLATING,
                             PRCS_NO = r.PRCS_NO,
                             REMK = r.REMK

                         }).ToArray();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 員工列表，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetEmpList(String queryStr)
        {
            queryStr = "C_SFC";  // 現場操作人員
            List<empnoModel> list = empno_BLL.GetList(queryStr);
            var model = (from r in list
                         select new empnoModel()
                         {
                             EMP_NO = r.EMP_NO,
                             EMP_NM = r.EMP_NM,
                             DEPM_NO = r.DEPM_NO
                         }).ToArray();
            return Json(model, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}