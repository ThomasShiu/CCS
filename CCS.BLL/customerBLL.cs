using System;
using System.Collections.Generic;
using System.Linq;
using CCS.Models;
//using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models.SAL;
using Microsoft.Practices.Unity;
using CCS.Common;
using CCS.BLL.Core;
using CCS.Models.PUB;

namespace CCS.BLL
{
    public class customerBLL:IcustomerBLL
    {
        CCSEntities db = new CCSEntities();

        //public ISysSampleRepository Rep { get; set; }
        //ICS_COMTRepository Rep = new CS_COMTRepository();

        [Dependency]
        public IcustomerRepository m_Rep { get; set; }

        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="pager">JQgrid分頁</param>
        /// <param name="queryStr">搜索條件</param>
        /// <returns>列表</returns>
        public List<customerModel> GetList(string queryStr)
        {

            IQueryable<customer> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.CS_NO.Contains(queryStr) || a.SHORT_NM.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            
            //queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        public List<customerModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<customer> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.CS_NO.Contains(queryStr) || a.SHORT_NM.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<customerModel> CreateModelList( ref IQueryable<customer> queryData)
        {
   
            List<customerModel> modelList = (from r in queryData
                                            select new customerModel
                                            {
                                                CS_NO = r.CS_NO,
                                                SHORT_NM = r.SHORT_NM,
                                                CLAS_NO = r.CLAS_NO,
                                                FULL_NM = r.FULL_NM,
                                                FULL_NM2 = r.FULL_NM2,
                                                ADDR_IVC = r.ADDR_IVC,
                                                ADDR_IVC2 = r.ADDR_IVC2,
                                                ADDR_OFC = r.ADDR_OFC,
                                                ADDR_OFC2 = r.ADDR_OFC2,
                                                TO_ADDR = r.TO_ADDR,
                                                TO_ADDR2 = r.TO_ADDR2,
                                                ADDR_DOC = r.ADDR_DOC,
                                                ADDR_DOC2 = r.ADDR_DOC2,
                                                ZNO_IVC = r.ZNO_IVC,
                                                ZNO_OFC = r.ZNO_OFC,
                                                ZNO_TO = r.ZNO_TO,
                                                ZNO_DOC = r.ZNO_DOC,
                                                PROPRIETOR = r.PROPRIETOR,
                                                CONTACTER = r.CONTACTER,
                                                CONTACTER2 = r.CONTACTER2,
                                                CONTACTER3 = r.CONTACTER3,
                                                TEL_NO = r.TEL_NO,
                                                TEL_NO2 = r.TEL_NO2,
                                                TEL_NO3 = r.TEL_NO3,
                                                FAX_NO = r.FAX_NO,
                                                E_MAIL = r.E_MAIL,
                                                WWW = r.WWW,
                                                UNIQUE_NO = r.UNIQUE_NO,
                                                TAX_NO = r.TAX_NO,
                                                EMP_NO = r.EMP_NO,
                                                DEPM_NO = r.DEPM_NO,
                                                SCHL_NO = r.SCHL_NO,
                                                CS_TY_NO = r.CS_TY_NO,
                                                SLN_NO = r.SLN_NO,
                                                NATION_NO = r.NATION_NO,
                                                AREA_NO = r.AREA_NO,
                                                PRC_NO = r.PRC_NO,
                                                PRC_NO1 = r.PRC_NO1,
                                                PRC_NO2 = r.PRC_NO2,
                                                PRC_NO3 = r.PRC_NO3,
                                                OPEN_DT = r.OPEN_DT,
                                                FST_DT = r.FST_DT,
                                                LST_DT = r.LST_DT,
                                                CAPITAL = r.CAPITAL,
                                                EMP_TOT = r.EMP_TOT,
                                                C_SAL = r.C_SAL,
                                                C_CRD = r.C_CRD,
                                                AR_CS_NO = r.AR_CS_NO,
                                                AR_ACT_NO = r.AR_ACT_NO,
                                                AR_BCH_NO = r.AR_BCH_NO,
                                                NR_ACT_NO = r.NR_ACT_NO,
                                                NR_BCH_NO = r.NR_BCH_NO,
                                                PR_ACT_NO = r.PR_ACT_NO,
                                                PR_BCH_NO = r.PR_BCH_NO,
                                                EAR_ACT_NO = r.EAR_ACT_NO,
                                                EAR_BCH_NO = r.EAR_BCH_NO,
                                                CURRENCY = r.CURRENCY,
                                                TAX_TY = r.TAX_TY,
                                                TAX_RT = r.TAX_RT,
                                                IVC_PAGE = r.IVC_PAGE,
                                                PRC_CDT = r.PRC_CDT,
                                                PAY_CDT = r.PAY_CDT,
                                                C_CTL = r.C_CTL,
                                                MAX_CRD = r.MAX_CRD,
                                                OVER_RT = r.OVER_RT,
                                                AR_DAY = r.AR_DAY,
                                                NR_DAY = r.NR_DAY,
                                                CASH_DAY = r.CASH_DAY,
                                                BRAND = r.BRAND,
                                                DESTINATION = r.DESTINATION,
                                                SEA_PORT = r.SEA_PORT,
                                                SEA_CORP = r.SEA_CORP,
                                                AIR_PORT = r.AIR_PORT,
                                                AIR_CORP = r.AIR_CORP,
                                                SHIP_CORP = r.SHIP_CORP,
                                                AGT_CORP = r.AGT_CORP,
                                                CLR_CORP = r.CLR_CORP,
                                                INSP_CORP = r.INSP_CORP,
                                                COMS_RATE = r.COMS_RATE,
                                                INSU_RATE = r.INSU_RATE,
                                                PRICING_SEQ = r.PRICING_SEQ,
                                                C_PRICING = r.C_PRICING,
                                                DISC_RT = r.DISC_RT,
                                                C_VCH = r.C_VCH,
                                                ACC_TY = r.ACC_TY,
                                                RCV_TY = r.RCV_TY,
                                                NOT_TY = r.NOT_TY,
                                                SHIP_TY = r.SHIP_TY,
                                                BANK = r.BANK,
                                                BANK2 = r.BANK2,
                                                BANK3 = r.BANK3,
                                                ACC_NO = r.ACC_NO,
                                                ACC_NO2 = r.ACC_NO2,
                                                ACC_NO3 = r.ACC_NO3,
                                                C_APF = r.C_APF,
                                                REMK = r.REMK,
                                                EFF_DT = r.EFF_DT,
                                                EXP_DT = r.EXP_DT,
                                                OWNER_USR_NO = r.OWNER_USR_NO,
                                                OWNER_GRP_NO = r.OWNER_GRP_NO,
                                                ADD_DT = r.ADD_DT,
                                                IP_NM = r.IP_NM,
                                                CP_NM = r.CP_NM
                                            }).ToList();
            return modelList;
        }
        /// <summary>
        /// 創建一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Create(ref ValidationErrors errors, customerModel model)
        {
            try
            {
                customer entity = m_Rep.GetById(model.CS_NO);
                if (entity != null)
                {
                    errors.Add("主鍵重複");
                    return false;
                }
                entity = new customer();
                entity.CS_NO = model.CS_NO;
                entity.SHORT_NM = model.SHORT_NM;
                entity.CLAS_NO = model.CLAS_NO;
                entity.FULL_NM = model.FULL_NM;
                entity.FULL_NM2 = model.FULL_NM2;
                entity.ADDR_IVC = model.ADDR_IVC;
                entity.ADDR_IVC2 = model.ADDR_IVC2;
                entity.ADDR_OFC = model.ADDR_OFC;
                entity.ADDR_OFC2 = model.ADDR_OFC2;
                entity.TO_ADDR = model.TO_ADDR;
                entity.TO_ADDR2 = model.TO_ADDR2;
                entity.ADDR_DOC = model.ADDR_DOC;
                entity.ADDR_DOC2 = model.ADDR_DOC2;
                entity.ZNO_IVC = model.ZNO_IVC;
                entity.ZNO_OFC = model.ZNO_OFC;
                entity.ZNO_TO = model.ZNO_TO;
                entity.ZNO_DOC = model.ZNO_DOC;
                entity.PROPRIETOR = model.PROPRIETOR;
                entity.CONTACTER = model.CONTACTER;
                entity.CONTACTER2 = model.CONTACTER2;
                entity.CONTACTER3 = model.CONTACTER3;
                entity.TEL_NO = model.TEL_NO;
                entity.TEL_NO2 = model.TEL_NO2;
                entity.TEL_NO3 = model.TEL_NO3;
                entity.FAX_NO = model.FAX_NO;
                entity.E_MAIL = model.E_MAIL;
                entity.WWW = model.WWW;
                entity.UNIQUE_NO = model.UNIQUE_NO;
                entity.TAX_NO = model.TAX_NO;
                entity.EMP_NO = model.EMP_NO;
                entity.DEPM_NO = model.DEPM_NO;
                entity.SCHL_NO = model.SCHL_NO;
                entity.CS_TY_NO = model.CS_TY_NO;
                entity.SLN_NO = model.SLN_NO;
                entity.NATION_NO = model.NATION_NO;
                entity.AREA_NO = model.AREA_NO;
                entity.PRC_NO = model.PRC_NO;
                entity.PRC_NO1 = model.PRC_NO1;
                entity.PRC_NO2 = model.PRC_NO2;
                entity.PRC_NO3 = model.PRC_NO3;
                entity.OPEN_DT = model.OPEN_DT;
                entity.FST_DT = model.FST_DT;
                entity.LST_DT = model.LST_DT;
                entity.CAPITAL = model.CAPITAL;
                entity.EMP_TOT = model.EMP_TOT;
                entity.C_SAL = model.C_SAL;
                entity.C_CRD = model.C_CRD;
                entity.AR_CS_NO = model.AR_CS_NO;
                entity.AR_ACT_NO = model.AR_ACT_NO;
                entity.AR_BCH_NO = model.AR_BCH_NO;
                entity.NR_ACT_NO = model.NR_ACT_NO;
                entity.NR_BCH_NO = model.NR_BCH_NO;
                entity.PR_ACT_NO = model.PR_ACT_NO;
                entity.PR_BCH_NO = model.PR_BCH_NO;
                entity.EAR_ACT_NO = model.EAR_ACT_NO;
                entity.EAR_BCH_NO = model.EAR_BCH_NO;
                entity.CURRENCY = model.CURRENCY;
                entity.TAX_TY = model.TAX_TY;
                entity.TAX_RT = model.TAX_RT;
                entity.IVC_PAGE = model.IVC_PAGE;
                entity.PRC_CDT = model.PRC_CDT;
                entity.PAY_CDT = model.PAY_CDT;
                entity.C_CTL = model.C_CTL;
                entity.MAX_CRD = model.MAX_CRD;
                entity.OVER_RT = model.OVER_RT;
                entity.AR_DAY = model.AR_DAY;
                entity.NR_DAY = model.NR_DAY;
                entity.CASH_DAY = model.CASH_DAY;
                entity.BRAND = model.BRAND;
                entity.DESTINATION = model.DESTINATION;
                entity.SEA_PORT = model.SEA_PORT;
                entity.SEA_CORP = model.SEA_CORP;
                entity.AIR_PORT = model.AIR_PORT;
                entity.AIR_CORP = model.AIR_CORP;
                entity.SHIP_CORP = model.SHIP_CORP;
                entity.AGT_CORP = model.AGT_CORP;
                entity.CLR_CORP = model.CLR_CORP;
                entity.INSP_CORP = model.INSP_CORP;
                entity.COMS_RATE = model.COMS_RATE;
                entity.INSU_RATE = model.INSU_RATE;
                entity.PRICING_SEQ = model.PRICING_SEQ;
                entity.C_PRICING = model.C_PRICING;
                entity.DISC_RT = model.DISC_RT;
                entity.C_VCH = model.C_VCH;
                entity.ACC_TY = model.ACC_TY;
                entity.RCV_TY = model.RCV_TY;
                entity.NOT_TY = model.NOT_TY;
                entity.SHIP_TY = model.SHIP_TY;
                entity.BANK = model.BANK;
                entity.BANK2 = model.BANK2;
                entity.BANK3 = model.BANK3;
                entity.ACC_NO = model.ACC_NO;
                entity.ACC_NO2 = model.ACC_NO2;
                entity.ACC_NO3 = model.ACC_NO3;
                entity.C_APF = model.C_APF;
                entity.REMK = model.REMK;
                entity.EFF_DT = model.EFF_DT;
                entity.EXP_DT = model.EXP_DT;
                entity.OWNER_USR_NO = model.OWNER_USR_NO;
                entity.OWNER_GRP_NO = model.OWNER_GRP_NO;
                entity.ADD_DT = model.ADD_DT;
                entity.IP_NM = model.IP_NM;
                entity.CP_NM = model.CP_NM;

                if (m_Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add("插入失敗");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 刪除一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add("刪除失敗");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 修改一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Edit(ref ValidationErrors errors, customerModel model)
        {
            try
            {
                customer entity = m_Rep.GetById(model.CS_NO);
                if (entity == null)
                {
                    errors.Add("主鍵重複");
                    return false;
                }

                entity.CS_NO = model.CS_NO;
                entity.SHORT_NM = model.SHORT_NM;
                entity.CLAS_NO = model.CLAS_NO;
                entity.FULL_NM = model.FULL_NM;
                entity.FULL_NM2 = model.FULL_NM2;
                entity.ADDR_IVC = model.ADDR_IVC;
                entity.ADDR_IVC2 = model.ADDR_IVC2;
                entity.ADDR_OFC = model.ADDR_OFC;
                entity.ADDR_OFC2 = model.ADDR_OFC2;
                entity.TO_ADDR = model.TO_ADDR;
                entity.TO_ADDR2 = model.TO_ADDR2;
                entity.ADDR_DOC = model.ADDR_DOC;
                entity.ADDR_DOC2 = model.ADDR_DOC2;
                entity.ZNO_IVC = model.ZNO_IVC;
                entity.ZNO_OFC = model.ZNO_OFC;
                entity.ZNO_TO = model.ZNO_TO;
                entity.ZNO_DOC = model.ZNO_DOC;
                entity.PROPRIETOR = model.PROPRIETOR;
                entity.CONTACTER = model.CONTACTER;
                entity.CONTACTER2 = model.CONTACTER2;
                entity.CONTACTER3 = model.CONTACTER3;
                entity.TEL_NO = model.TEL_NO;
                entity.TEL_NO2 = model.TEL_NO2;
                entity.TEL_NO3 = model.TEL_NO3;
                entity.FAX_NO = model.FAX_NO;
                entity.E_MAIL = model.E_MAIL;
                entity.WWW = model.WWW;
                entity.UNIQUE_NO = model.UNIQUE_NO;
                entity.TAX_NO = model.TAX_NO;
                entity.EMP_NO = model.EMP_NO;
                entity.DEPM_NO = model.DEPM_NO;
                entity.SCHL_NO = model.SCHL_NO;
                entity.CS_TY_NO = model.CS_TY_NO;
                entity.SLN_NO = model.SLN_NO;
                entity.NATION_NO = model.NATION_NO;
                entity.AREA_NO = model.AREA_NO;
                entity.PRC_NO = model.PRC_NO;
                entity.PRC_NO1 = model.PRC_NO1;
                entity.PRC_NO2 = model.PRC_NO2;
                entity.PRC_NO3 = model.PRC_NO3;
                entity.OPEN_DT = model.OPEN_DT;
                entity.FST_DT = model.FST_DT;
                entity.LST_DT = model.LST_DT;
                entity.CAPITAL = model.CAPITAL;
                entity.EMP_TOT = model.EMP_TOT;
                entity.C_SAL = model.C_SAL;
                entity.C_CRD = model.C_CRD;
                entity.AR_CS_NO = model.AR_CS_NO;
                entity.AR_ACT_NO = model.AR_ACT_NO;
                entity.AR_BCH_NO = model.AR_BCH_NO;
                entity.NR_ACT_NO = model.NR_ACT_NO;
                entity.NR_BCH_NO = model.NR_BCH_NO;
                entity.PR_ACT_NO = model.PR_ACT_NO;
                entity.PR_BCH_NO = model.PR_BCH_NO;
                entity.EAR_ACT_NO = model.EAR_ACT_NO;
                entity.EAR_BCH_NO = model.EAR_BCH_NO;
                entity.CURRENCY = model.CURRENCY;
                entity.TAX_TY = model.TAX_TY;
                entity.TAX_RT = model.TAX_RT;
                entity.IVC_PAGE = model.IVC_PAGE;
                entity.PRC_CDT = model.PRC_CDT;
                entity.PAY_CDT = model.PAY_CDT;
                entity.C_CTL = model.C_CTL;
                entity.MAX_CRD = model.MAX_CRD;
                entity.OVER_RT = model.OVER_RT;
                entity.AR_DAY = model.AR_DAY;
                entity.NR_DAY = model.NR_DAY;
                entity.CASH_DAY = model.CASH_DAY;
                entity.BRAND = model.BRAND;
                entity.DESTINATION = model.DESTINATION;
                entity.SEA_PORT = model.SEA_PORT;
                entity.SEA_CORP = model.SEA_CORP;
                entity.AIR_PORT = model.AIR_PORT;
                entity.AIR_CORP = model.AIR_CORP;
                entity.SHIP_CORP = model.SHIP_CORP;
                entity.AGT_CORP = model.AGT_CORP;
                entity.CLR_CORP = model.CLR_CORP;
                entity.INSP_CORP = model.INSP_CORP;
                entity.COMS_RATE = model.COMS_RATE;
                entity.INSU_RATE = model.INSU_RATE;
                entity.PRICING_SEQ = model.PRICING_SEQ;
                entity.C_PRICING = model.C_PRICING;
                entity.DISC_RT = model.DISC_RT;
                entity.C_VCH = model.C_VCH;
                entity.ACC_TY = model.ACC_TY;
                entity.RCV_TY = model.RCV_TY;
                entity.NOT_TY = model.NOT_TY;
                entity.SHIP_TY = model.SHIP_TY;
                entity.BANK = model.BANK;
                entity.BANK2 = model.BANK2;
                entity.BANK3 = model.BANK3;
                entity.ACC_NO = model.ACC_NO;
                entity.ACC_NO2 = model.ACC_NO2;
                entity.ACC_NO3 = model.ACC_NO3;
                entity.C_APF = model.C_APF;
                entity.REMK = model.REMK;
                entity.EFF_DT = model.EFF_DT;
                entity.EXP_DT = model.EXP_DT;
                entity.OWNER_USR_NO = model.OWNER_USR_NO;
                entity.OWNER_GRP_NO = model.OWNER_GRP_NO;
                entity.ADD_DT = model.ADD_DT;
                entity.IP_NM = model.IP_NM;
                entity.CP_NM = model.CP_NM;

                if (m_Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add("編輯失敗");
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 判斷是否存在實體
        /// </summary>
        /// <param name="id">主鍵ID</param>
        /// <returns>是否存在</returns>
        public bool IsExists(string id)
        {
            if (db.customer.SingleOrDefault(a => a.CS_NO == id) != null)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// 根據ID獲得一個實體
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>實體</returns>
        public customer GetById(string id)
        {
            if (IsExist(id))
            {
                customer entity = m_Rep.GetById(id);
                customer model = new customer();

                model.CS_NO = entity.CS_NO;
                model.SHORT_NM = entity.SHORT_NM;
                model.CLAS_NO = entity.CLAS_NO;
                model.FULL_NM = entity.FULL_NM;
                model.FULL_NM2 = entity.FULL_NM2;
                model.ADDR_IVC = entity.ADDR_IVC;
                model.ADDR_IVC2 = entity.ADDR_IVC2;
                model.ADDR_OFC = entity.ADDR_OFC;
                model.ADDR_OFC2 = entity.ADDR_OFC2;
                model.TO_ADDR = entity.TO_ADDR;
                model.TO_ADDR2 = entity.TO_ADDR2;
                model.ADDR_DOC = entity.ADDR_DOC;
                model.ADDR_DOC2 = entity.ADDR_DOC2;
                model.ZNO_IVC = entity.ZNO_IVC;
                model.ZNO_OFC = entity.ZNO_OFC;
                model.ZNO_TO = entity.ZNO_TO;
                model.ZNO_DOC = entity.ZNO_DOC;
                model.PROPRIETOR = entity.PROPRIETOR;
                model.CONTACTER = entity.CONTACTER;
                model.CONTACTER2 = entity.CONTACTER2;
                model.CONTACTER3 = entity.CONTACTER3;
                model.TEL_NO = entity.TEL_NO;
                model.TEL_NO2 = entity.TEL_NO2;
                model.TEL_NO3 = entity.TEL_NO3;
                model.FAX_NO = entity.FAX_NO;
                model.E_MAIL = entity.E_MAIL;
                model.WWW = entity.WWW;
                model.UNIQUE_NO = entity.UNIQUE_NO;
                model.TAX_NO = entity.TAX_NO;
                model.EMP_NO = entity.EMP_NO;
                model.DEPM_NO = entity.DEPM_NO;
                model.SCHL_NO = entity.SCHL_NO;
                model.CS_TY_NO = entity.CS_TY_NO;
                model.SLN_NO = entity.SLN_NO;
                model.NATION_NO = entity.NATION_NO;
                model.AREA_NO = entity.AREA_NO;
                model.PRC_NO = entity.PRC_NO;
                model.PRC_NO1 = entity.PRC_NO1;
                model.PRC_NO2 = entity.PRC_NO2;
                model.PRC_NO3 = entity.PRC_NO3;
                model.OPEN_DT = entity.OPEN_DT;
                model.FST_DT = entity.FST_DT;
                model.LST_DT = entity.LST_DT;
                model.CAPITAL = entity.CAPITAL;
                model.EMP_TOT = entity.EMP_TOT;
                model.C_SAL = entity.C_SAL;
                model.C_CRD = entity.C_CRD;
                model.AR_CS_NO = entity.AR_CS_NO;
                model.AR_ACT_NO = entity.AR_ACT_NO;
                model.AR_BCH_NO = entity.AR_BCH_NO;
                model.NR_ACT_NO = entity.NR_ACT_NO;
                model.NR_BCH_NO = entity.NR_BCH_NO;
                model.PR_ACT_NO = entity.PR_ACT_NO;
                model.PR_BCH_NO = entity.PR_BCH_NO;
                model.EAR_ACT_NO = entity.EAR_ACT_NO;
                model.EAR_BCH_NO = entity.EAR_BCH_NO;
                model.CURRENCY = entity.CURRENCY;
                model.TAX_TY = entity.TAX_TY;
                model.TAX_RT = entity.TAX_RT;
                model.IVC_PAGE = entity.IVC_PAGE;
                model.PRC_CDT = entity.PRC_CDT;
                model.PAY_CDT = entity.PAY_CDT;
                model.C_CTL = entity.C_CTL;
                model.MAX_CRD = entity.MAX_CRD;
                model.OVER_RT = entity.OVER_RT;
                model.AR_DAY = entity.AR_DAY;
                model.NR_DAY = entity.NR_DAY;
                model.CASH_DAY = entity.CASH_DAY;
                model.BRAND = entity.BRAND;
                model.DESTINATION = entity.DESTINATION;
                model.SEA_PORT = entity.SEA_PORT;
                model.SEA_CORP = entity.SEA_CORP;
                model.AIR_PORT = entity.AIR_PORT;
                model.AIR_CORP = entity.AIR_CORP;
                model.SHIP_CORP = entity.SHIP_CORP;
                model.AGT_CORP = entity.AGT_CORP;
                model.CLR_CORP = entity.CLR_CORP;
                model.INSP_CORP = entity.INSP_CORP;
                model.COMS_RATE = entity.COMS_RATE;
                model.INSU_RATE = entity.INSU_RATE;
                model.PRICING_SEQ = entity.PRICING_SEQ;
                model.C_PRICING = entity.C_PRICING;
                model.DISC_RT = entity.DISC_RT;
                model.C_VCH = entity.C_VCH;
                model.ACC_TY = entity.ACC_TY;
                model.RCV_TY = entity.RCV_TY;
                model.NOT_TY = entity.NOT_TY;
                model.SHIP_TY = entity.SHIP_TY;
                model.BANK = entity.BANK;
                model.BANK2 = entity.BANK2;
                model.BANK3 = entity.BANK3;
                model.ACC_NO = entity.ACC_NO;
                model.ACC_NO2 = entity.ACC_NO2;
                model.ACC_NO3 = entity.ACC_NO3;
                model.C_APF = entity.C_APF;
                model.REMK = entity.REMK;
                model.EFF_DT = entity.EFF_DT;
                model.EXP_DT = entity.EXP_DT;
                model.OWNER_USR_NO = entity.OWNER_USR_NO;
                model.OWNER_GRP_NO = entity.OWNER_GRP_NO;
                model.ADD_DT = entity.ADD_DT;
                model.IP_NM = entity.IP_NM;
                model.CP_NM = entity.CP_NM;

                return model;
            }
            else
            {
                return new customer();
            }
        }

        /// <summary>
        /// 判斷一個實體是否存在
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
