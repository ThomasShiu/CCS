using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface IEMPNORepository
    {
        IQueryable<EMPNO> GetList(CCSEntities db);
        int Create(EMPNO entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(EMPNO entity);
        EMPNO GetById(string id);
        bool IsExist(string id);
    }
}
