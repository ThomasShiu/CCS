using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface IitemRepository
    {
        IQueryable<ITEM> GetList(CCSEntities db);
        int Create(ITEM entity);
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(ITEM entity);
        ITEM GetById(string id);
        bool IsExist(string id);
    }
}
