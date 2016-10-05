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
using System.Transactions;
using CCS.Models.SYS;
using System.Data.Entity.Validation;

namespace CCS.BLL
{
    public  class cs_comtBLL : BaseBLL,Ics_comtBLL
    {

       // CCSEntities db = new CCSEntities();

        //public ISysSampleRepository Rep { get; set; }
        //ICS_COMTRepository Rep = new CS_COMTRepository();

        [Dependency]
        public Ics_comtRepository Rep { get; set; }

        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="pager">JQgrid分頁</param>
        /// <param name="queryStr">搜索條件</param>
        /// <returns>列表</returns>
        public List<cs_comtModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<CS_COMT> queryData = null;
            //queryData = Rep.GetList(db);
            //return CreateModelList(ref queryData);

            queryData = Rep.GetList(db);

            //排序 由大到小
            queryData = LinqHelper.DataSorting(queryData, pager.sort, pager.order);

            if (queryStr != null & queryStr != "")
            {
                queryData = queryData.Where(c => c.VCH_NO.Contains(queryStr));
            }
            return CreateModelList(ref pager, ref queryData);

        }
        private List<cs_comtModel> CreateModelList(ref GridPager pager, ref IQueryable<CS_COMT> queryData)
        {
            pager.totalRows = queryData.Count();
            if (pager.totalRows > 0)
            {
                if (pager.page <= 1)
                {
                    queryData = queryData.Take(pager.rows);
                }
                else
                {
                    queryData = queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
                }
            }

            List<cs_comtModel> modelList = (from r in queryData
                                            select new cs_comtModel
                                            {
                                                VCH_NO = r.VCH_NO,
                                                VCH_DT = r.VCH_DT,
                                                FA_NO = r.FA_NO,
                                                CS_NO = r.CS_NO,
                                                CS_NM = r.CS_NM,
                                                DEPM_NO = r.DEPM_NO,
                                                EMP_NO = r.EMP_NO,
                                                EMP_NAME = r.EMP_NAME,
                                                CS_VCH_NO = r.CS_VCH_NO,
                                                CONTACTER = r.CONTACTER,
                                                TAX_TY = r.TAX_TY,
                                                TAX_RT = r.TAX_RT.Value,
                                                PRC_CDT = r.PRC_CDT,
                                                PAY_CDT = r.PAY_CDT,
                                                TO_ADDR = r.TO_ADDR,
                                                TO_ADDR2 = r.TO_ADDR2,
                                                TEL_NO = r.TEL_NO,
                                                FAX_NO = r.FAX_NO,
                                                CURRENCY = r.CURRENCY,
                                                EXCH_RATE = r.EXCH_RATE.Value,
                                                WAHO_NO = r.WAHO_NO,
                                                LC_NO = r.LC_NO,
                                                SHIP_TY = r.SHIP_TY,
                                                STR_PORT = r.STR_PORT,
                                                DES_PORT = r.DES_PORT,
                                                AGT_CORP = r.AGT_CORP,
                                                CLR_CORP = r.CLR_CORP,
                                                INSP_CORP = r.INSP_CORP,
                                                SHIP_CORP = r.SHIP_CORP,
                                                MARK_NO = r.MARK_NO,
                                                FL_MARK = r.FL_MARK,
                                                SL_MARK = r.SL_MARK,
                                                CONSIGNEE = r.CONSIGNEE,
                                                NOTIFY = r.NOTIFY,
                                                DES_PLACE = r.DES_PLACE,
                                                BANK_NO = r.BANK_NO,
                                                PACK_REMK = r.PACK_REMK,
                                                IVC_REMK = r.IVC_REMK,
                                                REMK = r.REMK,
                                                ATTR_NO1 = r.ATTR_NO1,
                                                ATTR_NO2 = r.ATTR_NO2,
                                                ATTR_NO3 = r.ATTR_NO3,
                                                N_PRT = r.N_PRT.Value,
                                                C_SIGN = r.C_SIGN,
                                                C_CFM = r.C_CFM,
                                                CFM_DT = r.CFM_DT.Value,
                                                OWNER_USR_NO = r.OWNER_USR_NO,
                                                OWNER_GRP_NO = r.OWNER_GRP_NO,
                                                ADD_DT = r.ADD_DT.Value,
                                                CFM_USR_NO = r.CFM_USR_NO,
                                                MDY_USR_NO = r.MDY_USR_NO,
                                                MDY_DT = r.MDY_DT.Value,
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
        public bool Create(ref ValidationErrors errors, cs_comtModel model)
        {
            try
            {
                CS_COMT entity = Rep.GetById(model.VCH_NO);
                if (entity != null)
                {
                    errors.Add("主鍵重複");
                    return false;
                }

                entity = new CS_COMT();
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.FA_NO = model.FA_NO;
                entity.CS_NO = model.CS_NO;
                entity.CS_NM = model.CS_NM;
                entity.DEPM_NO = model.DEPM_NO;
                entity.EMP_NO = model.EMP_NO;
                entity.EMP_NAME = model.EMP_NAME;
                entity.CS_VCH_NO = model.CS_VCH_NO;
                entity.CONTACTER = model.CONTACTER;
                entity.TAX_TY = model.TAX_TY;
                entity.TAX_RT = model.TAX_RT;
                entity.PRC_CDT = model.PRC_CDT;
                entity.PAY_CDT = model.PAY_CDT;
                entity.TO_ADDR = model.TO_ADDR;
                entity.TO_ADDR2 = model.TO_ADDR2;
                entity.TEL_NO = model.TEL_NO;
                entity.FAX_NO = model.FAX_NO;
                entity.CURRENCY = model.CURRENCY;
                entity.EXCH_RATE = model.EXCH_RATE;
                entity.WAHO_NO = model.WAHO_NO;
                entity.LC_NO = model.LC_NO;
                entity.SHIP_TY = model.SHIP_TY;
                entity.STR_PORT = model.STR_PORT;
                entity.DES_PORT = model.DES_PORT;
                entity.AGT_CORP = model.AGT_CORP;
                entity.CLR_CORP = model.CLR_CORP;
                entity.INSP_CORP = model.INSP_CORP;
                entity.SHIP_CORP = model.SHIP_CORP;
                entity.MARK_NO = model.MARK_NO;
                entity.FL_MARK = model.FL_MARK;
                entity.SL_MARK = model.SL_MARK;
                entity.CONSIGNEE = model.CONSIGNEE;
                entity.NOTIFY = model.NOTIFY;
                entity.DES_PLACE = model.DES_PLACE;
                entity.BANK_NO = model.BANK_NO;
                entity.PACK_REMK = model.PACK_REMK;
                entity.IVC_REMK = model.IVC_REMK;
                entity.REMK = model.REMK;
                entity.ATTR_NO1 = model.ATTR_NO1;
                entity.ATTR_NO2 = model.ATTR_NO2;
                entity.ATTR_NO3 = model.ATTR_NO3;
                entity.N_PRT = model.N_PRT;
                entity.C_SIGN = model.C_SIGN;
                entity.C_CFM = model.C_CFM;
                entity.CFM_DT = model.CFM_DT;
                entity.OWNER_USR_NO = model.OWNER_USR_NO;
                entity.OWNER_GRP_NO = model.OWNER_GRP_NO;
                entity.ADD_DT = model.ADD_DT;
                entity.CFM_USR_NO = model.CFM_USR_NO;
                entity.MDY_USR_NO = model.MDY_USR_NO;
                entity.MDY_DT = model.MDY_DT;
                entity.IP_NM = model.IP_NM;
                entity.CP_NM = model.CP_NM;

                if (Rep.Create(entity) == 1)
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
                if (Rep.Delete(id) == 1)
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
        public bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        Rep.Delete(db, deleteCollection);
                        if (db.SaveChanges() == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
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
        public bool Edit(ref ValidationErrors errors, cs_comtModel model)
        {
            try
            {
                CS_COMT entity = Rep.GetById(model.VCH_NO);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }

                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.FA_NO = model.FA_NO;
                entity.CS_NO = model.CS_NO;
                entity.CS_NM = model.CS_NM;
                entity.DEPM_NO = model.DEPM_NO;
                entity.EMP_NO = model.EMP_NO;
                entity.EMP_NAME = model.EMP_NAME;
                entity.CS_VCH_NO = model.CS_VCH_NO;
                entity.CONTACTER = model.CONTACTER;
                entity.TAX_TY = model.TAX_TY;
                entity.TAX_RT = model.TAX_RT;
                entity.PRC_CDT = model.PRC_CDT;
                entity.PAY_CDT = model.PAY_CDT;
                entity.TO_ADDR = model.TO_ADDR;
                entity.TO_ADDR2 = model.TO_ADDR2;
                entity.TEL_NO = model.TEL_NO;
                entity.FAX_NO = model.FAX_NO;
                entity.CURRENCY = model.CURRENCY;
                entity.EXCH_RATE = model.EXCH_RATE;
                entity.WAHO_NO = model.WAHO_NO;
                entity.LC_NO = model.LC_NO;
                entity.SHIP_TY = model.SHIP_TY;
                entity.STR_PORT = model.STR_PORT;
                entity.DES_PORT = model.DES_PORT;
                entity.AGT_CORP = model.AGT_CORP;
                entity.CLR_CORP = model.CLR_CORP;
                entity.INSP_CORP = model.INSP_CORP;
                entity.SHIP_CORP = model.SHIP_CORP;
                entity.MARK_NO = model.MARK_NO;
                entity.FL_MARK = model.FL_MARK;
                entity.SL_MARK = model.SL_MARK;
                entity.CONSIGNEE = model.CONSIGNEE;
                entity.NOTIFY = model.NOTIFY;
                entity.DES_PLACE = model.DES_PLACE;
                entity.BANK_NO = model.BANK_NO;
                entity.PACK_REMK = model.PACK_REMK;
                entity.IVC_REMK = model.IVC_REMK;
                entity.REMK = model.REMK;
                entity.ATTR_NO1 = model.ATTR_NO1;
                entity.ATTR_NO2 = model.ATTR_NO2;
                entity.ATTR_NO3 = model.ATTR_NO3;
                entity.N_PRT = model.N_PRT;
                entity.C_SIGN = model.C_SIGN;
                entity.C_CFM = model.C_CFM;
                entity.CFM_DT = model.CFM_DT;
                entity.OWNER_USR_NO = model.OWNER_USR_NO;
                entity.OWNER_GRP_NO = model.OWNER_GRP_NO;
                entity.ADD_DT = model.ADD_DT;
                entity.CFM_USR_NO = model.CFM_USR_NO;
                entity.MDY_USR_NO = model.MDY_USR_NO;
                entity.MDY_DT = model.MDY_DT;
                entity.IP_NM = model.IP_NM;
                entity.CP_NM = model.CP_NM;

                if (Rep.Edit(entity) == 1)
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
            if (db.CS_COMT.SingleOrDefault(a => a.VCH_NO == id) != null)
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
        public cs_comtModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_COMT entity = Rep.GetById(id);
                cs_comtModel model = new cs_comtModel();

                model.VCH_NO = entity.VCH_NO;
                model.VCH_DT = entity.VCH_DT;
                model.FA_NO = entity.FA_NO;
                model.CS_NO = entity.CS_NO;
                model.CS_NM = entity.CS_NM;
                model.DEPM_NO = entity.DEPM_NO;
                model.EMP_NO = entity.EMP_NO;
                model.EMP_NAME = entity.EMP_NAME;
                model.CS_VCH_NO = entity.CS_VCH_NO;
                model.CONTACTER = entity.CONTACTER;
                model.TAX_TY = entity.TAX_TY;
                model.TAX_RT = entity.TAX_RT.Value;
                model.PRC_CDT = entity.PRC_CDT;
                model.PAY_CDT = entity.PAY_CDT;
                model.TO_ADDR = entity.TO_ADDR;
                model.TO_ADDR2 = entity.TO_ADDR2;
                model.TEL_NO = entity.TEL_NO;
                model.FAX_NO = entity.FAX_NO;
                model.CURRENCY = entity.CURRENCY;
                model.EXCH_RATE = entity.EXCH_RATE.Value;
                model.WAHO_NO = entity.WAHO_NO;
                model.LC_NO = entity.LC_NO;
                model.SHIP_TY = entity.SHIP_TY;
                model.STR_PORT = entity.STR_PORT;
                model.DES_PORT = entity.DES_PORT;
                model.AGT_CORP = entity.AGT_CORP;
                model.CLR_CORP = entity.CLR_CORP;
                model.INSP_CORP = entity.INSP_CORP;
                model.SHIP_CORP = entity.SHIP_CORP;
                model.MARK_NO = entity.MARK_NO;
                model.FL_MARK = entity.FL_MARK;
                model.SL_MARK = entity.SL_MARK;
                model.CONSIGNEE = entity.CONSIGNEE;
                model.NOTIFY = entity.NOTIFY;
                model.DES_PLACE = entity.DES_PLACE;
                model.BANK_NO = entity.BANK_NO;
                model.PACK_REMK = entity.PACK_REMK;
                model.IVC_REMK = entity.IVC_REMK;
                model.REMK = entity.REMK;
                model.ATTR_NO1 = entity.ATTR_NO1;
                model.ATTR_NO2 = entity.ATTR_NO2;
                model.ATTR_NO3 = entity.ATTR_NO3;
                model.N_PRT = entity.N_PRT.Value;
                model.C_SIGN = entity.C_SIGN;
                model.C_CFM = entity.C_CFM;
                model.CFM_DT = entity.CFM_DT.Value;
                model.OWNER_USR_NO = entity.OWNER_USR_NO;
                model.OWNER_GRP_NO = entity.OWNER_GRP_NO;
                model.ADD_DT = entity.ADD_DT.Value;
                model.CFM_USR_NO = entity.CFM_USR_NO;
                model.MDY_USR_NO = entity.MDY_USR_NO;
                model.MDY_DT = entity.MDY_DT.Value;
                model.IP_NM = entity.IP_NM;
                model.CP_NM = entity.CP_NM;

                return model;
            }
            else
            {
                return new cs_comtModel();
            }
        }

        /// <summary>
        /// 判斷一個實體是否存在
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            return Rep.IsExist(id);
        }

    }
}
