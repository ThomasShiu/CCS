using CCS.App_Start;
using CCS.Common;
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

namespace CCS.Areas.Wires.Controllers
{
    public class WIR04Controller : BaseController
    {
        private DropListService dls;
        public WIR04Controller(DropListService dls)
        {
            this.dls = dls;
        }

        CCSservice ccsService = new CCSservice();
        ValidationErrors errors = new ValidationErrors();

        // GET: Wires/WIR04
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

        [SupportFilter(ActionName = "Index")]
        #region
        public ActionResult Reporting(string vdate, string vcust, string type = "EXCEL")
        {
            string vdt = vdate;
            DateTime datetime = DateTime.ParseExact(vdate, "yyyy-MM-dd",CultureInfo.InvariantCulture);
            string vdate1 = datetime.ToString("yyyyMM");
            string vdate2 = datetime.AddMonths(-1).ToString("yyyyMM");
            string v_sqlstr = String.Format(
                     "SELECT WS.CS_NO,WS.CS_NM,WS.RAWMTRL, WS.HEAT_NO, WS.DIAMETER " +
                     "       , ISNULL(PRI.PRI_WT, 0) PRI_WT, ISNULL(CUR.IMPORT, 0) IMPORT, ISNULL(CUR.EXPORT, 0) EXPORT " +
                     "       , (ISNULL(PRI.PRI_WT, 0) + ISNULL(CUR.IMPORT, 0) - ISNULL(CUR.EXPORT, 0)) AS TTLWT " +
                     "FROM( " +
                     "  SELECT DISTINCT b.CS_NO,b.CS_NM,b.RAWMTRL, b.HEAT_NO, b.DIAMETER " +
                     "  FROM CS_WIRES_JOURNAL a, CS_WIRES b " +
                     "  WHERE a.WIRE_ID = b.WIRE_ID " +
                     "  AND CONVERT(char(6), a.TRANS_DATE, 112) <= {0} " +
                     ") WS LEFT OUTER JOIN  ( " +
                     " SELECT CS_NO,RAWMTRL, HEAT_NO, DIAMETER, (sum(IMPORT) - sum(EXPORT)) PRI_WT " +
                     " FROM(" +
                     " SELECT b.CS_NO,b.RAWMTRL, b.HEAT_NO, b.DIAMETER " +
                     "  , CASE WHEN a.TRANS_CODE = 'I' THEN a.WEIGHT ELSE 0 END as IMPORT " +
                     "  , CASE WHEN a.TRANS_CODE = 'O' THEN a.WEIGHT ELSE 0 END as EXPORT " +
                     "  , CONVERT(char(6), a.TRANS_DATE, 112) TRANS_DATE " +
                     "  FROM CS_WIRES_JOURNAL a, CS_WIRES b " +
                     "  WHERE a.WIRE_ID = b.WIRE_ID " +
                     "  AND CONVERT(char(6), a.TRANS_DATE, 112) <= {1} " +
                    "   ) A " +
                    "   GROUP BY CS_NO,RAWMTRL, HEAT_NO, DIAMETER " +
                    ") PRI ON WS.CS_NO = PRI.CS_NO AND WS.RAWMTRL = PRI.RAWMTRL AND WS.HEAT_NO = PRI.HEAT_NO AND WS.DIAMETER = PRI.DIAMETER " +
                    " LEFT OUTER JOIN(" +
                    "  SELECT CS_NO,RAWMTRL, HEAT_NO, DIAMETER, sum(IMPORT) IMPORT, sum(EXPORT) EXPORT " +
                    "  FROM(" +
                    "  SELECT b.CS_NO,b.RAWMTRL, b.HEAT_NO, b.DIAMETER " +
                    "   , CASE WHEN a.TRANS_CODE = 'I' THEN a.WEIGHT ELSE 0 END as IMPORT " +
                    "   , CASE WHEN a.TRANS_CODE = 'O' THEN a.WEIGHT ELSE 0 END as EXPORT " +
                    "   , CONVERT(char(6), a.TRANS_DATE, 112) TRANS_DATE " +
                    "   FROM CS_WIRES_JOURNAL a, CS_WIRES b " +
                    "   WHERE a.WIRE_ID = b.WIRE_ID " +
                    "   AND CONVERT(char(6), a.TRANS_DATE, 112) = {0} " +
                    "   ) A " +
                    "   GROUP BY CS_NO,RAWMTRL, HEAT_NO, DIAMETER, TRANS_DATE " +
                    " ) CUR ON WS.CS_NO = CUR.CS_NO AND WS.RAWMTRL = CUR.RAWMTRL AND WS.HEAT_NO = CUR.HEAT_NO AND WS.DIAMETER = CUR.DIAMETER " +
                    " WHERE 1 = 1 " +
                    " AND(ISNULL(PRI.PRI_WT, 0) > 0 OR ISNULL(CUR.IMPORT, 0) > 0 OR ISNULL(CUR.EXPORT, 0) > 0) " +
                    " AND WS.CS_NO = '{2}' ORDER BY 1, 2, 3 ", vdate1, vdate2, vcust);

            var path = Server.MapPath("~/Reports/WIR04_01.rdlc");
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