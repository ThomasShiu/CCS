using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_momtRepository
    {
        IQueryable<CS_MOMT> GetList(CCSEntities db);
        int Create(CS_MOMT entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_MOMT entity);
        CS_MOMT GetById(string id);
        bool IsExist(string id);
    }
}
