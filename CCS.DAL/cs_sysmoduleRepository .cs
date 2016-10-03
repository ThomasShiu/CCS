using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_sysmoduleRepository : Ics_sysmoduleRepository, IDisposable
    {
        public List<CS_SYSMODULE> GetMenuByPersonId(string personId, string moduleId)
        {
            using (CCSEntities db = new CCSEntities())
            {
                var menus =
                (
                    from m in db.CS_SYSMODULE
                    join rl in db.CS_SYSRIGHT
                    on m.Id equals rl.ModuleId
                    join r in
                        (from r in db.CS_SYSROLE
                         from u in r.CS_SYSUSER
                         where u.Id == personId
                         select r)
                    on rl.RoleId equals r.Id
                    where rl.Rightflag == true
                    where m.ParentId == moduleId
                    where m.Id != "0"
                    select m
                          ).Distinct().OrderBy(a => a.Sort).ToList();
                return menus;
            }
        }
        public IQueryable<CS_SYSMODULE> GetList(CCSEntities db)
            {
                IQueryable<CS_SYSMODULE> list = db.CS_SYSMODULE.AsQueryable();
                return list;
            }

            public IQueryable<CS_SYSMODULE> GetModuleBySystem(CCSEntities db, string parentId)
            {
                return db.CS_SYSMODULE.Where(a => a.ParentId == parentId).AsQueryable();
            }

            public int Create(CS_SYSMODULE entity)
            {
                using (CCSEntities db = new CCSEntities())
                {
                    db.CS_SYSMODULE.Add(entity);
                    return db.SaveChanges();
                }
            }

            public void Delete(CCSEntities db, string id)
            {
            CS_SYSMODULE entity = db.CS_SYSMODULE.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    //刪除SysRight表資料
                    var sr = db.CS_SYSRIGHT.AsQueryable().Where(a => a.ModuleId == id);
                    foreach (var o in sr)
                    {
                        //刪除SysRightOperate表資料
                        var sro = db.CS_SYSRIGHTOPERATE.AsQueryable().Where(a => a.RightId == o.Id);
                        foreach (var o2 in sro)
                        {
                            db.CS_SYSRIGHTOPERATE.Remove(o2);
                        }
                        db.CS_SYSRIGHT.Remove(o);
                    }
                    //刪除SysModuleOperate資料
                    var smo = db.CS_SYSMODULEOPERATE.AsQueryable().Where(a => a.Id == id);
                    foreach (var o3 in smo)
                    {
                        db.CS_SYSMODULEOPERATE.Remove(o3);
                    }
                    db.CS_SYSMODULE.Remove(entity);
                }
            }

            public int Edit(CS_SYSMODULE entity)
            {
                using (CCSEntities db = new CCSEntities())
                {
                    db.CS_SYSMODULE.Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                    //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                    return db.SaveChanges();
                }
            }

            public CS_SYSMODULE GetById(string id)
            {
                using (CCSEntities db = new CCSEntities())
                {
                    return db.CS_SYSMODULE.SingleOrDefault(a => a.Id == id);
                }
            }

            public bool IsExist(string id)
            {
                using (CCSEntities db = new CCSEntities())
                {
                CS_SYSMODULE entity = GetById(id);
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
