using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.PUB;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Inventory.Controllers
{
    public class INV01Controller : BaseController
    {
        // GET: Inventory/INV01
        [Dependency]
        public IitemBLL m_BLL { get; set; }

        ValidationErrors errors = new ValidationErrors();

        [SupportFilter]
        public ActionResult Index()
        {
            return View();
        }

        [SupportFilter(ActionName ="Index")]
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<itemModel> itemlist = m_BLL.GetList(ref pager, queryStr);
            //itemlist = (from r in itemlist
            //            where r.ITEM_NO.StartsWith("6")
            //            select new itemModel
            //            {
            //                ITEM_NO = r.ITEM_NO,
            //                ITEM_NM = r.ITEM_NM,
            //                ITEM_SP = r.ITEM_SP
            //            }).ToList();
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in itemlist
                        select new itemModel()
                        {

                            ITEM_NO = r.ITEM_NO,
                            ITEM_NM = r.ITEM_NM,
                            ITEM_SP = r.ITEM_SP,
                            ITEM_NM_E = r.ITEM_NM_E,
                            ITEM_SP_E = r.ITEM_SP_E,
                            ITEM_NO_O = r.ITEM_NO_O,
                            C_STA = r.C_STA,
                            ADD_DT = r.ADD_DT,
                            MDY_USR_NO = r.MDY_USR_NO,
                            MDY_DT = r.MDY_DT,
                            IP_NM = r.IP_NM,
                            CP_NM = r.CP_NM

                        }).ToArray()

            };
            return MyJson(json, "yyyy-MM-dd");
            //return Json(json);
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
        public JsonResult Create(itemModel model)
        {
            //model.Id = ResultHelper.NewId;
            //model.CreateTime = ResultHelper.NowTime;
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "ITEM_NO:" + model.ITEM_NO + ",ITEM_NM:" + model.ITEM_NM, "成功", "創建", "Admin");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "ITEM_NO:" + model.ITEM_NO + ",ITEM_NM:" + model.ITEM_NM + "," + ErrorCol, "失敗", "創建", "Admin");
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
            itemModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(itemModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "ITEM_NO:" + model.ITEM_NO + ",ITEM_NM:" + model.ITEM_NM, "成功", "修改", "Admin");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "ITEM_NO:" + model.ITEM_NO + ",ITEM_NM:" + model.ITEM_NM + "," + ErrorCol, "失敗", "修改", "Admin");
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
            itemModel entity = m_BLL.GetById(id);
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
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "Admin");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "ITEM_NO" + id + "," + ErrorCol, "失敗", "刪除", "Admin");
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