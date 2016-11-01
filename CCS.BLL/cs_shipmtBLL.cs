using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.INV;
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
    public class cs_shipmtBLL : BaseBLL, Ics_shipmtBLL
    {
        [Dependency]
        public Ics_shipmtRepository m_Rep { get; set; }

        public List<cs_shipmtModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_SHIPMT> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.VCH_NO.Contains(queryStr) || a.CS_NM.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_shipmtModel> CreateModelList(ref IQueryable<CS_SHIPMT> queryData)
        {

            List<cs_shipmtModel> modelList = (from r in queryData
                                              select new cs_shipmtModel
                                              {
                                                  Id = r.Id,
                                                  VCH_NO = r.VCH_NO,
                                                  VCH_DT = r.VCH_DT,
                                                  CS_NO = r.CS_NO,
                                                  CS_NM = r.CS_NM,
                                                  TO_ADDR = r.TO_ADDR,
                                                  CONTACT = r.CONTACT,
                                                  END_CODE = r.END_CODE,
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

        public bool Create(ref ValidationErrors errors, cs_shipmtModel model)
        {
            try
            {
                CS_SHIPMT entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_SHIPMT();
                entity.Id = model.Id;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.CS_NO = model.CS_NO;
                entity.CS_NM = model.CS_NM;
                entity.TO_ADDR = model.TO_ADDR;
                entity.CONTACT = model.CONTACT;
                entity.END_CODE = model.END_CODE;
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
        public bool Edit(ref ValidationErrors errors, cs_shipmtModel model)
        {
            try
            {
                CS_SHIPMT entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.CS_NO = model.CS_NO;
                entity.CS_NM = model.CS_NM;
                entity.TO_ADDR = model.TO_ADDR;
                entity.CONTACT = model.CONTACT;
                entity.END_CODE = model.END_CODE;
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
            if (db.CS_SHIPMT.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_shipmtModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_SHIPMT entity = m_Rep.GetById(id);
                cs_shipmtModel model = new cs_shipmtModel();
                model.Id = entity.Id;
                model.VCH_NO = entity.VCH_NO;
                model.VCH_DT = entity.VCH_DT;
                model.CS_NO = entity.CS_NO;
                model.CS_NM = entity.CS_NM;
                model.TO_ADDR = entity.TO_ADDR;
                model.CONTACT = entity.CONTACT;
                model.END_CODE = entity.END_CODE;
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

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
