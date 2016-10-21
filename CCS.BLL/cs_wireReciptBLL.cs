using CCS.BLL.Core;
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
    public class cs_wireReciptBLL :BaseBLL, Ics_wireReciptBLL
    {
        [Dependency]
        public Ics_wireReciptRepository m_Rep { get; set; }

        public List<cs_wire_reciptModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_WIRE_RECIPIENT> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.MO_VCH_NO.Contains(queryStr) || a.WIRE_ID.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_wire_reciptModel> CreateModelList(ref IQueryable<CS_WIRE_RECIPIENT> queryData)
        {

            List<cs_wire_reciptModel> modelList = (from r in queryData
                                                      select new cs_wire_reciptModel
                                                      {
                                                          Id = r.Id,
                                                          MO_VCH_NO = r.MO_VCH_NO,
                                                          WIRE_ID = r.WIRE_ID,
                                                          WEIGHT = r.WEIGHT.Value,
                                                          REC_DATE = r.REC_DATE.Value,
                                                          REC_EMP = r.REC_EMP,
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

        public bool Create(ref ValidationErrors errors, cs_wire_reciptModel model)
        {
            try
            {
                CS_WIRE_RECIPIENT entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_WIRE_RECIPIENT();
                entity.Id = model.Id;
                entity.MO_VCH_NO = model.MO_VCH_NO;
                entity.WIRE_ID = model.WIRE_ID;
                entity.WEIGHT = model.WEIGHT;
                entity.REC_DATE = model.REC_DATE;
                entity.REC_EMP = model.REC_EMP;
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
        public bool Edit(ref ValidationErrors errors, cs_wire_reciptModel model)
        {
            try
            {
                CS_WIRE_RECIPIENT entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.MO_VCH_NO = model.MO_VCH_NO;
                entity.WIRE_ID = model.WIRE_ID;
                entity.WEIGHT = model.WEIGHT;
                entity.REC_DATE = model.REC_DATE;
                entity.REC_EMP = model.REC_EMP;
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
            if (db.CS_WIRE_RECIPIENT.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_wire_reciptModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_WIRE_RECIPIENT entity = m_Rep.GetById(id);
                cs_wire_reciptModel model = new cs_wire_reciptModel();
                model.Id = entity.Id;
                model.MO_VCH_NO = entity.MO_VCH_NO;
                model.WIRE_ID = entity.WIRE_ID;
                model.WEIGHT = entity.WEIGHT.Value;
                model.REC_DATE = entity.REC_DATE.Value;
                model.REC_EMP = entity.REC_EMP;
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
