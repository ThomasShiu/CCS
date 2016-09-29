using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_sysmoduleRepository
    {
        //List<CS_SYSMODULE> GetMenuByPersonId(string moduleId);
        List<CS_SYSMODULE> GetMenuByPersonId(string personId, string moduleId);
        
        IQueryable<CS_SYSMODULE> GetList(CCSEntities db);
        IQueryable<CS_SYSMODULE> GetModuleBySystem(CCSEntities db, string parentId);
        int Create(CS_SYSMODULE entity);
        void Delete(CCSEntities db, string id);
        int Edit(CS_SYSMODULE entity);
        CS_SYSMODULE GetById(string id);
        bool IsExist(string id);

      
    }
}
