using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.KEG;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CCS.BLL
{
    public class cs_kegs_csBLL : BaseBLL, Ics_kegs_csBLL
    {
        [Dependency]
        public Ics_kegs_csRepository m_Rep { get; set; }

        public List<cs_kegs_csModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_KEGS_CS> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.CS_NO.Contains(queryStr) || a.CS_NM.Contains(queryStr) || a.TRANS_CODE.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_kegs_csModel> CreateModelList(ref IQueryable<CS_KEGS_CS> queryData)
        {

            List<cs_kegs_csModel> modelList = (from r in queryData
                                               select new cs_kegs_csModel
                                               {
                                                   Id = r.Id,
                                                   CS_NO = r.CS_NO,
                                                   CS_NM = r.CS_NM,
                                                   KEG_NM = r.KEG_NM,
                                                   TRANS_DATE = r.TRANS_DATE,
                                                   TRANS_CODE = r.TRANS_CODE,
                                                   CNT = r.CNT,
                                                   REMARK = r.REMARK,
                                                   C_CLS = r.C_CLS,
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

        public bool Create(ref ValidationErrors errors, cs_kegs_csModel model)
        {
            try
            {
                CS_KEGS_CS entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_KEGS_CS();
                entity.Id = model.Id;
                entity.CS_NO = model.CS_NO;
                entity.CS_NM = model.CS_NM;
                entity.KEG_NM = model.KEG_NM;
                entity.TRANS_DATE = model.TRANS_DATE;
                entity.TRANS_CODE = model.TRANS_CODE;
                entity.CNT = model.CNT;
                entity.REMARK = model.REMARK;
                entity.C_CLS = model.C_CLS;
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
                errors.Add(ex.Message+";"+ex.InnerException.InnerException.Message);
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
        public bool Edit(ref ValidationErrors errors, cs_kegs_csModel model)
        {
            try
            {
                CS_KEGS_CS entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.CS_NO = model.CS_NO;
                entity.CS_NM = model.CS_NM;
                entity.KEG_NM = model.KEG_NM;
                entity.TRANS_DATE = model.TRANS_DATE;
                entity.TRANS_CODE = model.TRANS_CODE;
                entity.CNT = model.CNT;
                entity.REMARK = model.REMARK;
                entity.C_CLS = model.C_CLS;
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
                errors.Add(ex.Message + ";" + ex.InnerException.InnerException.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool IsExists(string id)
        {
            if (db.CS_KEGS_CS.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_kegs_csModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_KEGS_CS entity = m_Rep.GetById(id);
                cs_kegs_csModel model = new cs_kegs_csModel();
                model.Id = entity.Id;
                model.CS_NO = entity.CS_NO;
                model.CS_NM = entity.CS_NM;
                model.KEG_NM = entity.KEG_NM;
                model.TRANS_DATE = entity.TRANS_DATE;
                model.TRANS_CODE = entity.TRANS_CODE;
                model.CNT = entity.CNT;
                model.REMARK = entity.REMARK;
                model.C_CLS = entity.C_CLS;
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
