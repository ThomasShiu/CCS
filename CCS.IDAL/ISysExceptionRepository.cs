using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface ISysExceptionRepository
    {
        int Create(CS_SYSEXCEPTION entity);
        IQueryable<CS_SYSEXCEPTION> GetList(CCSEntities db);
        CS_SYSEXCEPTION GetById(string id);
    }
}
