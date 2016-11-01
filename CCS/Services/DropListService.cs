using CCS.BLL;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models;
using CCS.Models.MAN;
using CCS.Models.PUB;
using CCS.Models.SAL;
using CCS.Models.WIR;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CCS.Services
{
    public class DropListService
    {
        [Dependency]
        public IcustomerBLL cust_BLL { get; set; }
        [Dependency]
        public IitemBLL item_BLL { get; set; }
        [Dependency]
        public IEMPNOBLL empno_BLL { get; set; }
        [Dependency]
        public IcomtBLL comt_BLL { get; set; }
        [Dependency]
        public IcodlBLL codl_BLL { get; set; }

        [Dependency]
        public Ics_momtBLL momt_BLL { get; set; }

        [Dependency]
        public Ics_wiresBLL cswires_BLL { get; set; }

        CCSEntities _db = new CCSEntities();

        #region  取得客戶列表
        public customerModel[] GetCustList(string queryStr)
        {
            try
            {
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
                return model;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region  取得料品基本檔列表
        public itemModel[] GetitemList(string queryStr)
        {
            try
            {
                //int total = pager.totalRows;
                List<itemModel> list = item_BLL.GetList(queryStr);
                var model = (from r in list
                             where r.ITEM_NO.StartsWith("6")  // 製成品
                             select new itemModel()
                             {
                                 ITEM_NO = r.ITEM_NO,
                                 ITEM_NM = r.ITEM_NM,
                                 ITEM_SP = r.ITEM_SP,
                                 ITEM_NM_E = r.ITEM_NM_E,
                                 ITEM_SP_E = r.ITEM_SP_E,
                                 ITEM_NO_O = r.ITEM_NO_O
                             }).ToArray();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion


        #region 取得員工列表，下拉選單
        //[HttpPost]
        public empnoModel[] GetEmpList(string queryStr)
        {
            try
            {
                List<empnoModel> list = empno_BLL.GetList(queryStr);
                var model = (from r in list
                             select new empnoModel()
                             {
                                 EMP_NO = r.EMP_NO,
                                 EMP_NM = r.EMP_NM,
                                 DEPM_NO = r.DEPM_NO
                             }).ToArray();


                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 線材(未結案)，下拉選單
        public cs_wiresModel[] GetWiresList(GridPager pager, string queryStr)
        {
            pager.rows = 999999;
            pager.page = 1;
            pager.sort = "WIRE_ID";
            pager.order = "desc";

            List<cs_wiresModel> list = cswires_BLL.GetList(ref pager, queryStr);
            var model = (from r in list
                         where r.C_CLS == "N"
                         select new cs_wiresModel()
                         {

                             Id = r.Id,
                             WIRE_ID = r.WIRE_ID,
                             CS_WIRE_ID = r.CS_WIRE_ID,
                             STOCK_DATE = r.STOCK_DATE,
                             RAWMTRL = r.RAWMTRL,
                             DIAMETER = r.DIAMETER,
                             ORG_DIAMETER = r.ORG_DIAMETER,
                             HEAT_NO = r.HEAT_NO,
                             WEIGHT = r.WEIGHT,
                             STAND_WEIGTH = r.STAND_WEIGTH,
                             ANNEAL = r.ANNEAL,
                             MARK = r.MARK,
                             MARK_NM = r.MARK_NM,
                             PROCESS_FACTORY = r.PROCESS_FACTORY,
                             TYPE = r.TYPE,
                             TYPE_NM = r.TYPE_NM,
                             REMARK = r.REMARK,
                             C_CLS = r.C_CLS

                         }).ToArray();

            return model;
        }
        #endregion

        #region 取得未結案訂單明細
        public List<SP_GET_CO_Result2> GetOrdDetailsList()
        {

            var model = _db.SP_GET_CO().Where(a=>a.C_CLS=="N").ToList();

            return model;
        }
        #endregion

        // 產生資料集
        public DataTable GetDataSet(string SQL, string v_TBLName)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CCSConn"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = SQL;
            da.SelectCommand = cmd;
            //DataSet ds = new DataSet();

            DataTable dt = new DataTable();


            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }




        public void getValue()
        {

        }
    }
}