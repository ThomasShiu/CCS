using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_sysmoduleoperateRepository : Ics_sysmoduleoperateRepository, IDisposable
    {
        public IQueryable<CS_SYSMODULEOPERATE> GetList(CCSEntities db)
        {
            IQueryable<CS_SYSMODULEOPERATE> list = db.CS_SYSMODULEOPERATE.AsQueryable();
            return list;
        }

        public int Create(CS_SYSMODULEOPERATE entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SYSMODULEOPERATE.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSMODULEOPERATE entity = db.CS_SYSMODULEOPERATE.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_SYSMODULEOPERATE.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public CS_SYSMODULEOPERATE GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_SYSMODULEOPERATE.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSMODULEOPERATE entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose()
        {

        }
    }
}
