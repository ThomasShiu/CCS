using CCS.IBLL;
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