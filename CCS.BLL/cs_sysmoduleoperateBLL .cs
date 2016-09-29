using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.SYS;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.BLL
{
    public class cs_sysmoduleoperateBLL : BaseBLL, Ics_sysmoduleoperateBLL
    {
        [Dependency]
        public Ics_sysmoduleoperateRepository m_Rep { get; set; }

        public List<cs_sysmoduleopertaeModel> GetList(ref GridPager pager, string mid)
        {

            IQueryable<CS_SYSMODULEOPERATE> queryData = m_Rep.GetList(db).Where(a => a.ModuleId == mid);
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_sysmoduleopertaeModel> CreateModelList(ref IQueryable<CS_SYSMODULEOPERATE> queryData)
        {

            List<cs_sysmoduleopertaeModel> modelList = (from r in queryData
                                                     select new cs_sysmoduleopertaeModel
                                                     {
                                                         Id = r.Id,
                                                         Name = r.Name,
                                                         KeyCode = r.KeyCode,
                                                         ModuleId = r.ModuleId,
                                                         IsValid = r.IsValid,
                                                         Sort = r.Sort
                                                     }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, cs_sysmoduleopertaeModel model)
        {
            try
            {
                CS_SYSMODULEOPERATE entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_SYSMODULEOPERATE();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.KeyCode = model.KeyCode;
                entity.ModuleId = model.ModuleId;
                entity.IsValid = model.IsValid;
                entity.Sort = model.Sort;
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

        public bool IsExists(string id)
        {
            if (db.CS_SYSMODULEOPERATE.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_sysmoduleopertaeModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_SYSMODULEOPERATE entity = m_Rep.GetById(id);
                cs_sysmoduleopertaeModel model = new cs_sysmoduleopertaeModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.KeyCode = entity.KeyCode;
                model.ModuleId = entity.ModuleId;
                model.IsValid = entity.IsValid;
                model.Sort = entity.Sort;
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
