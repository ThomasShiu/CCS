using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.INV;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Sales.Controllers
{
    public class SAL05Controller : BaseController
    {
        // GET: Sales/SAL05 銷貨單明細檔

        [Dependency]
        public Ics_shipdlBLL m_BLL { get; set; }

        ValidationErrors errors = new ValidationErrors();

        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        #region 訂單主明細檔
        [SupportFilter(ActionName = "Index")]
        public ActionResult MasterDetails(string id)
        {
            ViewBag.Perm = GetPermission();
            cs_shipdlModel entity = m_BLL.GetById(id);  //主檔，明細由JSON取得
            return View(entity);
        }
        #endregion

        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<cs_shipdlModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_shipdlModel()
                        {

                            Id = r.Id,
                            VCH_NO = r.VCH_NO,
                            VCH_SR = r.VCH_SR,
                            ITEM_NO = r.ITEM_NO,
                            ITEM_NM = r.ITEM_NM,
                            ITEM_SP = r.ITEM_SP,
                            RAWMTRL = r.RAWMTRL,
                            HEAT_NO = r.HEAT_NO,
                            KEG_CNT = r.KEG_CNT,
                            UNIT_WT = r.UNIT_WT,
                            NET_WEIGHT = r.NET_WEIGHT,
                            GROSS_WEIGHT = r.GROSS_WEIGHT,
                            COUNT_QTY = r.COUNT_QTY,
                            PRC = r.PRC,
                            AMT = r.AMT,
                            END_CODE = r.END_CODE,
                            CS_ORDER_NO = r.CS_ORDER_NO,
                            REMK = r.REMK,
                            EXC_INSDBID = r.EXC_INSDBID,
                            EXC_INSDATE = r.EXC_INSDATE,
                            EXC_UPDDBID = r.EXC_UPDDBID,
                            EXC_UPDDATE = r.EXC_UPDDATE,
                            EXC_SYSOWNR = r.EXC_SYSOWNR,
                            EXC_ISLOCKED = r.EXC_ISLOCKED,
                            EXC_COMPANY = r.EXC_COMPANY,
                            STATUS = r.STATUS

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
        public JsonResult Create(cs_shipdlModel model)
        {
            model.Id = ResultHelper.NewId;
            model.EXC_INSDATE = ResultHelper.NowTime;
            model.EXC_INSDBID = GetUserId();
            model.EXC_UPDDATE = ResultHelper.NowTime;
            model.EXC_UPDDBID = GetUserId();
            //model.CreateTime = ResultHelper.NowTime;
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",VCH_NO:" + model.VCH_NO, "成功", "創建", "CS_SHIPDL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",VCH_NO:" + model.VCH_NO + "," + ErrorCol, "失敗", "創建", "CS_SHIPDL");
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
            cs_shipdlModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_shipdlModel model)
        {
            model.EXC_UPDDATE = ResultHelper.NowTime;
            model.EXC_UPDDBID = GetUserId();
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",VCH_NO:" + model.VCH_NO, "成功", "修改", "CS_SHIPDL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",VCH_NO:" + model.VCH_NO + "," + ErrorCol, "失敗", "修改", "CS_SHIPDL");
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
            cs_shipdlModel entity = m_BLL.GetById(id);
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
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "CS_SHIPDL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失敗", "刪除", "CS_SHIPDL");
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