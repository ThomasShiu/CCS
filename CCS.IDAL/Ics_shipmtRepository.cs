using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_shipmtRepository
    {
        IQueryable<CS_SHIPMT> GetList(CCSEntities db);
        int Create(CS_SHIPMT entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_SHIPMT entity);
        CS_SHIPMT GetById(string id);
        bool IsExist(string id);
    }
}
