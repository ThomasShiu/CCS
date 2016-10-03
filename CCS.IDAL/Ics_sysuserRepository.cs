using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_sysuserRepository
    {
        IQueryable<CS_SYSUSER> GetList(CCSEntities db);
        int Create(CS_SYSUSER entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_SYSUSER entity);
        CS_SYSUSER GetById(string id);
        bool IsExist(string id);
    }
}
