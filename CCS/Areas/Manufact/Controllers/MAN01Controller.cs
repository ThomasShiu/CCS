using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.MAN;
using CCS.Models.SAL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Manufact.Controllers
{
    public class MAN01Controller : BaseController
    {
        [Dependency]
        public Ics_momtBLL cs_momt_BLL { get; set; }

        [Dependency]
        public Ics_codlBLL cs_codlBLL { get; set; }
        ValidationErrors errors = new ValidationErrors();

        public ActionResult Index()
        {
            return View();
        }

        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<cs_momtModel> list = cs_momt_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_momtModel()
                        {

                            Id = r.Id,
                            VCH_NO = r.VCH_NO,
                            VCH_DT = r.VCH_DT,
                            FA_NO = r.FA_NO,
                            ITEM_NO = r.ITEM_NO,
                            IMG_NO = r.IMG_NO,
                            PLAN_BDT = r.PLAN_BDT,
                            PLAN_EDT = r.PLAN_EDT,
                            PLAN_QTY = r.PLAN_QTY,
                            CO_NO = r.CO_NO,
                            CO_SR = r.CO_SR,
                            HEAD_MARK = r.HEAD_MARK,
                            RAWMTRL = r.RAWMTRL,
                            DIAMETER = r.DIAMETER,
                            PLATING = r.PLATING,
                            PRCS_NO = r.PRCS_NO,
                            REMK = r.REMK,
                            OWNER_USR_NO = r.OWNER_USR_NO,
                            OWNER_GRP_NO = r.OWNER_GRP_NO,
                            ADD_DT = r.ADD_DT,
                            CFM_USR_NO = r.CFM_USR_NO,
                            MDY_USR_NO = r.MDY_USR_NO,
                            MDY_DT = r.MDY_DT,
                            IP_NM = r.IP_NM,
                            CP_NM = r.CP_NM

                        }).ToArray()

            };

            return Json(json);
        }

        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetCscodlList(string queryStr)
        {
            List<cs_codlModel> list = cs_codlBLL.GetList(queryStr);
            var json = (from r in list
                        select new cs_codlModel()
                        {
                            ID = r.ID,
                            VCH_NO = r.VCH_NO,
                            VCH_SR = r.VCH_SR,
                            ITEM_NO = r.ITEM_NO,
                            ITEM_NM = r.ITEM_NM,
                            ITEM_SP = r.ITEM_SP,
                            CS_ITEM_NO = r.CS_ITEM_NO,
                            UNIT = r.UNIT,
                            QTY = r.QTY,
                            PRC = r.PRC,
                            AMT = r.AMT,
                            PRCV_DT = r.PRCV_DT,
                            C_CLS = r.C_CLS,
                            REMK = r.REMK

                        }).ToArray();

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
        public JsonResult Create(cs_momtModel model)
        {
            model.Id = ResultHelper.NewId;
            //model.CreateTime = ResultHelper.NowTime;

            if (model != null && ModelState.IsValid)
            {

                if (cs_momt_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",單號:" + model.VCH_NO, "成功", "創建", "CS_MOMT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",單號:" + model.VCH_NO + "," + ErrorCol, "失敗", "創建", "CS_MOMT");
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
            cs_momtModel entity = cs_momt_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_momtModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                if (cs_momt_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",單號:" + model.VCH_NO, "成功", "修改", "CS_MOMT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",單號:" + model.VCH_NO + "," + ErrorCol, "失敗", "修改", "CS_MOMT");
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
            cs_momtModel entity = cs_momt_BLL.GetById(id);
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
                if (cs_momt_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "CS_MOMT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失敗", "刪除", "CS_MOMT");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }


        }
        #endregion
    }
}
