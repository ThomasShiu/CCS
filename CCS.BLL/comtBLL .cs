using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.SAL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CCS.BLL
{
    public class comtBLL: BaseBLL, IcomtBLL
    {
        [Dependency]
        public IcomtRepository m_Rep { get; set; }

        public List<COMTModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<V_COMT> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.VCH_TY.Contains(queryStr) || a.VCH_NO.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<COMTModel> CreateModelList(ref IQueryable<V_COMT> queryData)
        {

            List<COMTModel> modelList = (from r in queryData
                                         select new COMTModel
                                         {
                                             ID = r.ID,
                                             VCH_TY = r.VCH_TY,
                                             VCH_NO = r.VCH_NO,
                                             VCH_DT = r.VCH_DT,
                                             CS_NO = r.CS_NO,
                                             FULL_NM = r.FULL_NM,
                                             DEPM_NO = r.DEPM_NO,
                                             DEPM_NM = r.DEPM_NM,
                                             EMP_NO = r.EMP_NO,
                                             EMP_NM = r.EMP_NM,
                                             TAX_TY = r.TAX_TY,
                                             TAX_RT = r.TAX_RT.Value,
                                             PAY_CDT = r.PAY_CDT,
                                             PAY_CDT_NM = r.PAY_CDT_NM,
                                             CS_VCH_NO = r.CS_VCH_NO,
                                             CONTACTER = r.CONTACTER,
                                             TO_ADDR = r.TO_ADDR,
                                             CURRENCY = r.CURRENCY,
                                             EXCH_RATE = r.EXCH_RATE.Value,
                                             WAHO_NO = r.WAHO_NO,
                                             WAHO_NM = r.WAHO_NM,
                                             AMT = r.AMT.Value,
                                             TAX = r.TAX.Value,
                                             QTY = r.QTY.Value,
                                             N_PRT = r.N_PRT.Value,
                                             C_SIGN = r.C_SIGN,
                                             C_CFM = r.C_CFM,
                                             CFM_DT = r.CFM_DT.Value
                                         }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, COMTModel model)
        {
            try
            {
                V_COMT entity = m_Rep.GetById(model.VCH_NO);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new V_COMT();
                entity.ID = model.ID;
                entity.VCH_TY = model.VCH_TY;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.CS_NO = model.CS_NO;
                entity.FULL_NM = model.FULL_NM;
                entity.DEPM_NO = model.DEPM_NO;
                entity.DEPM_NM = model.DEPM_NM;
                entity.EMP_NO = model.EMP_NO;
                entity.EMP_NM = model.EMP_NM;
                entity.TAX_TY = model.TAX_TY;
                entity.TAX_RT = model.TAX_RT;
                entity.PAY_CDT = model.PAY_CDT;
                entity.PAY_CDT_NM = model.PAY_CDT_NM;
                entity.CS_VCH_NO = model.CS_VCH_NO;
                entity.CONTACTER = model.CONTACTER;
                entity.TO_ADDR = model.TO_ADDR;
                entity.CURRENCY = model.CURRENCY;
                entity.EXCH_RATE = model.EXCH_RATE;
                entity.WAHO_NO = model.WAHO_NO;
                entity.WAHO_NM = model.WAHO_NM;
                entity.AMT = model.AMT;
                entity.TAX = model.TAX;
                entity.QTY = model.QTY;
                entity.N_PRT = model.N_PRT;
                entity.C_SIGN = model.C_SIGN;
                entity.C_CFM = model.C_CFM;
                entity.CFM_DT = model.CFM_DT;
                if (m_Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
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
                        m_Rep.Delete(db, deleteCollection);
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
        public bool Edit(ref ValidationErrors errors, COMTModel model)
        {
            try
            {
                V_COMT entity = m_Rep.GetById(model.VCH_NO);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.ID = model.ID;
                entity.VCH_TY = model.VCH_TY;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.CS_NO = model.CS_NO;
                entity.FULL_NM = model.FULL_NM;
                entity.DEPM_NO = model.DEPM_NO;
                entity.DEPM_NM = model.DEPM_NM;
                entity.EMP_NO = model.EMP_NO;
                entity.EMP_NM = model.EMP_NM;
                entity.TAX_TY = model.TAX_TY;
                entity.TAX_RT = model.TAX_RT;
                entity.PAY_CDT = model.PAY_CDT;
                entity.PAY_CDT_NM = model.PAY_CDT_NM;
                entity.CS_VCH_NO = model.CS_VCH_NO;
                entity.CONTACTER = model.CONTACTER;
                entity.TO_ADDR = model.TO_ADDR;
                entity.CURRENCY = model.CURRENCY;
                entity.EXCH_RATE = model.EXCH_RATE;
                entity.WAHO_NO = model.WAHO_NO;
                entity.WAHO_NM = model.WAHO_NM;
                entity.AMT = model.AMT;
                entity.TAX = model.TAX;
                entity.QTY = model.QTY;
                entity.N_PRT = model.N_PRT;
                entity.C_SIGN = model.C_SIGN;
                entity.C_CFM = model.C_CFM;
                entity.CFM_DT = model.CFM_DT;

                if (m_Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.EditFail);
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

        public bool IsExists(string id)
        {
            if (db.COMT.SingleOrDefault(a => a.VCH_NO == id) != null)
            {
                return true;
            }
            return false;
        }

        public COMTModel GetById(string id)
        {
            if (IsExist(id))
            {
                V_COMT entity = m_Rep.GetById(id);
                COMTModel model = new COMTModel();
                model.ID = entity.ID;
                model.VCH_TY = entity.VCH_TY;
                model.VCH_NO = entity.VCH_NO;
                model.VCH_DT = entity.VCH_DT;
                model.CS_NO = entity.CS_NO;
                model.FULL_NM = entity.FULL_NM;
                model.DEPM_NO = entity.DEPM_NO;
                model.DEPM_NM = entity.DEPM_NM;
                model.EMP_NO = entity.EMP_NO;
                model.EMP_NM = entity.EMP_NM;
                model.TAX_TY = entity.TAX_TY;
                model.TAX_RT = entity.TAX_RT.Value;
                model.PAY_CDT = entity.PAY_CDT;
                model.PAY_CDT_NM = entity.PAY_CDT_NM;
                model.CS_VCH_NO = entity.CS_VCH_NO;
                model.CONTACTER = entity.CONTACTER;
                model.TO_ADDR = entity.TO_ADDR;
                model.CURRENCY = entity.CURRENCY;
                model.EXCH_RATE = entity.EXCH_RATE.Value;
                model.WAHO_NO = entity.WAHO_NO;
                model.WAHO_NM = entity.WAHO_NM;
                model.AMT = entity.AMT.Value;
                model.TAX = entity.TAX.Value;
                model.QTY = entity.QTY.Value;
                model.N_PRT = entity.N_PRT.Value;
                model.C_SIGN = entity.C_SIGN;
                model.C_CFM = entity.C_CFM;
                model.CFM_DT = entity.CFM_DT.Value;
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }

    }
}
