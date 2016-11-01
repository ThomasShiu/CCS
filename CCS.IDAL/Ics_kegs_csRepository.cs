using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_kegs_csRepository
    {
        IQueryable<CS_KEGS_CS> GetList(CCSEntities db);
        int Create(CS_KEGS_CS entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_KEGS_CS entity);
        CS_KEGS_CS GetById(string id);
        bool IsExist(string id);
    }
}
