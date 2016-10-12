using CCS.IDAL;
using CCS.Models;
using CCS.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_sysrightRepository : Ics_sysrightRepository, IDisposable
    {
        /// <summary>
        /// 取角色模組的操作許可權，用於許可權控制
        /// </summary>
        /// <param name="accountid">acount Id</param>
        /// <param name="controller">url</param>
        /// <returns></returns>
        public List<permModel> GetPermission(string accountid, string controller)
        {

            using (CCSEntities db = new CCSEntities())
            {
                List<permModel> rights = (from r in db.SP_SYS_GetRightOperate(accountid, controller)
                                          select new permModel
                                          {
                                              KeyCode = r.KeyCode,
                                              IsValid = r.IsValid
                                          }).ToList();
                return rights;
            }
        }

        public int UpdateRight(cs_sysrightoperateModel model)
        {
            //轉換
            CS_SYSRIGHTOPERATE rightOperate = new CS_SYSRIGHTOPERATE();
            rightOperate.Id = model.Id;
            rightOperate.RightId = model.RightId;
            rightOperate.KeyCode = model.KeyCode;
            rightOperate.IsValid = model.IsValid;
            //判斷rightOperate是否存在，如果存在就更新rightOperate,否則就添加一條
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSRIGHTOPERATE right = db.CS_SYSRIGHTOPERATE.Where(a => a.Id == rightOperate.Id).FirstOrDefault();
                if (right != null)
                {
                    right.IsValid = rightOperate.IsValid;
                }
                else
                {
                    db.CS_SYSRIGHTOPERATE.Add(rightOperate);
                }
                if (db.SaveChanges() > 0)
                {
                    //更新角色--模組的有效標誌RightFlag
                    var sysRight = (from r in db.CS_SYSRIGHT
                                    where r.Id == rightOperate.RightId
                                    select r).First();
                    db.SP_Sys_UpdateSysRightRightFlag(sysRight.ModuleId, sysRight.RoleId);
                    return 1;
                }
            }
            return 0;
        }
        //按選擇的角色及模組載入模組的許可權項
        public List<SP_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            List<SP_Sys_GetRightByRoleAndModule_Result> result = null;
            using (CCSEntities db = new CCSEntities())
            {
                result = db.SP_Sys_GetRightByRoleAndModule(roleId, moduleId).ToList();
            }
            return result;
        }

        public IQueryable<CS_SYSRIGHT> GetList(CCSEntities db)
        {
            IQueryable<CS_SYSRIGHT> list = db.CS_SYSRIGHT.AsQueryable();
            return list;
        }

        public int Create(CS_SYSRIGHT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SYSRIGHT.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSRIGHT entity = db.CS_SYSRIGHT.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_SYSRIGHT.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_SYSRIGHT> collection = from f in db.CS_SYSRIGHT
                                                 where deleteCollection.Contains(f.Id)
                                                 select f;
            foreach (var deleteItem in collection)
            {
                db.CS_SYSRIGHT.Remove(deleteItem);
            }
        }

        public int Edit(CS_SYSRIGHT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SYSRIGHT.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public CS_SYSRIGHT GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_SYSRIGHT.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSRIGHT entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }

        public void Dispose()
        {

        }


    }
}
