using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.WIR;
using CCS.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Wires.Controllers
{
    public class WIR01Controller : BaseController
    {
        CCSservice ccsService = new CCSservice();

        [Dependency]
        public Ics_wiresBLL wiresBLL { get; set; }

        [Dependency]
        public Ics_wires_journalBLL wiresjournalBLL { get; set; }


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
            try
            {
                List<cs_wiresModel> list = wiresBLL.GetList(ref pager, queryStr);
                var json = new
                {
                    total = pager.totalRows,
                    rows = (from r in list
                            select new cs_wiresModel()
                            {

                                Id = r.Id,
                                WIRE_ID = r.WIRE_ID,
                                CS_WIRE_ID = r.CS_WIRE_ID,
                                STOCK_DATE = r.STOCK_DATE,
                                RAWMTRL = r.RAWMTRL,
                                DIAMETER = r.DIAMETER,
                                ORG_DIAMETER = r.ORG_DIAMETER,
                                HEAT_NO = r.HEAT_NO,
                                WEIGHT = r.WEIGHT,
                                STAND_WEIGTH = r.STAND_WEIGTH,
                                ANNEAL = r.ANNEAL,
                                MARK = r.MARK,
                                MARK_NM = r.MARK_NM,
                                PROCESS_FACTORY = r.PROCESS_FACTORY,
                                TYPE = r.TYPE,
                                TYPE_NM = r.TYPE_NM,
                                REMARK = r.REMARK

                            }).ToArray()

                };

                return MyJson(json,"yyyy-MM-dd");
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        // 線材異動 - Datagrid子明細
        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetDetailsList(GridPager pager, string queryStr)
        {
            pager.rows = 999999;
            pager.page = 1;
            pager.sort = "WIRE_ID";
            pager.order = "desc";

            List<cs_wires_journalModel> list = wiresjournalBLL.GetList(ref pager, queryStr);
            var json = (from r in list
                        select new cs_wires_journalModel()
                        {
                            Id = r.Id,
                            WIRE_ID = r.WIRE_ID,
                            TRANS_CODE = r.TRANS_CODE,
                            TRANS_DATE = r.TRANS_DATE,
                            WEIGHT = r.WEIGHT
                        });


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
        public JsonResult Create(cs_wiresModel model)
        {
            model.Id = ResultHelper.NewId;
            model.WIRE_ID= ResultHelper.NewOrdId("WIR", "W"); // 取單號
            model.ANNEAL = false;
            model.EXC_INSDATE = ResultHelper.NowTime;
            model.EXC_INSDBID = GetUserId();
            model.EXC_UPDDATE = ResultHelper.NowTime;
            model.EXC_UPDDBID = GetUserId();

            if (model != null && ModelState.IsValid)
            {

                if (wiresBLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",WIRE_ID:" + model.WIRE_ID, "成功", "創建", "CS_WIRES");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",WIRE_ID:" + model.WIRE_ID + "," + ErrorCol, "失敗", "創建", "CS_WIRES");
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
            cs_wiresModel entity = wiresBLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_wiresModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.EXC_UPDDATE = ResultHelper.NowTime;
                model.EXC_UPDDBID = GetUserId();

                if (wiresBLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",WIRE_ID:" + model.WIRE_ID, "成功", "修改", "CS_WIRES");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",WIRE_ID:" + model.WIRE_ID + "," + ErrorCol, "失敗", "修改", "CS_WIRES");
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
            cs_wiresModel entity = wiresBLL.GetById(id);
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
                if (wiresBLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "CS_WIRES");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id + "," + ErrorCol, "失敗", "刪除", "CS_WIRES");
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
