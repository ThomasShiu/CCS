﻿using CCS.BLL.Core;
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
using System.Threading.Tasks;
using System.Transactions;

namespace CCS.BLL
{
    public class cs_momtBLL  : BaseBLL, Ics_momtBLL
    {
        [Dependency]
        public Ics_momtRepository m_Rep { get; set; }

        public List<cs_momtModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_MOMT> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.VCH_NO.Contains(queryStr) || a.ITEM_NO.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_momtModel> CreateModelList(ref IQueryable<CS_MOMT> queryData)
        {

            List<cs_momtModel> modelList = (from r in queryData
                                            select new cs_momtModel
                                            {
                                                Id = r.Id,
                                                VCH_NO = r.VCH_NO,
                                                VCH_DT = r.VCH_DT,
                                                FA_NO = r.FA_NO,
                                                ITEM_NO = r.ITEM_NO,
                                                IMG_NO = r.IMG_NO,
                                                PLAN_BDT = r.PLAN_BDT.Value,
                                                PLAN_EDT = r.PLAN_EDT.Value,
                                                PLAN_QTY = r.PLAN_QTY.Value,
                                                CO_NO = r.CO_NO,
                                                CO_SR = r.CO_SR.Value,
                                                HEAD_MARK = r.HEAD_MARK,
                                                RAWMTRL = r.RAWMTRL,
                                                DIAMETER = r.DIAMETER.Value,
                                                PLATING = r.PLATING,
                                                PRCS_NO = r.PRCS_NO,
                                                REMK = r.REMK,
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

        public bool Create(ref ValidationErrors errors, cs_momtModel model)
        {
            try
            {
                CS_MOMT entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_MOMT();
                entity.Id = model.Id;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.FA_NO = model.FA_NO;
                entity.ITEM_NO = model.ITEM_NO;
                entity.IMG_NO = model.IMG_NO;
                entity.PLAN_BDT = model.PLAN_BDT;
                entity.PLAN_EDT = model.PLAN_EDT;
                entity.PLAN_QTY = model.PLAN_QTY;
                entity.CO_NO = model.CO_NO;
                entity.CO_SR = model.CO_SR;
                entity.HEAD_MARK = model.HEAD_MARK;
                entity.RAWMTRL = model.RAWMTRL;
                entity.DIAMETER = model.DIAMETER;
                entity.PLATING = model.PLATING;
                entity.PRCS_NO = model.PRCS_NO;
                entity.REMK = model.REMK;
                entity.OWNER_USR_NO = model.OWNER_USR_NO;
                entity.OWNER_GRP_NO = model.OWNER_GRP_NO;
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
        public bool Edit(ref ValidationErrors errors, cs_momtModel model)
        {
            try
            {
                CS_MOMT entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.FA_NO = model.FA_NO;
                entity.ITEM_NO = model.ITEM_NO;
                entity.IMG_NO = model.IMG_NO;
                entity.PLAN_BDT = model.PLAN_BDT;
                entity.PLAN_EDT = model.PLAN_EDT;
                entity.PLAN_QTY = model.PLAN_QTY;
                entity.CO_NO = model.CO_NO;
                entity.CO_SR = model.CO_SR;
                entity.HEAD_MARK = model.HEAD_MARK;
                entity.RAWMTRL = model.RAWMTRL;
                entity.DIAMETER = model.DIAMETER;
                entity.PLATING = model.PLATING;
                entity.PRCS_NO = model.PRCS_NO;
                entity.REMK = model.REMK;
                entity.OWNER_USR_NO = model.OWNER_USR_NO;
                entity.OWNER_GRP_NO = model.OWNER_GRP_NO;
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

        public bool IsExists(string id)
        {
            if (db.CS_MOMT.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_momtModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_MOMT entity = m_Rep.GetById(id);
                cs_momtModel model = new cs_momtModel();
                model.Id = entity.Id;
                model.VCH_NO = entity.VCH_NO;
                model.VCH_DT = entity.VCH_DT;
                model.FA_NO = entity.FA_NO;
                model.ITEM_NO = entity.ITEM_NO;
                model.IMG_NO = entity.IMG_NO;
                model.PLAN_BDT = entity.PLAN_BDT.Value;
                model.PLAN_EDT = entity.PLAN_EDT.Value;
                model.PLAN_QTY = entity.PLAN_QTY.Value;
                model.CO_NO = entity.CO_NO;
                model.CO_SR = entity.CO_SR.Value;
                model.HEAD_MARK = entity.HEAD_MARK;
                model.RAWMTRL = entity.RAWMTRL;
                model.DIAMETER = entity.DIAMETER.Value;
                model.PLATING = entity.PLATING;
                model.PRCS_NO = entity.PRCS_NO;
                model.REMK = entity.REMK;
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
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
