using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_wipfRepository
    {
        IQueryable<CS_WIP_F> GetList(CCSEntities db);
        int Create(CS_WIP_F entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_WIP_F entity);
        CS_WIP_F GetById(string id);
        bool IsExist(string id);
    }
}
