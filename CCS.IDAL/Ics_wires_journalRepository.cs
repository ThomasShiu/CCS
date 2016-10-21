using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_wires_journalRepository
    {
        IQueryable<CS_WIRES_JOURNAL> GetList(CCSEntities db);
        int Create(CS_WIRES_JOURNAL entity);
        int Delete(int id);
        void Delete(CCSEntities db, int[] deleteCollection);
        int Edit(CS_WIRES_JOURNAL entity);
        CS_WIRES_JOURNAL GetById(int id);
        bool IsExist(int id);
    }

}
