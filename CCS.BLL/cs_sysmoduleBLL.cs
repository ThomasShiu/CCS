using CCS.BLL.Core;
using CCS.Common;
using CCS.DAL;
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
    public class cs_sysmoduleBLL : BaseBLL, Ics_sysmoduleBLL
    {
        [Dependency]
        public Ics_sysmoduleRepository m_Rep { get; set; }

        public List<CS_SYSMODULE> GetMenuByPersonId(string personId, string moduleId)
        {
            return m_Rep.GetMenuByPersonId(personId, moduleId);
        }

        public List<cs_sysmoduleModel> GetList(string parentId)
        {
            IQueryable<CS_SYSMODULE> queryData = null;
            queryData = m_Rep.GetList(db).Where(a => a.ParentId == parentId).OrderBy(a => a.Sort);
            return CreateModelList(ref queryData);
        }
        private List<cs_sysmoduleModel> CreateModelList(ref IQueryable<CS_SYSMODULE> queryData)
        {
            List<cs_sysmoduleModel> modelList = (from r in queryData
                                              select new cs_sysmoduleModel
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  EnglishName = r.EnglishName,
                                                  ParentId = r.ParentId,
                                                  Url = r.Url,
                                                  Iconic = r.Iconic,
                                                  Sort = r.Sort,
                                                  Remark = r.Remark,
                                                  Enable = r.Enable,
                                                  CreatePerson = r.CreatePerson,
                                                  CreateTime = r.CreateTime,
                                                  IsLast = r.IsLast
                                              }).ToList();
            return modelList;
        }


        public List<CS_SYSMODULE> GetModuleBySystem(string parentId)
        {

            return m_Rep.GetModuleBySystem(db, parentId).ToList();
        }

        public bool Create(ref ValidationErrors errors, cs_sysmoduleModel model)
        {

            try
            {
                CS_SYSMODULE entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_SYSMODULE();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.EnglishName = model.EnglishName;
                entity.ParentId = model.ParentId;
                entity.Url = model.Url;
                entity.Iconic = model.Iconic;
                entity.Sort = model.Sort;
                entity.Remark = model.Remark;
                entity.Enable = model.Enable;
                entity.CreatePerson = model.CreatePerson;
                entity.CreateTime = model.CreateTime;
                entity.IsLast = model.IsLast;
                if (m_Rep.Create(entity) == 1)
                {
                    //分配給角色
                    db.SP_SYS_INSERTSYSRIGHT();
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
                //檢查是否有下級
                if (db.CS_SYSMODULE.AsQueryable().Where(a => a.Id == id).Count() > 0)
                {
                    errors.Add("有下屬關聯，請先刪除下屬！");
                    return false;
                }
                m_Rep.Delete(db, id);
                if (db.SaveChanges() > 0)
                {
                    //清理無用的項
                    db.SP_SYS_ClearUnusedRIGHTOPERATE();
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

        public bool Edit(ref ValidationErrors errors, cs_sysmoduleModel model)
        {
            try
            {
                CS_SYSMODULE entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Name = model.Name;
                entity.EnglishName = model.EnglishName;
                entity.ParentId = model.ParentId;
                entity.Url = model.Url;
                entity.Iconic = model.Iconic;
                entity.Sort = model.Sort;
                entity.Remark = model.Remark;
                entity.Enable = model.Enable;
                entity.IsLast = model.IsLast;

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

        public cs_sysmoduleModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_SYSMODULE entity = m_Rep.GetById(id);
                cs_sysmoduleModel model = new cs_sysmoduleModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.EnglishName = entity.EnglishName;
                model.ParentId = entity.ParentId;
                model.Url = entity.Url;
                model.Iconic = entity.Iconic;
                model.Sort = entity.Sort;
                model.Remark = entity.Remark;
                model.Enable = entity.Enable;
                model.CreatePerson = entity.CreatePerson;
                model.CreateTime = entity.CreateTime;
                model.IsLast = entity.IsLast;
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
