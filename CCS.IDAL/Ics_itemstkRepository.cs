using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_itemstkRepository
    {
        IQueryable<CS_ITEMSTK> GetList(CCSEntities db);
        int Create(CS_ITEMSTK entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_ITEMSTK entity);
        CS_ITEMSTK GetById(string id);
        bool IsExist(string id);
    }
}
