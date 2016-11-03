﻿using CCS.BLL.Core;
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
    public class codlBLL : BaseBLL, IcodlBLL
    {
        [Dependency]
        public IcodlRepository m_Rep { get; set; }

        public List<CODLModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<V_CODL> queryData = null;
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
        private List<CODLModel> CreateModelList(ref IQueryable<V_CODL> queryData)
        {

            List<CODLModel> modelList = (from r in queryData
                                              select new CODLModel
                                              {
                                                  ID = r.ID,
                                                  VCH_TY = r.VCH_TY,
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
                                                  PRCV_DT = r.PRCV_DT.Value,
                                                  RCV_QTY = r.RCV_QTY.Value,
                                                  CO_WAHO_NO = r.CO_WAHO_NO,
                                                  WAHO_NM = r.WAHO_NM,
                                                  C_OUT = r.C_OUT,
                                                  OUT_RT = r.OUT_RT.Value,
                                                  C_CLS = r.C_CLS,
                                                  REMK = r.REMK,
                                                  CS_NO = r.CS_NO,
                                                  C_CFM = r.C_CFM
                                              }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, CODLModel model)
        {
            try
            {
                V_CODL entity = m_Rep.GetById(model.ID);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new V_CODL();
                entity.ID = model.ID;
                entity.VCH_TY = model.VCH_TY;
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
                entity.RCV_QTY = model.RCV_QTY;
                entity.CO_WAHO_NO = model.CO_WAHO_NO;
                entity.WAHO_NM = model.WAHO_NM;
                entity.C_OUT = model.C_OUT;
                entity.OUT_RT = model.OUT_RT;
                entity.C_CLS = model.C_CLS;
                entity.REMK = model.REMK;
                entity.CS_NO = model.CS_NO;
                entity.C_CFM = model.C_CFM;
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
        public bool Edit(ref ValidationErrors errors, CODLModel model)
        {
            try
            {
                V_CODL entity = m_Rep.GetById(model.ID);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.ID = model.ID;
                entity.VCH_TY = model.VCH_TY;
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
                entity.RCV_QTY = model.RCV_QTY;
                entity.CO_WAHO_NO = model.CO_WAHO_NO;
                entity.WAHO_NM = model.WAHO_NM;
                entity.C_OUT = model.C_OUT;
                entity.OUT_RT = model.OUT_RT;
                entity.C_CLS = model.C_CLS;
                entity.REMK = model.REMK;
                entity.CS_NO = model.CS_NO;
                entity.C_CFM = model.C_CFM;

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
            if (db.V_CODL.SingleOrDefault(a => a.ID == id) != null)
            {
                return true;
            }
            return false;
        }

        public CODLModel GetById(string id)
        {
            if (IsExist(id))
            {
                V_CODL entity = m_Rep.GetById(id);
                CODLModel model = new CODLModel();
                model.ID = entity.ID;
                model.VCH_TY = entity.VCH_TY;
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
                model.PRCV_DT = entity.PRCV_DT.Value;
                model.RCV_QTY = entity.RCV_QTY.Value;
                model.CO_WAHO_NO = entity.CO_WAHO_NO;
                model.WAHO_NM = entity.WAHO_NM;
                model.C_OUT = entity.C_OUT;
                model.OUT_RT = entity.OUT_RT.Value;
                model.C_CLS = entity.C_CLS;
                model.REMK = entity.REMK;
                model.CS_NO = entity.CS_NO;
                model.C_CFM = entity.C_CFM;
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