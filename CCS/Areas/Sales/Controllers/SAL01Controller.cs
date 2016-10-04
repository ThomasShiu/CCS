using CCS;
using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models;
using CCS.Models.PUB;
using CCS.Models.SAL;
using CCS.Models.SYS;
using CCS.Services;
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
        CCSservice ccsService = new CCSservice();
        ValidationErrors errors = new ValidationErrors();
        public AccountModel account = new AccountModel();
        CCSEntities db = new CCSEntities();

        /// <summary>
        /// 業務層注入
        /// </summary>
        [Dependency]
        public Ics_comtBLL comt_BLL { get; set; }

        [Dependency]
        public IcustomerBLL cust_BLL { get; set; }
        [Dependency]
        public IEMPNOBLL empno_BLL { get; set; }

        // GET: Sales/SAL01
        [SupportFilter]
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
                            FA_NO = r.FA_NO,
                            CS_NO = r.CS_NO,
                            DEPM_NO = r.DEPM_NO,
                            EMP_NO = r.EMP_NO,
                            CS_VCH_NO = r.CS_VCH_NO,
                            CONTACTER = r.CONTACTER,
                            TAX_TY = r.TAX_TY,
                            TAX_RT = r.TAX_RT,
                            PRC_CDT = r.PRC_CDT,
                            PAY_CDT = r.PAY_CDT,
                            TO_ADDR = r.TO_ADDR,
                            TO_ADDR2 = r.TO_ADDR2,
                            CURRENCY = r.CURRENCY,
                            EXCH_RATE = r.EXCH_RATE,
                            WAHO_NO = r.WAHO_NO,
                            LC_NO = r.LC_NO,
                            SHIP_TY = r.SHIP_TY,
                            STR_PORT = r.STR_PORT,
                            DES_PORT = r.DES_PORT,
                            AGT_CORP = r.AGT_CORP,
                            CLR_CORP = r.CLR_CORP,
                            INSP_CORP = r.INSP_CORP,
                            SHIP_CORP = r.SHIP_CORP,
                            MARK_NO = r.MARK_NO,
                            FL_MARK = r.FL_MARK,
                            SL_MARK = r.SL_MARK,
                            CONSIGNEE = r.CONSIGNEE,
                            NOTIFY = r.NOTIFY,
                            DES_PLACE = r.DES_PLACE,
                            BANK_NO = r.BANK_NO,
                            PACK_REMK = r.PACK_REMK,
                            IVC_REMK = r.IVC_REMK,
                            REMK = r.REMK,
                            N_PRT = r.N_PRT,
                            C_SIGN = r.C_SIGN,
                            C_CFM = r.C_CFM,
                            CFM_DT = r.CFM_DT,
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

            return Json(json, JsonRequestBehavior.AllowGet);

        }


        #region 創建
        [SupportFilter]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();  // 權限-功能按鈕
            return View();
        }

        [HttpPost]
        public JsonResult Create(cs_comtModel model)
        {
            AccountModel account = (AccountModel)Session["Account"];
            //account.Id = "admin";
            //account.TrueName = "admin";
            //Session["Account"] = account;
            // 產生單號
            var result = db.SP_GEN_ORDNO("SAL", "S", 1);
            string v_ordno = result.First().FROM_NO;
            model.VCH_NO = v_ordno;
            model.C_CFM = "Y";
            model.ADD_DT = DateTime.Now;
            model.CFM_DT = DateTime.Now;
            model.MDY_DT = DateTime.Now;
            model.MDY_USR_NO = account.Id;
            model.IP_NM = HttpContext.Request.UserHostAddress;
            model.CP_NM = HttpContext.Request.UserHostName;
            model.N_PRT = 0;
            
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
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
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
        [SupportFilter]
        public ActionResult Details(string id)
        {
            cs_comtModel entity = comt_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [SupportFilter]
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

        #region 客戶列表，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetCustList(String queryStr)
        {
            //var model =  ccsService.GetCustList("");
            List<customerModel> list = cust_BLL.GetList(queryStr);
            var model = (from r in list
                         select new customerModel()
                         {
                             CS_NO = r.CS_NO,
                             SHORT_NM = r.SHORT_NM,
                             FULL_NM = r.FULL_NM,
                             ADDR_IVC = r.ADDR_IVC,
                             CONTACTER = r.CONTACTER,
                             TEL_NO = r.TEL_NO,
                             FAX_NO = r.FAX_NO

                         }).ToArray();

            return Json(model, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 員工列表，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetEmpList(String queryStr)
        {
            queryStr = "C_COP";
            //var model =  ccsService.GetCustList("");
            List<empnoModel> list = empno_BLL.GetList(queryStr);
            var model = (from r in list
                         select new empnoModel()
                         {
                             EMP_NO = r.EMP_NO,
                             EMP_NM = r.EMP_NM,
                             DEPM_NO = r.DEPM_NO,
                             E_MAIL = r.E_MAIL

                         }).ToArray();

            return Json(model, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}