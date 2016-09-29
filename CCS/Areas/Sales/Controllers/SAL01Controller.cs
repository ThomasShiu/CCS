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
    public class SAL01Controller : BaseController
    {

        ValidationErrors errors = new ValidationErrors();
        public AccountModel account = new AccountModel();
       

        /// <summary>
        /// 業務層注入
        /// </summary>
        [Dependency]
        public Ics_comtBLL comt_BLL { get; set; }

        [Dependency]
        public IcustomerBLL cust_BLL { get; set; }

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
            List<cs_comtModel> list = comt_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_comtModel()
                        {

                            VCH_NO = r.VCH_NO,
                            VCH_DT = r.VCH_DT,
                            FA_NO =r.FA_NO,
                            CS_NO = r.CS_NO,
                            DEPM_NO = r.DEPM_NO,
                            EMP_NO = r.EMP_NO,
                            CURRENCY = r.CURRENCY,
                            C_CFM = r.C_CFM,
                            ITEM_NO = r.ITEM_NO,
                            QTY=r.QTY,
                            UNIT = r.UNIT,
                            PRC = r.PRC,
                            AMT = r.AMT,
                            RCV_QTY = r.RCV_QTY,
                            PL = r.PL

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
            AccountModel account = (AccountModel)Session["Account"];
            //account.Id = "admin";
            //account.TrueName = "admin";
            //Session["Account"] = account;
            model.C_CFM = "Y";
            model.C_CLS = "N";

            if (comt_BLL.Create(ref errors, model))
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

            cs_comtModel entity = comt_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        public JsonResult Edit(cs_comtModel model)
        {
            AccountModel account = (AccountModel)Session["Account"];

            //account.Id = "admin";
            //account.TrueName = "admin";
            //Session["Account"] = account;

            if (comt_BLL.Edit(ref errors, model))
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
            cs_comtModel entity = comt_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            AccountModel account = (AccountModel)Session["Account"];

            //account.Id = "admin";
            //account.TrueName = "admin";
            //Session["Account"] = account;

            if (!string.IsNullOrWhiteSpace(id))
            {
                if (comt_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog("虛擬用戶", "Id:" + account.Id + ",Name:" + account.TrueName, "成功", "刪除", "範例程序");
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog("虛用用戶", "Id:" + account.Id + ",Name:" + account.TrueName + "," + ErrorCol, "失敗", "刪除", "範例程序");
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion

        #region

        //[HttpPost]
        public JsonResult GetCustList()
        {
            String queryStr = "";
            //int total = pager.totalRows;
            List<customerModel> list = cust_BLL.GetList(queryStr);
            var json = (from r in list
                        select new customerModel()
                        {
                            CS_NO = r.CS_NO,
                            SHORT_NM = r.SHORT_NM,
                            ADDR_IVC = r.ADDR_IVC,
                            CONTACTER = r.CONTACTER,
                            TEL_NO = r.TEL_NO,
                            FAX_NO = r.FAX_NO

                        }).ToArray();
           

            return Json(json, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}