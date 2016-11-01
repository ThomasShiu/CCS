using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_shipdlRepository
    {
        IQueryable<CS_SHIPDL> GetList(CCSEntities db);
        int Create(CS_SHIPDL entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_SHIPDL entity);
        CS_SHIPDL GetById(string id);
        CS_SHIPDL GetByNo(string id);
        bool IsExist(string id);
    }
}
