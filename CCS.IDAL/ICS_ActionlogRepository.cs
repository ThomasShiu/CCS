using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_actionlogRepository
    {

        int Create(CS_ACTIONLOG entity);
        void Delete(CCSEntities db, string[] deleteCollection);  // 多選刪除

        IQueryable<CS_ACTIONLOG> GetList(CCSEntities db);
        CS_ACTIONLOG GetById(int? id);

    }
}
