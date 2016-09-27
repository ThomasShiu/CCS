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

        public List<CS_SYSMODULE> GetMenuByPersonId(string moduleId)
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


        public void Dispose()
        {

        }
    }
}
