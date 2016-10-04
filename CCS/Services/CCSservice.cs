using CCS.IBLL;
using CCS.Models.SAL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCS.Services
{
    public class CCSservice
    {
        [Dependency]
        public IcustomerBLL cust_BLL { get; set; }
        
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
        public void getValue()
        {

        }
    }
}