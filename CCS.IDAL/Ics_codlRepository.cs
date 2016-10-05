using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface  Ics_codlRepository
    {
        IQueryable<CS_CODL> GetList(CCSEntities db);
        int Create(CS_CODL entity);
        int Delete(int id);
        void Delete(CCSEntities db, string[] deleteCollection);
        int Edit(CS_CODL entity);
        CS_CODL GetById(int id);
        CS_CODL GetByNOSN(string v_no, int v_sn);

        bool IsExist(int id);
    }
}
