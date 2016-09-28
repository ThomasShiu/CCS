using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_sysmoduleRepository : Ics_sysmoduleRepository, IDisposable
    {

        public List<CS_SYSMODULE> GetMenuByPersonId1(string personId, string moduleId)
        {
            using (CCSEntities db = new CCSEntities())
            {
                var menus =
                (
                    from m in db.CS_SYSMODULE
                    where m.ParentId == moduleId
                    where m.Id != "0"
                    select m
                          ).Distinct().OrderBy(a => a.Sort).ToList();
                return menus;
            }
        }
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

        public void Dispose()
        {

        }
    }
}
