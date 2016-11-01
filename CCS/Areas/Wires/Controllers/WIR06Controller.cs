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
    public class WIR06Controller : BaseController
    {
        private DropListService dls;
        public WIR06Controller(DropListService dls)
        {
            this.dls = dls;
        }

        CCSservice ccsService = new CCSservice();
        ValidationErrors errors = new ValidationErrors();

        // GET: Wires/WIR06
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
            DateTime datetime = DateTime.ParseExact(vdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string vdate1 = datetime.ToString("yyyyMM");
            string vdate2 = datetime.AddMonths(-1).ToString("yyyyMM");
            string v_sqlstr = String.Format(
                        " SELECT WS.CS_NO,WS.CS_NM,WS.RAWMTRL,WS.DIAMETER "+
                        "        , ISNULL(PRI.PRI_WT, 0) PRI_WT, ISNULL(CUR.IMPORT, 0) IMPORT, ISNULL(CUR.EXPORT, 0) EXPORT, ISNULL(CUR.LOSS, 0) LOSS, ISNULL(CUR.BACK, 0) BACK " +
                        "        , (ISNULL(PRI.PRI_WT, 0) + ISNULL(CUR.IMPORT, 0) - ISNULL(CUR.EXPORT, 0) - ISNULL(CUR.LOSS, 0) - ISNULL(CUR.BACK, 0)) AS TTLWT " +
                        " FROM ( " +
                        "   SELECT  DISTINCT a.CS_NO, a.CS_NM, a.RAWMTRL, a.DIAMETER " +
                        "   FROM CS_WIRES_CS a " +
                        "   WHERE 1 = 1 " +
                        "   AND CONVERT(char(6), a.TRANS_DATE, 112) <= '{0}' " +
                        " ) WS LEFT OUTER JOIN " +
                        " ( " +
                        "    SELECT CS_NO, CS_NM, RAWMTRL, DIAMETER, (sum(IMPORT) - sum(EXPORT) - sum(LOSS) - sum(BACK)) PRI_WT " +
                        "    FROM( " +
                        "    SELECT a.CS_NO, a.CS_NM, a.RAWMTRL, a.DIAMETER " +
                        "     , CASE WHEN a.TRANS_CODE = 'I' THEN a.WEIGHT ELSE 0 END as IMPORT " +
                        "     , CASE WHEN a.TRANS_CODE = 'O' THEN a.WEIGHT ELSE 0 END as EXPORT " +
                        "     , CASE WHEN a.TRANS_CODE = 'L' THEN a.WEIGHT ELSE 0 END as LOSS " +
                        "     , CASE WHEN a.TRANS_CODE = 'R' THEN a.WEIGHT ELSE 0 END as BACK " +
                        "     , CONVERT(char(6), a.TRANS_DATE, 112) TRANS_DATE " +
                        "     FROM CS_WIRES_CS a " +
                        "     WHERE 1 = 1 " +
                        "     AND CONVERT(char(6), a.TRANS_DATE, 112) <= '{1}' " +
                        "     ) A " +
                        "     GROUP BY CS_NO, CS_NM, RAWMTRL, DIAMETER " +
                        "  ) PRI ON WS.CS_NO = PRI.CS_NO AND WS.RAWMTRL = PRI.RAWMTRL  AND WS.DIAMETER = PRI.DIAMETER " +
                        " LEFT OUTER JOIN " +
                        "(  " +
                        "    SELECT CS_NO, CS_NM, RAWMTRL, DIAMETER, sum(IMPORT) IMPORT, sum(EXPORT) EXPORT, sum(LOSS) LOSS, sum(BACK) BACK " +
                        "    FROM( " +
                        "    SELECT a.CS_NO, a.CS_NM, a.RAWMTRL, a.DIAMETER " +
                        "     , CASE WHEN a.TRANS_CODE = 'I' THEN a.WEIGHT ELSE 0 END as IMPORT " +
                        "     , CASE WHEN a.TRANS_CODE = 'O' THEN a.WEIGHT ELSE 0 END as EXPORT " +
                        "     , CASE WHEN a.TRANS_CODE = 'L' THEN a.WEIGHT ELSE 0 END as LOSS " +
                        "     , CASE WHEN a.TRANS_CODE = 'R' THEN a.WEIGHT ELSE 0 END as BACK " +
                        "     , CONVERT(char(6), a.TRANS_DATE, 112) TRANS_DATE " +
                        "     FROM CS_WIRES_CS a " +
                        "     WHERE 1 = 1 " +
                        "     AND CONVERT(char(6), a.TRANS_DATE, 112) = '{0}' " +
                        "     ) A " +
                        "     GROUP BY CS_NO, CS_NM, RAWMTRL, DIAMETER " +
                        " ) CUR ON WS.CS_NO = CUR.CS_NO AND WS.RAWMTRL = CUR.RAWMTRL AND WS.DIAMETER = CUR.DIAMETER " +
                        " WHERE 1 = 1 " +
                        " AND(ISNULL(PRI.PRI_WT, 0) > 0 OR ISNULL(CUR.IMPORT, 0) > 0 OR ISNULL(CUR.EXPORT, 0) > 0 OR ISNULL(CUR.LOSS, 0) > 0 OR ISNULL(CUR.BACK, 0) > 0) " +
                        " AND WS.CS_NO = '{2}' ORDER BY 1, 2, 3 ", vdate1, vdate2, vcust);

            var path = Server.MapPath("~/Reports/WIR06_01.rdlc");
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