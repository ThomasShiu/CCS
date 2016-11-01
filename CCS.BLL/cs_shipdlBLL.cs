using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.INV;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CCS.BLL
{
    public class cs_shipdlBLL : BaseBLL, Ics_shipdlBLL
    {
        [Dependency]
        public Ics_shipdlRepository m_Rep { get; set; }

        public List<cs_shipdlModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_SHIPDL> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.VCH_NO.Contains(queryStr) || a.ITEM_NM.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_shipdlModel> CreateModelList(ref IQueryable<CS_SHIPDL> queryData)
        {

            List<cs_shipdlModel> modelList = (from r in queryData
                                              select new cs_shipdlModel
                                              {
                                                  Id = r.Id,
                                                  VCH_NO = r.VCH_NO,
                                                  VCH_SR = r.VCH_SR,
                                                  ITEM_NO = r.ITEM_NO,
                                                  ITEM_NM = r.ITEM_NM,
                                                  ITEM_SP = r.ITEM_SP,
                                                  RAWMTRL = r.RAWMTRL,
                                                  HEAT_NO = r.HEAT_NO,
                                                  KEG_CNT = r.KEG_CNT.Value,
                                                  UNIT_WT = r.UNIT_WT.Value,
                                                  NET_WEIGHT = r.NET_WEIGHT.Value,
                                                  GROSS_WEIGHT = r.GROSS_WEIGHT.Value,
                                                  COUNT_QTY = r.COUNT_QTY.Value,
                                                  PRC = r.PRC.HasValue?r.PRC.Value:0,
                                                  AMT = r.AMT.HasValue?r.AMT.Value:0,
                                                  END_CODE = r.END_CODE,
                                                  CS_ORDER_NO = r.CS_ORDER_NO,
                                                  REMK = r.REMK,
                                                  EXC_INSDBID = r.EXC_INSDBID,
                                                  EXC_INSDATE = r.EXC_INSDATE.Value,
                                                  EXC_UPDDBID = r.EXC_UPDDBID,
                                                  EXC_UPDDATE = r.EXC_UPDDATE.Value,
                                                  EXC_SYSOWNR = r.EXC_SYSOWNR,
                                                  EXC_ISLOCKED = r.EXC_ISLOCKED,
                                                  EXC_COMPANY = r.EXC_COMPANY,
                                                  STATUS = r.STATUS
                                              }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, cs_shipdlModel model)
        {
            try
            {
                CS_SHIPDL entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_SHIPDL();
                entity.Id = model.Id;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_SR = model.VCH_SR;
                entity.ITEM_NO = model.ITEM_NO;
                entity.ITEM_NM = model.ITEM_NM;
                entity.ITEM_SP = model.ITEM_SP;
                entity.RAWMTRL = model.RAWMTRL;
                entity.HEAT_NO = model.HEAT_NO;
                entity.KEG_CNT = model.KEG_CNT;
                entity.UNIT_WT = model.UNIT_WT;
                entity.NET_WEIGHT = model.NET_WEIGHT;
                entity.GROSS_WEIGHT = model.GROSS_WEIGHT;
                entity.COUNT_QTY = model.COUNT_QTY;
                entity.PRC = model.PRC;
                entity.AMT = model.AMT;
                entity.END_CODE = model.END_CODE;
                entity.CS_ORDER_NO = model.CS_ORDER_NO;
                entity.REMK = model.REMK;
                entity.EXC_INSDBID = model.EXC_INSDBID;
                entity.EXC_INSDATE = model.EXC_INSDATE;
                entity.EXC_UPDDBID = model.EXC_UPDDBID;
                entity.EXC_UPDDATE = model.EXC_UPDDATE;
                entity.EXC_SYSOWNR = model.EXC_SYSOWNR;
                entity.EXC_ISLOCKED = model.EXC_ISLOCKED;
                entity.EXC_COMPANY = model.EXC_COMPANY;
                entity.STATUS = model.STATUS;
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
        public bool Edit(ref ValidationErrors errors, cs_shipdlModel model)
        {
            try
            {
                CS_SHIPDL entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_SR = model.VCH_SR;
                entity.ITEM_NO = model.ITEM_NO;
                entity.ITEM_NM = model.ITEM_NM;
                entity.ITEM_SP = model.ITEM_SP;
                entity.RAWMTRL = model.RAWMTRL;
                entity.HEAT_NO = model.HEAT_NO;
                entity.KEG_CNT = model.KEG_CNT;
                entity.UNIT_WT = model.UNIT_WT;
                entity.NET_WEIGHT = model.NET_WEIGHT;
                entity.GROSS_WEIGHT = model.GROSS_WEIGHT;
                entity.COUNT_QTY = model.COUNT_QTY;
                entity.PRC = model.PRC;
                entity.AMT = model.AMT;
                entity.END_CODE = model.END_CODE;
                entity.CS_ORDER_NO = model.CS_ORDER_NO;
                entity.REMK = model.REMK;
                entity.EXC_INSDBID = model.EXC_INSDBID;
                entity.EXC_INSDATE = model.EXC_INSDATE;
                entity.EXC_UPDDBID = model.EXC_UPDDBID;
                entity.EXC_UPDDATE = model.EXC_UPDDATE;
                entity.EXC_SYSOWNR = model.EXC_SYSOWNR;
                entity.EXC_ISLOCKED = model.EXC_ISLOCKED;
                entity.EXC_COMPANY = model.EXC_COMPANY;
                entity.STATUS = model.STATUS;

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
            if (db.CS_SHIPDL.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_shipdlModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_SHIPDL entity = m_Rep.GetById(id);
                cs_shipdlModel model = new cs_shipdlModel();
                model.Id = entity.Id;
                model.VCH_NO = entity.VCH_NO;
                model.VCH_SR = entity.VCH_SR;
                model.ITEM_NO = entity.ITEM_NO;
                model.ITEM_NM = entity.ITEM_NM;
                model.ITEM_SP = entity.ITEM_SP;
                model.RAWMTRL = entity.RAWMTRL;
                model.HEAT_NO = entity.HEAT_NO;
                model.KEG_CNT = entity.KEG_CNT.Value;
                model.UNIT_WT = entity.UNIT_WT.Value;
                model.NET_WEIGHT = entity.NET_WEIGHT.Value;
                model.GROSS_WEIGHT = entity.GROSS_WEIGHT.Value;
                model.COUNT_QTY = entity.COUNT_QTY.Value;
                model.PRC = entity.PRC.Value;
                model.AMT = entity.AMT.Value;
                model.END_CODE = entity.END_CODE;
                model.CS_ORDER_NO = entity.CS_ORDER_NO;
                model.REMK = entity.REMK;
                model.EXC_INSDBID = entity.EXC_INSDBID;
                model.EXC_INSDATE = entity.EXC_INSDATE.Value;
                model.EXC_UPDDBID = entity.EXC_UPDDBID;
                model.EXC_UPDDATE = entity.EXC_UPDDATE.Value;
                model.EXC_SYSOWNR = entity.EXC_SYSOWNR;
                model.EXC_ISLOCKED = entity.EXC_ISLOCKED;
                model.EXC_COMPANY = entity.EXC_COMPANY;
                model.STATUS = entity.STATUS;
                return model;
            }
            else
            {
                return null;
            }
        }
        public cs_shipdlModel GetByNo(string id)
        {
            //if (IsExist(id))
            //{
                CS_SHIPDL entity = m_Rep.GetByNo(id);
                cs_shipdlModel model = new cs_shipdlModel();
                model.Id = entity.Id;
                model.VCH_NO = entity.VCH_NO;
                model.VCH_SR = entity.VCH_SR;
                model.ITEM_NO = entity.ITEM_NO;
                model.ITEM_NM = entity.ITEM_NM;
                model.ITEM_SP = entity.ITEM_SP;
                model.RAWMTRL = entity.RAWMTRL;
                model.HEAT_NO = entity.HEAT_NO;
                model.KEG_CNT = entity.KEG_CNT.Value;
                model.UNIT_WT = entity.UNIT_WT.Value;
                model.NET_WEIGHT = entity.NET_WEIGHT.Value;
                model.GROSS_WEIGHT = entity.GROSS_WEIGHT.Value;
                model.COUNT_QTY = entity.COUNT_QTY.Value;
                model.PRC = entity.PRC.HasValue?entity.PRC.Value:0;
                model.AMT = entity.AMT.HasValue?entity.AMT.Value:0;
                model.END_CODE = entity.END_CODE;
                model.CS_ORDER_NO = entity.CS_ORDER_NO;
                model.REMK = entity.REMK;
                model.EXC_INSDBID = entity.EXC_INSDBID;
                model.EXC_INSDATE = entity.EXC_INSDATE.Value;
                model.EXC_UPDDBID = entity.EXC_UPDDBID;
                model.EXC_UPDDATE = entity.EXC_UPDDATE.Value;
                model.EXC_SYSOWNR = entity.EXC_SYSOWNR;
                model.EXC_ISLOCKED = entity.EXC_ISLOCKED;
                model.EXC_COMPANY = entity.EXC_COMPANY;
                model.STATUS = entity.STATUS;
                return model;
            //}
            //else
            //{
            //    return null;
            //}
        }
        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }

    }
}
