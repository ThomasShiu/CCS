using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_sysroleRepository
    {
        IQueryable<CS_SYSROLE> GetList(CCSEntities db);
        int Create(CS_SYSROLE entity);
        int Delete(string id);
        int Edit(CS_SYSROLE entity);
        CS_SYSROLE GetById(string id);
        bool IsExist(string id);
    }
}
