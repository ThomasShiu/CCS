using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_sysmoduleoperateRepository
    {
        IQueryable<CS_SYSMODULEOPERATE> GetList(CCSEntities db);
        int Create(CS_SYSMODULEOPERATE entity);
        int Delete(string id);
        CS_SYSMODULEOPERATE GetById(string id);
        bool IsExist(string id);
    }
}
