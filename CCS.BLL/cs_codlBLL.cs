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
    public class cs_codlBLL : BaseBLL, Ics_codlBLL
    {
        [Dependency]
        public Ics_codlRepository m_Rep { get; set; }

        public List<cs_codlModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_CODL> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.VCH_NO.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        public List<cs_codlModel> GetList(string queryStr)
        {

            IQueryable<CS_CODL> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.VCH_NO.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }

            return CreateModelList(ref queryData);
        }

        private List<cs_codlModel> CreateModelList(ref IQueryable<CS_CODL> queryData)
        {

            List<cs_codlModel> modelList = (from r in queryData
                                            select new cs_codlModel
                                            {
                                                ID = r.ID,
                                                VCH_NO = r.VCH_NO,
                                                VCH_SR = r.VCH_SR,
                                                ITEM_NO = r.ITEM_NO,
                                                ITEM_NM = r.ITEM_NM,
                                                ITEM_SP = r.ITEM_SP,
                                                CS_ITEM_NO = r.CS_ITEM_NO,
                                                UNIT = r.UNIT,
                                                QTY = r.QTY.Value,
                                                PRC = r.PRC.Value,
                                                AMT = r.AMT.Value,
                                                PRCV_DT = r.PRCV_DT,
                                                C_CLS = r.C_CLS,
                                                REMK = r.REMK,
                                                ADD_DT = r.ADD_DT.Value,
                                                CFM_USR_NO = r.CFM_USR_NO,
                                                MDY_USR_NO = r.MDY_USR_NO,
                                                MDY_DT = r.MDY_DT.Value,
                                                IP_NM = r.IP_NM,
                                                CP_NM = r.CP_NM
                                            }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, cs_codlModel model)
        {
            try
            {
                CS_CODL entity = m_Rep.GetById(model.ID);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_CODL();
                entity.ID = model.ID;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_SR = model.VCH_SR;
                entity.ITEM_NO = model.ITEM_NO;
                entity.ITEM_NM = model.ITEM_NM;
                entity.ITEM_SP = model.ITEM_SP;
                entity.CS_ITEM_NO = model.CS_ITEM_NO;
                entity.UNIT = model.UNIT;
                entity.QTY = model.QTY;
                entity.PRC = model.PRC;
                entity.AMT = model.AMT;
                entity.PRCV_DT = model.PRCV_DT;
                entity.C_CLS = model.C_CLS;
                entity.REMK = model.REMK;
                entity.ADD_DT = model.ADD_DT;
                entity.CFM_USR_NO = model.CFM_USR_NO;
                entity.MDY_USR_NO = model.MDY_USR_NO;
                entity.MDY_DT = model.MDY_DT;
                entity.IP_NM = model.IP_NM;
                entity.CP_NM = model.CP_NM;

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

        public bool Delete(ref ValidationErrors errors, int id)
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
        public bool Edit(ref ValidationErrors errors, cs_codlModel model)
        {
            try
            {
                CS_CODL entity = m_Rep.GetById(model.ID);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.ID = model.ID;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_SR = model.VCH_SR;
                entity.ITEM_NO = model.ITEM_NO;
                entity.ITEM_NM = model.ITEM_NM;
                entity.ITEM_SP = model.ITEM_SP;
                entity.CS_ITEM_NO = model.CS_ITEM_NO;
                entity.UNIT = model.UNIT;
                entity.QTY = model.QTY;
                entity.PRC = model.PRC;
                entity.AMT = model.AMT;
                entity.PRCV_DT = model.PRCV_DT;
                entity.C_CLS = model.C_CLS;
                entity.REMK = model.REMK;
                entity.ADD_DT = model.ADD_DT;
                entity.CFM_USR_NO = model.CFM_USR_NO;
                entity.MDY_USR_NO = model.MDY_USR_NO;
                entity.MDY_DT = model.MDY_DT;
                entity.IP_NM = model.IP_NM;
                entity.CP_NM = model.CP_NM;

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

        public bool IsExists(int id)
        {
            if (db.CS_CODL.SingleOrDefault(a => a.ID == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_codlModel GetById(int id)
        {
            if (IsExist(id))
            {
                CS_CODL entity = m_Rep.GetById(id);
                cs_codlModel model = new cs_codlModel();
                model.ID = entity.ID;
                model.VCH_NO = entity.VCH_NO;
                model.VCH_SR = entity.VCH_SR;
                model.ITEM_NO = entity.ITEM_NO;
                model.ITEM_NM = entity.ITEM_NM;
                model.ITEM_SP = entity.ITEM_SP;
                model.CS_ITEM_NO = entity.CS_ITEM_NO;
                model.UNIT = entity.UNIT;
                model.QTY = entity.QTY.Value;
                model.PRC = entity.PRC.Value;
                model.AMT = entity.AMT.Value;
                model.PRCV_DT = entity.PRCV_DT;
                model.C_CLS = entity.C_CLS;
                model.REMK = entity.REMK;
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
                return null;
            }
        }

        public bool IsExist(int id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
