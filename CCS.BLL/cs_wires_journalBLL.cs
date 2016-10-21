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
    public class cs_wires_journalBLL : BaseBLL, Ics_wires_journalBLL
    {
        [Dependency]
        public Ics_wires_journalRepository m_Rep { get; set; }

        public List<cs_wires_journalModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_WIRES_JOURNAL> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.WIRE_ID.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_wires_journalModel> CreateModelList(ref IQueryable<CS_WIRES_JOURNAL> queryData)
        {

            List<cs_wires_journalModel> modelList = (from r in queryData
                                                     select new cs_wires_journalModel
                                                     {
                                                         Id = r.Id,
                                                         WIRE_ID = r.WIRE_ID,
                                                         TRANS_CODE = r.TRANS_CODE,
                                                         TRANS_DATE = r.TRANS_DATE,
                                                         WEIGHT = r.WEIGHT.Value,
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

        public bool Create(ref ValidationErrors errors, cs_wires_journalModel model)
        {
            try
            {
                CS_WIRES_JOURNAL entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_WIRES_JOURNAL();
                entity.Id = model.Id;
                entity.WIRE_ID = model.WIRE_ID;
                entity.TRANS_CODE = model.TRANS_CODE;
                entity.TRANS_DATE = model.TRANS_DATE;
                entity.WEIGHT = model.WEIGHT;
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

        public bool Delete(ref ValidationErrors errors, int[] deleteCollection)
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
        public bool Edit(ref ValidationErrors errors, cs_wires_journalModel model)
        {
            try
            {
                CS_WIRES_JOURNAL entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.WIRE_ID = model.WIRE_ID;
                entity.TRANS_CODE = model.TRANS_CODE;
                entity.TRANS_DATE = model.TRANS_DATE;
                entity.WEIGHT = model.WEIGHT;
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

        public bool IsExists(int id)
        {
            if (db.CS_WIRES_JOURNAL.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_wires_journalModel GetById(int id)
        {
            if (IsExist(id))
            {
                CS_WIRES_JOURNAL entity = m_Rep.GetById(id);
                cs_wires_journalModel model = new cs_wires_journalModel();
                model.Id = entity.Id;
                model.WIRE_ID = entity.WIRE_ID;
                model.TRANS_CODE = entity.TRANS_CODE;
                model.TRANS_DATE = entity.TRANS_DATE;
                model.WEIGHT = entity.WEIGHT.Value;
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

        public bool IsExist(int id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
