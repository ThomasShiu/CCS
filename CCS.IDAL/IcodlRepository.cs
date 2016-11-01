using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface IcodlRepository
    {
        IQueryable<V_CODL> GetList(CCSEntities db);
        int Create(V_CODL entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(V_CODL entity);
        V_CODL GetById(string id);
        bool IsExist(string id);
    }
}
