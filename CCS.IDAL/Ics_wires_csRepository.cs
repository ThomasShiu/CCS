using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_wires_csRepository
    {
        IQueryable<CS_WIRES_CS> GetList(CCSEntities db);
        int Create(CS_WIRES_CS entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_WIRES_CS entity);
        CS_WIRES_CS GetById(string id);
        bool IsExist(string id);
    }
}
