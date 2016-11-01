using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface IcomtRepository
    {
        IQueryable<V_COMT> GetList(CCSEntities db);
        int Create(V_COMT entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(V_COMT entity);
        V_COMT GetById(string id);
        bool IsExist(string id);
    }
}
