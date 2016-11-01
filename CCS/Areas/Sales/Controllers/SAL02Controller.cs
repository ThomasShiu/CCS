using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.PUB;
using CCS.Models.SAL;
using CCS.Models.SYS;
using CCS.Services;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Sales.Controllers
{

    
    [UserTraceLog]
    public class SAL02Controller : BaseController
    {
        private DropListService dls;
        public SAL02Controller(DropListService dls)
        {
            this.dls = dls;
        }

        CCSservice ccsService = new CCSservice();

        // GET: Sales/SAL02
        [Dependency]
        public Ics_codlBLL m_BLL { get; set; }

        [Dependency]
        public Ics_comtBLL comt_BLL { get; set; }
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

            model.C_CLS = "N";
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
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.ID + ",VCH_NO:" + model.VCH_NO, "成功", "創建", "CS_CODL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.ID + ",VCH_NO:" + model.VCH_NO + "," + ErrorCol, "失敗", "創建", "CS_CODL");
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
                AccountModel account = (AccountModel)Session["Account"];
                model.MDY_DT = DateTime.Now;
                model.MDY_USR_NO = account.Id;

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "ID:" + model.ID + ",VCH_NO:" + model.VCH_NO, "成功", "修改", "CS_CODL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "ID:" + model.ID + ",VCH_NO:" + model.VCH_NO + "," + ErrorCol, "失敗", "修改", "CS_CODL");
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
                    LogHandler.WriteServiceLog(GetUserId(), "ID:" + id, "成功", "刪除", "CS_CODL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "ID:" + id + "," + ErrorCol, "失敗", "刪除", "CS_CODL");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }


        }
        #endregion

        #region 料品列表，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetItemList(String queryStr)
        {
            //var model =  ccsService.GetCustList("");
            //List<itemModel> list = item_BLL.GetList(queryStr);
            //var model = (from r in list
            //             where r.ITEM_NO.StartsWith("6")  // 製成品
            //             select new itemModel()
            //             {
            //                 ITEM_NO = r.ITEM_NO.Trim(),
            //                 ITEM_NM = r.ITEM_NM.Trim(),
            //                 ITEM_SP = r.ITEM_SP.Trim(),
            //                 ITEM_NM_E = r.ITEM_NM_E,
            //                 ITEM_SP_E = r.ITEM_SP_E,
            //                 ITEM_NO_O = r.ITEM_NO_O
            //             }).ToArray();
            var model = dls.GetitemList("").ToList();
            return Json(model, JsonRequestBehavior.AllowGet);

        }
        #endregion


        #region 訂單報表
        [SupportFilter(ActionName = "Index")]
        public ActionResult Reporting(string id,string type = "PDF")
        {
            string v_sqlstr = "SELECT VCH_NO, CONVERT(VARCHAR(10),VCH_DT,120) VCH_DT, FA_NO, CS_NO, CS_NM, DEPM_NO, EMP_NO, EMP_NAME, CS_VCH_NO,"+
                 "CONTACTER, TAX_TY, TAX_RT, TO_ADDR, TEL_NO, FAX_NO, CURRENCY, EXCH_RATE, WAHO_NO,"+
                 "SHIP_TY, SHIP_CORP, REMK, VCH_SR, ITEM_NO, ITEM_NM, ITEM_SP, CS_ITEM_NO, UNIT, QTY, PRC, AMT, CONVERT(VARCHAR(10),PRCV_DT,120) PRCV_DT " +
                 "FROM CCS_Main.dbo.V_ORDERS WHERE VCH_NO = '"+ id + "' ";
            
             //資料集
             DataTable dt = ccsService.GetDataSet(v_sqlstr,"");

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/SAL01_01.rdlc");
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
            localReport.DataSources.Add(reportDataSource);
            string reportType = type;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + type + "</OutPutFormat>" +
                // 中一刀
                "<PageWidth>9in</PageWidth>" +
                "<PageHeight>6in</PageHeight>" +

                // A4
                //"<PageWidth>8.2in</PageWidth>" +
                //"<PageHeight>11.6in</PageHeight>" +
                "<MarginTop>0.1in</MarginTop>" +
                "<MarginLeft>0.1in</MarginLeft>" +
                "<MarginRight>0.1in</MarginRight>" +
                "<MarginBottom>0.1in</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );
                return File(renderedBytes, mimeType);
            
           
        }
        #endregion
    }
}
