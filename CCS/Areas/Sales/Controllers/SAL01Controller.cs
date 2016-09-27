using CCS.App_Start;
using CCS.Common;
using CCS.IBLL;
using CCS.Models;
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
    public class SAL01Controller : Controller
    {

        ValidationErrors errors = new ValidationErrors();
        public AccountModel account = new AccountModel();
       

        /// <summary>
        /// 業務層注入
        /// </summary>
        [Dependency]
        public Ics_comtBLL m_BLL { get; set; }

        // GET: Sales/SAL01
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CS_COMT()
        {
            //List<cs_comtModel> list = m_BLL.GetList("");
            return View();
        }

        [HttpPost]
        public JsonResult GetList(GridPager pager,String queryStr)
        {
            //int total = pager.totalRows;
            List<cs_comtModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_comtModel()
                        {

                            VCH_NO = r.VCH_NO,
                            VCH_DT_STR = r.VCH_DT.ToShortDateString(),
                            CS_NO = r.CS_NO,
                            CURRENCY = r.CURRENCY,
                            C_CFM = r.C_CFM

                        }).ToArray()
            };

            return Json(json, JsonRequestBehavior.AllowGet);

        }

        #region 創建
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(cs_comtModel model)
        {

            account.Id = "admin";
            account.TrueName = "admin";
            Session["Account"] = account;

            if (m_BLL.Create(ref errors, model))
            {
                LogHandler.WriteServiceLog("虛擬用戶", "Id:" + account.Id + ",Name:" + account.TrueName, "成功", "創建", "範例程序");
                return Json(JsonHandler.CreateMessage(1, "新增成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虛用戶", "Id:" + account.Id + ",Name:" + account.TrueName + "," + ErrorCol, "失敗", "創建", "範例程序");
                return Json(JsonHandler.CreateMessage(0, "新增失敗" + ErrorCol), JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 修改

        public ActionResult Edit(string id)
        {

            cs_comtModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public JsonResult Edit(cs_comtModel model)
        {
            account.Id = "admin";
            account.TrueName = "admin";
            Session["Account"] = account;

            if (m_BLL.Edit(ref errors, model))
            {
                LogHandler.WriteServiceLog("虛擬用戶", "Id:" + account.Id + ",Name:" + account.TrueName, "成功", "編輯", "範例程序");
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虛用戶", "Id:" + account.Id + ",Name:" + account.TrueName + "," + ErrorCol, "失敗", "編輯", "範例程序");
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 詳細
        public ActionResult Details(string id)
        {
            cs_comtModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            account.Id = "admin";
            account.TrueName = "admin";
            Session["Account"] = account;

            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog("虛擬用戶", "Id:" + account.Id + ",Name:" + account.TrueName, "成功", "刪除", "範例程序");
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog("虛用戶", "Id:" + account.Id + ",Name:" + account.TrueName + "," + ErrorCol, "失敗", "刪除", "範例程序");
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