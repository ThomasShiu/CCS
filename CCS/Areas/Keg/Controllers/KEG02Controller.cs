using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.KEG;
using CCS.Models.PUB;
using CCS.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Keg.Controllers
{
    public class KEG02Controller : BaseController
    {
        private DropListService dls;
        public KEG02Controller(DropListService dls)
        {
            this.dls = dls;
        }

        [Dependency]
        public Ics_kegs_csBLL m_BLL { get; set; }
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
            List<cs_kegs_csModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        where r.TRANS_CODE=="I"
                        select new cs_kegs_csModel()
                        {

                            Id = r.Id,
                            CS_NO = r.CS_NO,
                            CS_NM = r.CS_NM,
                            KEG_NM = r.KEG_NM,
                            TRANS_DATE = r.TRANS_DATE,
                            TRANS_CODE = r.TRANS_CODE,
                            CNT = r.CNT,
                            REMARK = r.REMARK,
                            C_CLS = r.C_CLS,
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
        public JsonResult Create(cs_kegs_csModel model)
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
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",CS_NO" + model.CS_NO, "成功", "創建", "CS_KEGS_CS");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",CS_NO" + model.CS_NO + "," + ErrorCol, "失敗", "創建", "CS_KEGS_CS");
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
            cs_kegs_csModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_kegs_csModel model)
        {
            model.EXC_UPDDATE = ResultHelper.NowTime;
            model.EXC_UPDDBID = GetUserId();

            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",CS_NO" + model.CS_NO, "成功", "修改", "CS_KEGS_CS");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",CS_NO" + model.CS_NO + "," + ErrorCol, "失敗", "修改", "CS_KEGS_CS");
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
            cs_kegs_csModel entity = m_BLL.GetById(id);
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
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "CS_KEGS_CS");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失敗", "刪除", "CS_KEGS_CS");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }

        }
        #endregion

        #region 客戶列表，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetCustList(String queryStr)
        {

            List<customerModel> list = dls.GetCustList(queryStr).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }

}