using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.SAL;
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
    public class SAL03Controller : BaseController
    {
        CCSservice ccsService = new CCSservice();
        private DropListService dls;
        public SAL03Controller(DropListService dls)
        {
            this.dls = dls;
        }

        [Dependency]
        public IcomtBLL comtBLL { get; set; }
        [Dependency]
        public IcodlBLL codlBLL { get; set; }
        
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
            List<COMTModel> list = comtBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new COMTModel()
                        {

                            ID = r.ID,
                            VCH_TY = r.VCH_TY,
                            VCH_NO = r.VCH_NO,
                            VCH_DT = r.VCH_DT,
                            CS_NO = r.CS_NO,
                            FULL_NM = r.FULL_NM,
                            DEPM_NO = r.DEPM_NO,
                            DEPM_NM = r.DEPM_NM,
                            EMP_NO = r.EMP_NO,
                            EMP_NM = r.EMP_NM,
                            TAX_TY = r.TAX_TY,
                            TAX_RT = r.TAX_RT,
                            PAY_CDT = r.PAY_CDT,
                            PAY_CDT_NM = r.PAY_CDT_NM,
                            CS_VCH_NO = r.CS_VCH_NO,
                            CONTACTER = r.CONTACTER,
                            TO_ADDR = r.TO_ADDR,
                            CURRENCY = r.CURRENCY,
                            EXCH_RATE = r.EXCH_RATE,
                            WAHO_NO = r.WAHO_NO,
                            WAHO_NM = r.WAHO_NM,
                            AMT = r.AMT,
                            TAX = r.TAX,
                            QTY = r.QTY,
                            N_PRT = r.N_PRT,
                            C_SIGN = r.C_SIGN,
                            C_CFM = r.C_CFM,
                            CFM_DT = r.CFM_DT

                        }).ToArray()

            };

            return Json(json);
        }

        // 訂單明細 - Datagrid子明細
        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetDetailsList(GridPager pager, string queryStr)
        {
            pager.rows = 999999;
            pager.page = 1;
            pager.sort = "VCH_NO";
            pager.order = "desc";

            List<CODLModel> list = codlBLL.GetList(ref pager, queryStr);
            var json = (from r in list
                        select new CODLModel()
                        {
                            ID = r.ID,
                            VCH_TY = r.VCH_TY,
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
                            RCV_QTY = r.RCV_QTY,
                            CO_WAHO_NO = r.CO_WAHO_NO,
                            WAHO_NM = r.WAHO_NM,
                            C_OUT = r.C_OUT,
                            OUT_RT = r.OUT_RT,
                            C_CLS = r.C_CLS,
                            REMK = r.REMK,
                            CS_NO = r.CS_NO,
                            C_CFM = r.C_CFM
                        });


            return Json(json);
        }

        #region 詳細
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Perm = GetPermission();
            COMTModel entity = comtBLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 訂單報表
        [SupportFilter(ActionName = "Index")]
        public ActionResult Reporting(string ty,string no, string type = "PDF")
        {
            string v_sqlstr = "SELECT A.VCH_TY, A.VCH_NO,  CONVERT(VARCHAR(10), A.VCH_DT,120) VCH_DT, A.CS_NO, A.FULL_NM AS CS_NM, A.DEPM_NO, A.DEPM_NM, A.EMP_NO, A.EMP_NM AS EMP_NAME, A.TAX_TY, A.TAX_RT, A.PAY_CDT, A.PAY_CDT_NM, " +
                            "A.CS_VCH_NO, A.CONTACTER, A.TO_ADDR, A.TEL_NO, A.FAX_NO, A.CURRENCY, A.EXCH_RATE " +
                            ",B.VCH_SR, B.ITEM_NO, B.ITEM_NM, B.ITEM_SP, B.CS_ITEM_NO, B.UNIT, B.QTY, B.PRC, B.AMT,CONVERT(VARCHAR(10), B.PRCV_DT,120) PRCV_DT, B.RCV_QTY, B.CO_WAHO_NO, B.WAHO_NM, REMK " +
                            " FROM V_COMT A, V_CODL B " +
                            " WHERE A.VCH_NO = B.VCH_NO " +
                            " AND A.VCH_NO = B.VCH_NO " +
                            " AND A.VCH_TY = '"+ty+"' " +
                            " AND A.VCH_NO = '"+ no + "'  ";

            //資料集
            DataTable dt = ccsService.GetDataSet(v_sqlstr, "");

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/SAL03_01.rdlc");
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