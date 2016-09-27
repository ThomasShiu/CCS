using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_syslogRepository
    {
        int Create(CS_SYSLOG entity);
        void Delete(CCSEntities db, string[] deleteCollection);  // 多選刪除

        IQueryable<CS_SYSLOG> GetList(CCSEntities db);
        CS_SYSLOG GetById(string id);
    }
}
