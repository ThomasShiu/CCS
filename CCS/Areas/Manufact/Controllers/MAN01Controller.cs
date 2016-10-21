using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.MAN;
using CCS.Models.PUB;
using CCS.Models.SAL;
using CCS.Models.WIR;
using CCS.Services;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Manufact.Controllers
{
    public class MAN01Controller : BaseController
    {
        [Dependency]
        public Ics_momtBLL cs_momt_BLL { get; set; }

        [Dependency]
        public Ics_comtBLL cs_comtBLL { get; set; }

        [Dependency]
        public Ics_codlBLL cs_codlBLL { get; set; }

        [Dependency]
        public Ics_wiresBLL cs_wiresBLL { get; set; }
        [Dependency]
        public IitemBLL item_BLL { get; set; }

        [Dependency]
        public Ics_wipfBLL cswipf_BLL { get; set; }

        CCSservice ccsService = new CCSservice();
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
            try
            {
                List<itemModel> itemlist = item_BLL.GetList(""); // 料品主檔
                //itemlist = (from r in itemlist
                //            where r.ITEM_NO.StartsWith("6")
                //            select new itemModel
                //            {
                //                ITEM_NO = r.ITEM_NO,
                //                ITEM_NM = r.ITEM_NM,
                //                ITEM_SP = r.ITEM_SP
                //            }).ToList();

                List<cs_momtModel> list = cs_momt_BLL.GetList(ref pager, queryStr);

                var json = new
                {
                    total = pager.totalRows,
                    rows = (from r in list
                            from r1 in itemlist
                            where r.ITEM_NO == r1.ITEM_NO.TrimEnd()
                            select new cs_momtModel()
                            {
                                Id = r.Id,
                                VCH_NO = r.VCH_NO,
                                VCH_DT = r.VCH_DT,
                                FA_NO = r.FA_NO,
                                ITEM_NO = r.ITEM_NO,
                                ITEM_NM = r1.ITEM_NM,
                                IMG_NO = r.IMG_NO,
                                PLAN_BDT = r.PLAN_BDT,
                                PLAN_EDT = r.PLAN_EDT,
                                PLAN_QTY = r.PLAN_QTY,
                                CO_NO = r.CO_NO,
                                CO_SR = r.CO_SR,
                                HEAD_MARK = r.HEAD_MARK,
                                THREAD = r.THREAD,
                                RAWMTRL = r.RAWMTRL,
                                DIAMETER = r.DIAMETER,
                                HEAT_NO = r.HEAT_NO,
                                PLATING = r.PLATING,
                                PRCS_NO = r.PRCS_NO,
                                MACHINE = r.MACHINE,
                                REMK = r.REMK,
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

                return MyJson(json, "yyyy-MM-dd");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // 成型生產紀錄 - Datagrid子明細
        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetDetailsList(GridPager pager, string queryStr)
        {
            pager.rows = 999999;
            pager.page = 1;
            pager.sort = "LOT_NO";
            pager.order = "desc";

            List<cs_wipfModel> list = cswipf_BLL.GetList(ref pager, queryStr);
            var json = (from r in list
                        group r by new
                        {
                            r.LOT_NO
                        } into g
                        select new
                        {
                            g.Key.LOT_NO,
                            TTLWT = (int?)g.Sum(p => p.WEIGHT),
                            TTLQTY = (int?)g.Sum(p => p.COUNT_QTY)
                        });


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
        public JsonResult Create(cs_momtModel model)
        {
            model.Id = ResultHelper.NewId;
            model.VCH_NO = ResultHelper.NewOrdId("WIP", "B"); // 取單號
            model.C_CLS = "N";
            model.EMP_NO = GetUserId();
            model.EMP_NM = GetUserTrueName();
            model.EXC_INSDBID = GetUserId();
            model.EXC_INSDATE = DateTime.Now;
            model.EXC_UPDDBID = GetUserId();
            model.EXC_UPDDATE = DateTime.Now;
            //model.EXC_ISLOCKED = GetUserId();
            model.EXC_COMPANY = "CCS";

            if (model != null && ModelState.IsValid)
            {

                if (cs_momt_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",單號:" + model.VCH_NO, "成功", "創建", "CS_MOMT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",單號:" + model.VCH_NO + "," + ErrorCol, "失敗", "創建", "CS_MOMT");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
            }
        }
        #endregion

        #region 訂單資料，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetCscodlList(GridPager pager,string queryStr)
        {
            pager.rows = 999999;
            pager.page = 1;
            pager.sort = "VCH_NO";
            pager.order = "desc";

            List<cs_codlModel> dllist = cs_codlBLL.GetList(ref pager, queryStr);  // 訂單明細
            List<cs_comtModel> mtlist = cs_comtBLL.GetList(ref pager, queryStr); // 訂單主檔

            var model = (from A in dllist
                         from B in mtlist
                         where
                           A.VCH_NO == B.VCH_NO &&
                           A.C_CLS == "N"
                         select new
                         {
                             A.ID,
                             A.VCH_NO,
                             A.VCH_SR,
                             A.ITEM_NO,
                             A.ITEM_NM,
                             A.ITEM_SP,
                             A.CS_ITEM_NO,
                             A.UNIT,
                             A.QTY,
                             A.PRC,
                             A.AMT,
                             A.PRCV_DT,
                             B.CS_NM,
                             B.CS_VCH_NO
                         }).ToArray();


            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        

        #region 製程組合，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetProcessSetList(string queryStr)
        {
            var list = ResultHelper.GetProcessSetList(queryStr);

            var model = (from r in list
                         select new
                         {
                             r.Id,
                             r.P_SET,
                             r.P_SET_NM
                         }).ToArray();


            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            cs_momtModel entity = cs_momt_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_momtModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.EXC_UPDDBID = GetUserId();
                model.EXC_UPDDATE = DateTime.Now;

                if (cs_momt_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",單號:" + model.VCH_NO, "成功", "修改", "CS_MOMT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",單號:" + model.VCH_NO + "," + ErrorCol, "失敗", "修改", "CS_MOMT");
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
            cs_momtModel entity = cs_momt_BLL.GetById(id);
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
                if (cs_momt_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "CS_MOMT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id + "," + ErrorCol, "失敗", "刪除", "CS_MOMT");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }


        }
        #endregion

        [SupportFilter(ActionName = "Index")]
        #region
        public ActionResult Reporting(string id, string type = "PDF")
        {
            string v_sqlstr = "SELECT a.VCH_NO, a.VCH_DT, a.FA_NO, a.EMP_NO, a.EMP_NM, a.ITEM_NO, a.IMG_NO, a.PLAN_BDT, a.PLAN_EDT, a.PLAN_QTY, "+
                                "a.HEAD_MARK, a.RAWMTRL, a.DIAMETER, a.HEAT_NO, a.PLATING, a.PRCS_NO,a.MACHINE, a.REMK, " +
                                "a.CO_NO, a.CO_SR, b.ITEM_NM,b.ITEM_SP,b.CS_ITEM_NO,b.PRCV_DT,d.SHORT_NM,c.CS_VCH_NO,a.THREAD " +
                                " FROM CS_MOMT a, CS_CODL b,CS_COMT c, customer d "+
                                "   WHERE a.CO_NO = b.VCH_NO "+
                                " AND a.CO_SR = b.VCH_SR "+
                                " AND b.VCH_NO = c.VCH_NO "+
                                " AND c.CS_NO = d.CS_NO "+
                                " AND a.VCH_NO = '" + id + "' ";

            var path = Server.MapPath("~/Reports/MAN01_01.rdlc");
            string paper = "A4";


            //資料集
            DataTable dt = ccsService.GetDataSet(v_sqlstr, "");

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = path;
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
            localReport.DataSources.Add(reportDataSource);
            localReport.EnableExternalImages = true;

            var url = "http://"+Request.Url.Authority;

            //宣告要傳入報表的參數 p_ImgPath，並指定照片路徑 , http://xxx.xxx.xxx.xx:1234
            ReportParameter p_ImgPath = new ReportParameter("ImgPath", url);
            //把參數傳給報表
            localReport.SetParameters(new ReportParameter[] { p_ImgPath });

            string reportType = type;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + type + "</OutPutFormat>";
            switch (paper) {
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
