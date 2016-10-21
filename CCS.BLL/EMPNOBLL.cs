using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.PUB;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CCS.BLL
{
    public class EMPNOBLL : BaseBLL, IEMPNOBLL
    {
        [Dependency]
        public IEMPNORepository m_Rep { get; set; }

        public List<empnoModel> GetList(string queryStr)
        {

            IQueryable<EMPNO> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                

                switch (queryStr)
                {
                    case "C_COP":
                        queryData = m_Rep.GetList(db).Where(a => a.C_COP=="Y");
                        break;
                    case "C_PUR":
                        queryData = m_Rep.GetList(db).Where(a => a.C_PUR == "Y");
                        break;
                    case "C_INV":
                        queryData = m_Rep.GetList(db).Where(a => a.C_INV == "Y");
                        break;
                    case "C_SFC":
                        queryData = m_Rep.GetList(db).Where(a => a.C_SFC == "Y");
                        break;
                    default:
                        queryData = m_Rep.GetList(db).Where(a => a.EMP_NM.Contains(queryStr) || a.EMP_NO.Contains(queryStr));
                        break;
                }
                
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }

            return CreateModelList(ref queryData);
        }
        public List<empnoModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<EMPNO> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.EMP_NM.Contains(queryStr) || a.EMP_NO.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<empnoModel> CreateModelList(ref IQueryable<EMPNO> queryData)
        {

            List<empnoModel> modelList = (from r in queryData
                                          select new empnoModel
                                          {
                                              EMP_NO = r.EMP_NO,
                                              EMP_NM = r.EMP_NM,
                                              DEPM_NO = r.DEPM_NO,
                                              TEL_NO = r.TEL_NO,
                                              TEL_NO2 = r.TEL_NO2,
                                              E_MAIL = r.E_MAIL,
                                              C_INV = r.C_INV,
                                              C_PUR = r.C_PUR,
                                              C_COP = r.C_COP,
                                              C_PPS = r.C_PPS,
                                              C_AST = r.C_AST,
                                              C_ACT = r.C_ACT,
                                              C_SFC = r.C_SFC,
                                              C_QMS = r.C_QMS,
                                              C_BOM = r.C_BOM,
                                              C_MOC = r.C_MOC
                                          }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, empnoModel model)
        {
            try
            {
                EMPNO entity = m_Rep.GetById(model.EMP_NO);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new EMPNO();
                entity.EMP_NO = model.EMP_NO;
                entity.EMP_NM = model.EMP_NM;
                entity.DEPM_NO = model.DEPM_NO;
                entity.TEL_NO = model.TEL_NO;
                entity.TEL_NO2 = model.TEL_NO2;
                entity.E_MAIL = model.E_MAIL;
                entity.C_INV = model.C_INV;
                entity.C_PUR = model.C_PUR;
                entity.C_COP = model.C_COP;
                entity.C_PPS = model.C_PPS;
                entity.C_AST = model.C_AST;
                entity.C_ACT = model.C_ACT;
                entity.C_SFC = model.C_SFC;
                entity.C_QMS = model.C_QMS;
                entity.C_BOM = model.C_BOM;
                entity.C_MOC = model.C_MOC;
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
        public bool Edit(ref ValidationErrors errors, empnoModel model)
        {
            try
            {
                EMPNO entity = m_Rep.GetById(model.EMP_NO);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.EMP_NO = model.EMP_NO;
                entity.EMP_NM = model.EMP_NM;
                entity.DEPM_NO = model.DEPM_NO;
                entity.TEL_NO = model.TEL_NO;
                entity.TEL_NO2 = model.TEL_NO2;
                entity.E_MAIL = model.E_MAIL;
                entity.C_INV = model.C_INV;
                entity.C_PUR = model.C_PUR;
                entity.C_COP = model.C_COP;
                entity.C_PPS = model.C_PPS;
                entity.C_AST = model.C_AST;
                entity.C_ACT = model.C_ACT;
                entity.C_SFC = model.C_SFC;
                entity.C_QMS = model.C_QMS;
                entity.C_BOM = model.C_BOM;
                entity.C_MOC = model.C_MOC;

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
            if (db.EMPNO.SingleOrDefault(a => a.EMP_NO == id) != null)
            {
                return true;
            }
            return false;
        }

        public empnoModel GetById(string id)
        {
            if (IsExist(id))
            {
                EMPNO entity = m_Rep.GetById(id);
                empnoModel model = new empnoModel();
                model.EMP_NO = entity.EMP_NO;
                model.EMP_NM = entity.EMP_NM;
                model.DEPM_NO = entity.DEPM_NO;
                model.TEL_NO = entity.TEL_NO;
                model.TEL_NO2 = entity.TEL_NO2;
                model.E_MAIL = entity.E_MAIL;
                model.C_INV = entity.C_INV;
                model.C_PUR = entity.C_PUR;
                model.C_COP = entity.C_COP;
                model.C_PPS = entity.C_PPS;
                model.C_AST = entity.C_AST;
                model.C_ACT = entity.C_ACT;
                model.C_SFC = entity.C_SFC;
                model.C_QMS = entity.C_QMS;
                model.C_BOM = entity.C_BOM;
                model.C_MOC = entity.C_MOC;
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
