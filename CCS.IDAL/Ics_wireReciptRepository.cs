using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_wireReciptRepository
    {
        IQueryable<CS_WIRE_RECIPIENT> GetList(CCSEntities db);
        int Create(CS_WIRE_RECIPIENT entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_WIRE_RECIPIENT entity);
        CS_WIRE_RECIPIENT GetById(string id);
        bool IsExist(string id);
    }
}
