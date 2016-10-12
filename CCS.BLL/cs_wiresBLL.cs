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
    public  class cs_wiresBLL : BaseBLL, Ics_wiresBLL
    {
        [Dependency]
        public Ics_wiresRepository m_Rep { get; set; }

        public List<cs_wiresModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_WIRES> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.Id.Contains(queryStr) || a.WIRE_ID.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_wiresModel> CreateModelList(ref IQueryable<CS_WIRES> queryData)
        {

            List<cs_wiresModel> modelList = (from r in queryData
                                             select new cs_wiresModel
                                             {
                                                 Id = r.Id,
                                                 WIRE_ID = r.WIRE_ID,
                                                 CS_WIRE_ID = r.CS_WIRE_ID,
                                                 STOCK_DATE = r.STOCK_DATE,
                                                 RAWMTRL = r.RAWMTRL,
                                                 DIAMETER = r.DIAMETER,
                                                 ORG_DIAMETER = r.ORG_DIAMETER.Value,
                                                 HEAT_NO = r.HEAT_NO,
                                                 WEIGHT = r.WEIGHT,
                                                 STAND_WEIGTH = r.STAND_WEIGTH.Value,
                                                 ANNEAL = r.ANNEAL,
                                                 MARK = r.MARK,
                                                 MARK_NM = r.MARK_NM,
                                                 PROCESS_FACTORY = r.PROCESS_FACTORY,
                                                 TYPE = r.TYPE.Value,
                                                 TYPE_NM = r.TYPE_NM,
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

        public bool Create(ref ValidationErrors errors, cs_wiresModel model)
        {
            try
            {
                CS_WIRES entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_WIRES();
                entity.Id = model.Id;
                entity.WIRE_ID = model.WIRE_ID;
                entity.CS_WIRE_ID = model.CS_WIRE_ID;
                entity.STOCK_DATE = model.STOCK_DATE;
                entity.RAWMTRL = model.RAWMTRL;
                entity.DIAMETER = model.DIAMETER;
                entity.ORG_DIAMETER = model.ORG_DIAMETER;
                entity.HEAT_NO = model.HEAT_NO;
                entity.WEIGHT = model.WEIGHT;
                entity.STAND_WEIGTH = model.STAND_WEIGTH;
                entity.ANNEAL = model.ANNEAL;
                entity.MARK = model.MARK;
                entity.MARK_NM = model.MARK_NM;
                entity.PROCESS_FACTORY = model.PROCESS_FACTORY;
                entity.TYPE = model.TYPE;
                entity.TYPE_NM = model.TYPE_NM;
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
        public bool Edit(ref ValidationErrors errors, cs_wiresModel model)
        {
            try
            {
                CS_WIRES entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.WIRE_ID = model.WIRE_ID;
                entity.CS_WIRE_ID = model.CS_WIRE_ID;
                entity.STOCK_DATE = model.STOCK_DATE;
                entity.RAWMTRL = model.RAWMTRL;
                entity.DIAMETER = model.DIAMETER;
                entity.ORG_DIAMETER = model.ORG_DIAMETER.HasValue ? model.ORG_DIAMETER : null;
                entity.HEAT_NO = model.HEAT_NO;
                entity.WEIGHT = model.WEIGHT;
                entity.STAND_WEIGTH = model.STAND_WEIGTH;
                entity.ANNEAL = model.ANNEAL;
                entity.MARK = model.MARK;
                entity.MARK_NM = model.MARK_NM;
                entity.PROCESS_FACTORY = model.PROCESS_FACTORY;
                entity.TYPE = model.TYPE;
                entity.TYPE_NM = model.TYPE_NM;
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
            if (db.CS_WIRES.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_wiresModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_WIRES entity = m_Rep.GetById(id);
                cs_wiresModel model = new cs_wiresModel();
                model.Id = entity.Id;
                model.WIRE_ID = entity.WIRE_ID;
                model.CS_WIRE_ID = entity.CS_WIRE_ID;
                model.STOCK_DATE = entity.STOCK_DATE;
                model.RAWMTRL = entity.RAWMTRL;
                model.DIAMETER = entity.DIAMETER;
                model.ORG_DIAMETER = entity.ORG_DIAMETER.HasValue ? entity.ORG_DIAMETER : null;
                model.HEAT_NO = entity.HEAT_NO;
                model.WEIGHT = entity.WEIGHT;
                model.STAND_WEIGTH = entity.STAND_WEIGTH.Value;
                model.ANNEAL = entity.ANNEAL;
                model.MARK = entity.MARK;
                model.MARK_NM = entity.MARK_NM;
                model.PROCESS_FACTORY = entity.PROCESS_FACTORY;
                model.TYPE = entity.TYPE.Value;
                model.TYPE_NM = entity.TYPE_NM;
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
