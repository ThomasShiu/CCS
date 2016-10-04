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
    public class cs_sysroleBLL : BaseBLL, Ics_sysroleBLL
    {
        [Dependency]
        public Ics_sysroleRepository m_Rep { get; set; }
        public List<cs_sysroleModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_SYSROLE> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.Name.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<cs_sysroleModel> CreateModelList(ref IQueryable<CS_SYSROLE> queryData)
        {
            List<cs_sysroleModel> modelList = new List<cs_sysroleModel>();
            foreach (var r in queryData)
            {
                modelList.Add(new cs_sysroleModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CreateTime = r.CreateTime,
                    CreatePerson = r.CreatePerson,
                    UserName = ""
                });
            }
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, cs_sysroleModel model)
        {
            try
            {
                CS_SYSROLE entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_SYSROLE();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.CreateTime = model.CreateTime;
                entity.CreatePerson = model.CreatePerson;
                if (m_Rep.Create(entity) == 1)
                {
                    //分配給角色
                    db.SP_SYS_InsertSysRIGHT();
                    //清理無用的項
                    db.SP_SYS_ClearUnusedRIGHTOPERATE();
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


        public bool Edit(ref ValidationErrors errors, cs_sysroleModel model)
        {
            try
            {
                CS_SYSROLE entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.CreateTime = model.CreateTime;
                entity.CreatePerson = model.CreatePerson;

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
            if (db.CS_SYSROLE.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_sysroleModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_SYSROLE entity = m_Rep.GetById(id);
                cs_sysroleModel model = new cs_sysroleModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Description = entity.Description;
                model.CreateTime = entity.CreateTime;
                model.CreatePerson = entity.CreatePerson;
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
