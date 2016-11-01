using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.MAN;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CCS.BLL
{
    public class cs_wipfBLL : BaseBLL, Ics_wipfBLL
    {
        [Dependency]
        public Ics_wipfRepository m_Rep { get; set; }

        public List<cs_wipfModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_WIP_F> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.LOT_NO.Contains(queryStr) );
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_wipfModel> CreateModelList(ref IQueryable<CS_WIP_F> queryData)
        {

            List<cs_wipfModel> modelList = (from r in queryData
                                             select new cs_wipfModel
                                             {
                                                 Id = r.Id,
                                                 LOT_NO = r.LOT_NO,
                                                 HEAT_NO = r.HEAT_NO,
                                                 KEG_NO = r.KEG_NO,
                                                 KEG_CNT = r.KEG_CNT,
                                                 PRCS_TY = r.PRCS_TY,
                                                 PRCS_NO = r.PRCS_NO,
                                                 EMP_NO = r.EMP_NO,
                                                 EMP_NM = r.EMP_NM,
                                                 MACHINE = r.MACHINE,
                                                 BDT = r.BDT ,
                                                 EDT = r.EDT,
                                                 WEIGHT = r.WEIGHT,
                                                 UNIT_WT = r.UNIT_WT,
                                                 COUNT_QTY = r.COUNT_QTY,
                                                 END_CODE = r.END_CODE,
                                                 EXC_INSDBID = r.EXC_INSDBID,
                                                 EXC_INSDATE = r.EXC_INSDATE.Value,
                                                 EXC_UPDDBID = r.EXC_UPDDBID,
                                                 EXC_UPDDATE = r.EXC_UPDDATE.Value,
                                                 EXC_SYSOWNR = r.EXC_SYSOWNR,
                                                 EXC_ISLOCKED = r.EXC_ISLOCKED,
                                                 EXC_COMPANY = r.EXC_COMPANY
                                             }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, cs_wipfModel model)
        {
            try
            {
                CS_WIP_F entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_WIP_F();
                entity.Id = model.Id;
                entity.LOT_NO = model.LOT_NO;
                entity.HEAT_NO = model.HEAT_NO;
                entity.KEG_NO = model.KEG_NO;
                entity.KEG_CNT = model.KEG_CNT;
                entity.PRCS_TY = model.PRCS_TY;
                entity.PRCS_NO = model.PRCS_NO;
                entity.EMP_NO = model.EMP_NO;
                entity.EMP_NM = model.EMP_NM;
                entity.MACHINE = model.MACHINE;
                entity.BDT = model.BDT;
                entity.EDT = model.EDT;
                entity.WEIGHT = model.WEIGHT;
                entity.UNIT_WT = model.UNIT_WT;
                entity.COUNT_QTY = model.COUNT_QTY;
                entity.END_CODE = model.END_CODE;
                entity.EXC_INSDBID = model.EXC_INSDBID;
                entity.EXC_INSDATE = model.EXC_INSDATE;
                entity.EXC_UPDDBID = model.EXC_UPDDBID;
                entity.EXC_UPDDATE = model.EXC_UPDDATE;
                entity.EXC_SYSOWNR = model.EXC_SYSOWNR;
                entity.EXC_ISLOCKED = model.EXC_ISLOCKED;
                entity.EXC_COMPANY = model.EXC_COMPANY;
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
                String innerMessage = (ex.InnerException != null) ? ex.InnerException.InnerException.Message:"";
                errors.Add(ex.Message+"<br/>"+ innerMessage);
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
        public bool Edit(ref ValidationErrors errors, cs_wipfModel model)
        {
            try
            {
                CS_WIP_F entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.LOT_NO = model.LOT_NO;
                entity.HEAT_NO = model.HEAT_NO;
                entity.KEG_NO = model.KEG_NO;
                entity.PRCS_TY = model.PRCS_TY;
                entity.PRCS_NO = model.PRCS_NO;
                entity.EMP_NO = model.EMP_NO;
                entity.EMP_NM = model.EMP_NM;
                entity.MACHINE = model.MACHINE;
                entity.BDT = model.BDT;
                entity.EDT = model.EDT;
                entity.WEIGHT = model.WEIGHT;
                entity.UNIT_WT = model.UNIT_WT;
                entity.COUNT_QTY = model.COUNT_QTY;
                entity.END_CODE = model.END_CODE;
                entity.EXC_INSDBID = model.EXC_INSDBID;
                entity.EXC_INSDATE = model.EXC_INSDATE;
                entity.EXC_UPDDBID = model.EXC_UPDDBID;
                entity.EXC_UPDDATE = model.EXC_UPDDATE;
                entity.EXC_SYSOWNR = model.EXC_SYSOWNR;
                entity.EXC_ISLOCKED = model.EXC_ISLOCKED;
                entity.EXC_COMPANY = model.EXC_COMPANY;

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
            if (db.CS_WIP_F.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_wipfModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_WIP_F entity = m_Rep.GetById(id);
                cs_wipfModel model = new cs_wipfModel();
                model.Id = entity.Id;
                model.LOT_NO = entity.LOT_NO;
                model.HEAT_NO = entity.HEAT_NO;
                model.KEG_NO = entity.KEG_NO;
                entity.KEG_CNT = model.KEG_CNT;
                model.PRCS_TY = entity.PRCS_TY;
                model.PRCS_NO = entity.PRCS_NO;
                model.EMP_NO = entity.EMP_NO;
                model.EMP_NM = entity.EMP_NM;
                model.MACHINE = entity.MACHINE;
                model.BDT = entity.BDT;
                model.EDT = entity.EDT;
                model.WEIGHT = entity.WEIGHT;
                model.UNIT_WT = entity.UNIT_WT;
                model.COUNT_QTY = entity.COUNT_QTY;
                model.END_CODE = entity.END_CODE;
                model.EXC_INSDBID = entity.EXC_INSDBID;
                model.EXC_INSDATE = entity.EXC_INSDATE.Value;
                model.EXC_UPDDBID = entity.EXC_UPDDBID;
                model.EXC_UPDDATE = entity.EXC_UPDDATE.Value;
                model.EXC_SYSOWNR = entity.EXC_SYSOWNR;
                model.EXC_ISLOCKED = entity.EXC_ISLOCKED;
                model.EXC_COMPANY = entity.EXC_COMPANY;
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