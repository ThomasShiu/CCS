using CCS.App_Start;
using CCS.Core;
using CCS.Models.PUB;
using CCS.Services;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Keg.Controllers
{
    public class KEG04Controller : BaseController
    {
        private DropListService dls;
        public KEG04Controller(DropListService dls)
        {
            this.dls = dls;
        }

        CCSservice ccsService = new CCSservice();

        // GET: Keg/KEG04
        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        #region 客戶列表，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetCustList(String queryStr)
        {

            List<customerModel> list = dls.GetCustList(queryStr).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 鐵桶對帳報表
        [SupportFilter(ActionName = "Index")]
        public ActionResult Reporting(string vdate, string vcust,string type = "Excel")
        {
            string vdt = vdate;
            DateTime datetime = DateTime.ParseExact(vdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string vdate1 = datetime.ToString("yyyyMM");
            string vdate2 = datetime.AddMonths(-1).ToString("yyyyMM");
            string v_sqlstr = String.Format(
                     " SELECT K.CS_NO, K.CS_NM, K.KEG_NM,ISNULL(PRI.PRI_CNT,0) PRI_CNT, "+
                    " ISNULL(CUR.IMPORT, 0) IMPORT, ISNULL(CUR.EXPORT, 0) EXPORT, " +
                    " ( ISNULL(PRI.PRI_CNT, 0) + ISNULL(CUR.IMPORT, 0) - ISNULL(CUR.EXPORT, 0)) AS TTLCNT " +
                    " FROM ( " +
                    " SELECT DISTINCT CS_NO, CS_NM, KEG_NM " +
                    " FROM CS_KEGS_CS ) K LEFT OUTER JOIN " +
                    " ( SELECT CS_NO, CS_NM, KEG_NM, (sum(IMPORT) - sum(EXPORT)) PRI_CNT " +
                    "    FROM( " +
                    "    SELECT CS_NO, CS_NM, KEG_NM " +
                    "       , CASE WHEN TRANS_CODE = 'I' THEN CNT ELSE 0 END as IMPORT " +
                    "       , CASE WHEN TRANS_CODE = 'O' THEN CNT ELSE 0 END as EXPORT " +
                    "       , CONVERT(char(6), TRANS_DATE, 112) TRANS_DATE " +
                    "     FROM CS_KEGS_CS " +
                    "     WHERE 1 = 1 " +
                    "     AND CONVERT(char(6), TRANS_DATE, 112) <= '{1}' " +
                    "   ) A GROUP BY CS_NO, CS_NM, KEG_NM " +
                    " ) PRI ON K.CS_NO = PRI.CS_NO AND K.CS_NM = PRI.CS_NM AND K.KEG_NM = PRI.KEG_NM " +
                    " LEFT OUTER JOIN " +
                    " ( " +
                    "   SELECT CS_NO, CS_NM, KEG_NM, sum(IMPORT) IMPORT, sum(EXPORT) EXPORT " +
                    "    FROM( " +
                    "    SELECT CS_NO, CS_NM, KEG_NM " +
                    "       , CASE WHEN TRANS_CODE = 'I' THEN CNT ELSE 0 END as IMPORT " +
                    "       , CASE WHEN TRANS_CODE = 'O' THEN CNT ELSE 0 END as EXPORT " +
                    "       , CONVERT(char(6), TRANS_DATE, 112) TRANS_DATE " +
                    "     FROM CS_KEGS_CS " +
                    "     WHERE 1 = 1 " +
                    "     AND CONVERT(char(6), TRANS_DATE, 112) = '{0}' " +
                    "   ) A GROUP BY CS_NO, CS_NM, KEG_NM " +
                    " ) CUR ON K.CS_NO = CUR.CS_NO AND K.CS_NM = CUR.CS_NM AND K.KEG_NM = CUR.KEG_NM " +
                    " WHERE 1 = 1 " +
                    " AND (ISNULL(PRI.PRI_CNT, 0) > 0 OR ISNULL(CUR.IMPORT, 0) > 0 OR ISNULL(CUR.EXPORT, 0) > 0) " +
                    " AND K.CS_NO = '{2}' ORDER BY 1, 2, 3 ", vdate1, vdate2, vcust);

            var path = Server.MapPath("~/Reports/KEG04_01.rdlc");
            string paper = "A4";


            //資料集
            DataTable dt = ccsService.GetDataSet(v_sqlstr, "");

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = path;
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
            localReport.DataSources.Add(reportDataSource);

            localReport.EnableExternalImages = true;
            //宣告要傳入報表的參數 vYM
            ReportParameter p_YM = new ReportParameter("vYM", vdate1);
            //把參數傳給報表
            localReport.SetParameters(new ReportParameter[] { p_YM });



            string reportType = type;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + type + "</OutPutFormat>";
            switch (paper)
            {
                case "Letter":// 中一刀
                    deviceInfo +=
                    "<PageWidth>9in</PageWidth>" +
                    "<PageHeight>6in</PageHeight>";
                    break;
                case "A4":// A4
                    deviceInfo +=
                    "<PageWidth>8.2in</PageWidth>" +
                    "<PageHeight>11.6in</PageHeight>";
                    break;
            }
            deviceInfo +=
                "<MarginTop>0.2in</MarginTop>" +
                "<MarginLeft>0.2in</MarginLeft>" +
                "<MarginRight>0.2in</MarginRight>" +
                "<MarginBottom>0.2in</MarginBottom>" +
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