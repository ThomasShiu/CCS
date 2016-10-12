using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_wiresRepository
    {
        IQueryable<CS_WIRES> GetList(CCSEntities db);
        int Create(CS_WIRES entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_WIRES entity);
        CS_WIRES GetById(string id);
        bool IsExist(string id);
    }
}
