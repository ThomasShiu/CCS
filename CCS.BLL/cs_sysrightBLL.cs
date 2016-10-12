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
using System.Transactions;

namespace CCS.BLL
{
    public class cs_sysrightBLL : BaseBLL, Ics_sysrightBLL
    {
        // 角色授權
        [Dependency]
        public Ics_sysrightRepository SysRightRepository { get; set; }

        public List<permModel> GetPermission(string accountid, string controllor)
        {
            return SysRightRepository.GetPermission(accountid, controllor);
        }

        public List<SP_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            return SysRightRepository.GetRightByRoleAndModule(roleId, moduleId);
        }

        public int UpdateRight(cs_sysrightoperateModel model)
        {
            return SysRightRepository.UpdateRight(model);
        }

        // 授權管理
        [Dependency]
        public Ics_sysrightRepository sysright_Rep { get; set; }

        public List<cs_sysrightModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<CS_SYSRIGHT> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = sysright_Rep.GetList(db).Where(a => a.Id.Contains(queryStr) || a.ModuleId.Contains(queryStr));
            }
            else
            {
                queryData = sysright_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        public List<cs_sysrightModel> GetList( string queryStr)
        {

            IQueryable<CS_SYSRIGHT> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = sysright_Rep.GetList(db).Where(a => a.Id.Contains(queryStr) || a.ModuleId.Contains(queryStr));
            }
            else
            {
                queryData = sysright_Rep.GetList(db);
            }
           
            return CreateModelList(ref queryData);
        }

        private List<cs_sysrightModel> CreateModelList(ref IQueryable<CS_SYSRIGHT> queryData)
        {

            List<cs_sysrightModel> modelList = (from r in queryData
                                                select new cs_sysrightModel
                                                {
                                                    Id = r.Id,
                                                    ModuleId = r.ModuleId,
                                                    RoleId = r.RoleId,
                                                    Rightflag = r.Rightflag
                                                }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, cs_sysrightModel model)
        {
            try
            {
                CS_SYSRIGHT entity = sysright_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new CS_SYSRIGHT();
                entity.Id = model.Id;
                entity.ModuleId = model.ModuleId;
                entity.RoleId = model.RoleId;
                entity.Rightflag = model.Rightflag;
                if (sysright_Rep.Create(entity) == 1)
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
                if (sysright_Rep.Delete(id) == 1)
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
                        sysright_Rep.Delete(db, deleteCollection);
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
        public bool Edit(ref ValidationErrors errors, cs_sysrightModel model)
        {
            try
            {
                CS_SYSRIGHT entity = sysright_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.ModuleId = model.ModuleId;
                entity.RoleId = model.RoleId;
                entity.Rightflag = model.Rightflag;

                if (sysright_Rep.Edit(entity) == 1)
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
            if (db.CS_SYSRIGHT.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public cs_sysrightModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_SYSRIGHT entity = sysright_Rep.GetById(id);
                cs_sysrightModel model = new cs_sysrightModel();
                model.Id = entity.Id;
                model.ModuleId = entity.ModuleId;
                model.RoleId = entity.RoleId;
                model.Rightflag = entity.Rightflag;
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return sysright_Rep.IsExist(id);
        }
    }
}
