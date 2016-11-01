using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models.MAN;
using CCS.Models.PUB;
using CCS.Models.WIR;
using CCS.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
 * 線材領用
 */
namespace CCS.Areas.Wires.Controllers
{
    public class WIR02Controller : BaseController
    {
        private DropListService dls;
        public WIR02Controller(DropListService dls)
        {
            this.dls = dls;
        }

        [Dependency]
        public Ics_wireReciptBLL m_BLL { get; set; }

        [Dependency]
        public Ics_momtBLL csmomt_BLL { get; set; }

        [Dependency]
        public Ics_wiresBLL cswires_BLL { get; set; }


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
            GridPager pager2 = new GridPager
            {
                rows = 999999,
                page = 1,
                order = "desc"
            };

        List<itemModel> itemlist = item_BLL.GetList(queryStr); // 料品主檔
            itemlist = (from r in itemlist
                        where r.ITEM_NO.StartsWith("6")
                        select new itemModel
                        {
                            ITEM_NO = r.ITEM_NO,
                            ITEM_NM = r.ITEM_NM,
                            ITEM_SP = r.ITEM_SP
                        }).ToList();

            pager2.sort = "VCH_NO";
            List<cs_momtModel> momtlist = csmomt_BLL.GetList(ref pager2, queryStr); // 製令
            pager2.sort = "WIRE_ID";
            List<cs_wiresModel> wirelist = cswires_BLL.GetList(ref pager2, queryStr); // 線材

            List<cs_wire_reciptModel> list = m_BLL.GetList(ref pager, queryStr); // 線材領用

            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        from r1 in momtlist
                        from r2 in wirelist
                        from r3 in itemlist
                        where r.MO_VCH_NO == r1.VCH_NO 
                        &&    r.WIRE_ID == r2.WIRE_ID
                        &&    r1.ITEM_NO == r3.ITEM_NO.TrimEnd()
                        select new cs_wire_reciptModel()
                        {
                            Id = r.Id,
                            MO_VCH_NO = r.MO_VCH_NO,
                            ITEM_NO = r1.ITEM_NO,
                            ITEM_NM = r3.ITEM_NM,
                            RAWMTRL = r2.RAWMTRL,
                            DIAMETER = r2.DIAMETER,
                            HEAT_NO = r2.HEAT_NO,
                            WIRE_ID = r.WIRE_ID,
                            WEIGHT = r.WEIGHT,
                            REC_DATE = r.REC_DATE,
                            REC_EMP = r.REC_EMP,
                            RECIPT_TY = r.RECIPT_TY
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
        public JsonResult Create(cs_wire_reciptModel model)
        {
            model.Id = ResultHelper.NewId;
            model.EXC_INSDATE = ResultHelper.NowTime;
            model.EXC_INSDBID = GetUserId();
            model.EXC_UPDDATE = ResultHelper.NowTime;
            model.EXC_UPDDBID = GetUserId();

            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",MO_VCH_NO" + model.MO_VCH_NO, "成功", "創建", "CS_WIRE_RECIPIENT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",MO_VCH_NO" + model.MO_VCH_NO + "," + ErrorCol, "失敗", "創建", "CS_WIRE_RECIPIENT");
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
            cs_wire_reciptModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_wire_reciptModel model)
        {
            model.EXC_UPDDATE = ResultHelper.NowTime;
            model.EXC_UPDDBID = GetUserId();

            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",MO_VCH_NO" + model.MO_VCH_NO, "成功", "修改", "CS_WIRE_RECIPIENT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",MO_VCH_NO" + model.MO_VCH_NO + "," + ErrorCol, "失敗", "修改", "CS_WIRE_RECIPIENT");
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
            cs_wire_reciptModel entity = m_BLL.GetById(id);
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
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "CS_WIRE_RECIPIENT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失敗", "刪除", "CS_WIRE_RECIPIENT");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }


        }
        #endregion

        #region 製令(未結案)，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetMomtList(GridPager pager, string queryStr)
        {
            pager.rows = 999999;
            pager.page = 1;
            pager.sort = "VCH_NO";
            pager.order = "desc";

            List<itemModel> itemlist = item_BLL.GetList(queryStr); // 料品主檔
            itemlist = (from r in itemlist
                        where r.ITEM_NO.StartsWith("6")
                        select new itemModel
                        {
                            ITEM_NO = r.ITEM_NO,
                            ITEM_NM = r.ITEM_NM,
                            ITEM_SP = r.ITEM_SP
                        }).ToList();

            List<cs_momtModel> list = csmomt_BLL.GetList(ref pager, queryStr);
            var model =  (from r in list
                          from r1 in itemlist
                          where r.PRCS_NO == "F" //成型才需領線
                          && r.C_CLS == "N"      // 未結案
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

        #region 線材(未結案)，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetWiresList(GridPager pager, string queryStr)
        {
            pager.rows = 999999;
            pager.page = 1;
            pager.sort = "WIRE_ID";
            pager.order = "desc";

            var list = dls.GetWiresList( pager, queryStr).ToList();
            
 
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 員工列表，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetEmpList(String queryStr)
        {
            queryStr = "C_SFC";
            var list = dls.GetEmpList(queryStr);
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}
