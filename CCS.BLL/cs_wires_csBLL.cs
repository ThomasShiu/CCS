﻿using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.WIR;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CCS.BLL
{
    public class cs_wires_csBLL : BaseBLL, Ics_wires_csBLL
    {
        [Dependency]
        public Ics_wires_csRepository m_Rep { get; set; }

        public List<cs_wires_csModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_WIRES_CS> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.RAWMTRL.Contains(queryStr) || a.CS_NM.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_wires_csModel> CreateModelList(ref IQueryable<CS_WIRES_CS> queryData)
        {

            List<cs_wires_csModel> modelList = (from r in queryData
                                                select new cs_wires_csModel
                                                {
                                                    Id = r.Id,
                                                    RAWMTRL = r.RAWMTRL,
                                                    DIAMETER = r.DIAMETER.Value,
                                                    ORG_DIAMETER = r.ORG_DIAMETER.Value,
                                                    HEAT_NO = r.HEAT_NO,
                                                    WEIGHT = r.WEIGHT.Value,
                                                    STAND_WEIGTH = r.STAND_WEIGTH.Value,
                                                    MARK_NM = r.MARK_NM,
                                                    PROCESS_FACTORY = r.PROCESS_FACTORY,
                                                    CS_NO = r.CS_NO,
                                                    CS_NM = r.CS_NM,
                                                    TRANS_DATE = r.TRANS_DATE,
                                                    TRANS_CODE = r.TRANS_CODE,
                                                    REMARK = r.REMARK,
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

        public bool Create(ref ValidationErrors errors, cs_wires_csModel model)
        {
            try
            {
                CS_WIRES_CS entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_WIRES_CS();
                entity.Id = model.Id;
                entity.RAWMTRL = model.RAWMTRL;
                entity.DIAMETER = model.DIAMETER;
                entity.ORG_DIAMETER = model.ORG_DIAMETER;
                entity.HEAT_NO = model.HEAT_NO;
                entity.WEIGHT = model.WEIGHT;
                entity.STAND_WEIGTH = model.STAND_WEIGTH;
                entity.MARK_NM = model.MARK_NM;
                entity.PROCESS_FACTORY = model.PROCESS_FACTORY;
                entity.CS_NO = model.CS_NO;
                entity.CS_NM = model.CS_NM;
                entity.TRANS_DATE = model.TRANS_DATE;
                entity.TRANS_CODE = model.TRANS_CODE;
                entity.REMARK = model.REMARK;
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
        public bool Edit(ref ValidationErrors errors, cs_wires_csModel model)
        {
            try
            {
                CS_WIRES_CS entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.RAWMTRL = model.RAWMTRL;
                entity.DIAMETER = model.DIAMETER;
                entity.ORG_DIAMETER = model.ORG_DIAMETER;
                entity.HEAT_NO = model.HEAT_NO;
                entity.WEIGHT = model.WEIGHT;
                entity.STAND_WEIGTH = model.STAND_WEIGTH;
                entity.MARK_NM = model.MARK_NM;
                entity.PROCESS_FACTORY = model.PROCESS_FACTORY;
                entity.CS_NO = model.CS_NO;
                entity.CS_NM = model.CS_NM;
                entity.TRANS_DATE = model.TRANS_DATE;
                entity.TRANS_CODE = model.TRANS_CODE;
                entity.REMARK = model.REMARK;
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
            if (db.CS_WIRES_CS.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_wires_csModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_WIRES_CS entity = m_Rep.GetById(id);
                cs_wires_csModel model = new cs_wires_csModel();
                model.Id = entity.Id;
                model.RAWMTRL = entity.RAWMTRL;
                model.DIAMETER = entity.DIAMETER.Value;
                model.ORG_DIAMETER = entity.ORG_DIAMETER.Value;
                model.HEAT_NO = entity.HEAT_NO;
                model.WEIGHT = entity.WEIGHT.Value;
                model.STAND_WEIGTH = entity.STAND_WEIGTH.Value;
                model.MARK_NM = entity.MARK_NM;
                model.PROCESS_FACTORY = entity.PROCESS_FACTORY;
                model.CS_NO = entity.CS_NO;
                model.CS_NM = entity.CS_NM;
                model.TRANS_DATE = entity.TRANS_DATE;
                model.TRANS_CODE = entity.TRANS_CODE;
                model.REMARK = entity.REMARK;
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
