using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.INV;
using CCS.Services;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Inventory.Controllers
{
    public class INV04Controller : BaseController
    {
        private DropListService dls;
        public INV04Controller(DropListService dls)
        {
            this.dls = dls;
        }
        CCSservice ccsService = new CCSservice();

        [Dependency]
        public Ics_shipmtBLL cs_shipmt_BLL { get; set; }

        [Dependency]
        public Ics_shipdlBLL m_BLL { get; set; }

        ValidationErrors errors = new ValidationErrors();

        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        #region 訂單主明細檔
        [SupportFilter(ActionName = "Index")]
        public ActionResult MasterDetails(string id)
        {
            ViewBag.Perm = GetPermission();
            cs_shipmtModel entity = cs_shipmt_BLL.GetById(id);  //主檔，明細由JSON取得
            return View(entity);
        }
        #endregion

        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<cs_shipdlModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_shipdlModel()
                        {

                            Id = r.Id,
                            VCH_NO = r.VCH_NO,
                            VCH_SR = r.VCH_SR,
                            ITEM_NO = r.ITEM_NO,
                            ITEM_NM = r.ITEM_NM,
                            ITEM_SP = r.ITEM_SP,
                            RAWMTRL = r.RAWMTRL,
                            HEAT_NO = r.HEAT_NO,
                            KEG_CNT = r.KEG_CNT,
                            UNIT_WT = r.UNIT_WT,
                            NET_WEIGHT = r.NET_WEIGHT,
                            GROSS_WEIGHT = r.GROSS_WEIGHT,
                            COUNT_QTY = r.COUNT_QTY,
                            PRC = r.PRC,
                            AMT = r.AMT,
                            END_CODE = r.END_CODE,
                            CS_ORDER_NO = r.CS_ORDER_NO,
                            REMK = r.REMK,
                            EXC_INSDBID = r.EXC_INSDBID,
                            EXC_INSDATE = r.EXC_INSDATE,
                            EXC_UPDDBID = r.EXC_UPDDBID,
                            EXC_UPDDATE = r.EXC_UPDDATE,
                            EXC_SYSOWNR = r.EXC_SYSOWNR,
                            EXC_ISLOCKED = r.EXC_ISLOCKED,
                            EXC_COMPANY = r.EXC_COMPANY,
                            STATUS = r.STATUS

                        }).ToArray()

            };

            return Json(json);
        }

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
        public JsonResult Create(cs_shipdlModel model)
        {
            model.Id = ResultHelper.NewId;
            model.AMT = 0;
            model.PRC = 0;
            model.EXC_INSDATE = ResultHelper.NowTime;
            model.EXC_INSDBID = GetUserId();
            model.EXC_UPDDATE = ResultHelper.NowTime;
            model.EXC_UPDDBID = GetUserId();
            //model.CreateTime = ResultHelper.NowTime;
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",VCH_NO:" + model.VCH_NO, "成功", "創建", "CS_SHIPDL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",VCH_NO:" + model.VCH_NO + "," + ErrorCol, "失敗", "創建", "CS_SHIPDL");
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
            cs_shipdlModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_shipdlModel model)
        {
            model.EXC_UPDDATE = ResultHelper.NowTime;
            model.EXC_UPDDBID = GetUserId();
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",VCH_NO:" + model.VCH_NO, "成功", "修改", "CS_SHIPDL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + model.Id + ",VCH_NO:" + model.VCH_NO + "," + ErrorCol, "失敗", "修改", "CS_SHIPDL");
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
            cs_shipdlModel entity = m_BLL.GetById(id);
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
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "CS_SHIPDL");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失敗", "刪除", "CS_SHIPDL");
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
        public JsonResult GetOrdDetailsList()
        {
            //var model =  ccsService.GetCustList("");
            var model = dls.GetOrdDetailsList();

            return Json(model, JsonRequestBehavior.AllowGet);

        }
        #endregion

        
        #region 料品列表，下拉選單
        [SupportFilter(ActionName = "Index")]
        //[HttpPost]
        public JsonResult GetItemList(String queryStr)
        {
            //var model =  ccsService.GetCustList("");
            var model = dls.GetitemList("").ToList();

            return Json(model, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 出貨單報表
        [SupportFilter(ActionName = "Index")]
        public ActionResult Reporting(string id, string type = "PDF")
        {
            string v_sqlstr = "SELECT a.VCH_NO, a.VCH_DT, rtrim(a.CS_NO) CS_NO, rtrim(a.CS_NM) CS_NM, a.TO_ADDR, a.CONTACT, a.REMK, " +
                            "  b.VCH_SR, b.ITEM_NO, b.ITEM_NM, b.ITEM_SP, b.RAWMTRL, b.HEAT_NO, b.KEG_CNT, b.UNIT_WT, "+
                            "  b.NET_WEIGHT, b.GROSS_WEIGHT, b.COUNT_QTY, b.PRC, b.AMT, b.END_CODE, b.CS_ORDER_NO, b.REMK REMK2 " +
                            "FROM CS_SHIPMT a,CS_SHIPDL b " +
                            "WHERE a.VCH_NO = b.VCH_NO " +
                            "AND a.VCH_NO = '"+ id + "' ";

            //資料集
            DataTable dt = ccsService.GetDataSet(v_sqlstr, "");

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/INV04_01.rdlc");
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