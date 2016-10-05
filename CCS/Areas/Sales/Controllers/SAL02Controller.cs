using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.SAL;
using CCS.Models.SYS;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Sales.Controllers
{
    [UserTraceLog]
    public class SAL02Controller : BaseController
    {
        // GET: Sales/SAL02
        [Dependency]
        public Ics_codlBLL m_BLL { get; set; }

        [Dependency]
        public Ics_comtBLL comt_BLL { get; set; }

        ValidationErrors errors = new ValidationErrors();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<cs_codlModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
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

                        }).ToArray()

            };

            return Json(json);
        }

        #region 訂單主明細檔
        [SupportFilter(ActionName ="Index")]
        public ActionResult MasterDetails(string id)
        {
            ViewBag.Perm = GetPermission();
            cs_comtModel entity = comt_BLL.GetById(id);  //主檔，明細由JSON取得
            return View(entity);
        }
        #endregion



        #region 創建
        [SupportFilter]
        public ActionResult Create(string ID)
        {
            ViewBag.Perm = GetPermission();
            ViewBag.vch_no = ID;
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(cs_codlModel model)
        {
            //model.ID = ResultHelper.NewId;
            AccountModel account = (AccountModel)Session["Account"];

            model.ADD_DT = DateTime.Now;
            model.MDY_DT = DateTime.Now;
            model.MDY_USR_NO = account.Id;
            model.CFM_USR_NO = account.Id;
            model.IP_NM = HttpContext.Request.UserHostAddress;
            model.CP_NM = HttpContext.Request.UserHostName;

            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "ID" + model.ID + ",VCH_NO" + model.VCH_NO, "成功", "創建", "CS_CODL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "ID" + model.ID + ",VCH_NO" + model.VCH_NO + "," + ErrorCol, "失敗", "創建", "CS_CODL");
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
        public ActionResult Edit(int id)
        {
            ViewBag.Perm = GetPermission();
            cs_codlModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_codlModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "ID" + model.ID + ",VCH_NO" + model.VCH_NO, "成功", "修改", "CS_CODL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "ID" + model.ID + ",VCH_NO" + model.VCH_NO + "," + ErrorCol, "失敗", "修改", "CS_CODL");
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
        public ActionResult Details(int id)
        {
            ViewBag.Perm = GetPermission();
            cs_codlModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 刪除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(int id)
        {
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "CS_CODL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "ID" + id + "," + ErrorCol, "失敗", "刪除", "CS_CODL");
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
