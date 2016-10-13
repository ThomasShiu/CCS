using CCS.Common;
using CCS.IBLL;
using CCS.Models;
using CCS.Models.MAN;
using CCS.Models.PUB;
using CCS.Models.SAL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CCS.Services
{
    public class CCSservice
    {
        [Dependency]
        public IcustomerBLL cust_BLL { get; set; }
        [Dependency]
        public IitemBLL item_BLL { get; set; }
        [Dependency]
        public IEMPNOBLL empno_BLL { get; set; }
        [Dependency]
        public Ics_codlBLL codl_BLL { get; set; }

        #region  取得客戶列表
        public customerModel[] GetCustList(String queryStr)
        {
            try { 
            //int total = pager.totalRows;
            List<customerModel> list = cust_BLL.GetList(queryStr);
            var model = (from r in list
                        select new customerModel()
                        {
                            CS_NO = r.CS_NO,
                            SHORT_NM = r.SHORT_NM,
                            ADDR_IVC = r.ADDR_IVC,
                            CONTACTER = r.CONTACTER,
                            TEL_NO = r.TEL_NO,
                            FAX_NO = r.FAX_NO

                        }).ToArray();


            return model;
            }catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region  取得料品基本檔列表
        public itemModel[] GetitemList(String queryStr)
        {
            try
            {
                //int total = pager.totalRows;
                List<itemModel> list = item_BLL.GetList(queryStr);
                var model = (from r in list
                             select new itemModel()
                             {
                                 ITEM_NO = r.ITEM_NO,
                                 ITEM_NM = r.ITEM_NM,
                                 ITEM_SP = r.ITEM_SP,
                                 ITEM_NM_E = r.ITEM_NM_E,
                                 ITEM_SP_E = r.ITEM_SP_E,
                                 ITEM_NO_O = r.ITEM_NO_O,

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
        public empnoModel[] GetEmpList(String queryStr)
        {
            GridPager pager=null;
            pager.rows = 999999;
            pager.page = 1;
            pager.sort = "EMP_NO";
            pager.order = "desc";

            List<empnoModel> list = empno_BLL.GetList(ref pager, queryStr);
            var model = (from r in list
                         select new empnoModel()
                         {
                             EMP_NO = r.EMP_NO,
                             EMP_NM = r.EMP_NM,
                             DEPM_NO = r.DEPM_NO,
                             E_MAIL = r.E_MAIL

                         }).ToArray();

            return model;

        }
        #endregion

        #region 取得訂單明細
        public cs_codlModel[] GetOrdDetailsList(GridPager pager, string queryStr)
        {
            pager.rows = 999999;
            pager.page = 1;
            pager.sort = "VCH_NO";
            pager.order = "desc";

            List<cs_codlModel> list = codl_BLL.GetList(ref pager, queryStr);
            var model = (from r in list
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

                         }).ToArray();


            return model;
        }
        #endregion

        // 產生資料集
        public DataTable GetDataSet(string SQL,string v_TBLName)
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