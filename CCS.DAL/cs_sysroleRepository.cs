using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_sysroleRepository: Ics_sysroleRepository, IDisposable
    {
        public IQueryable<CS_SYSROLE> GetList(CCSEntities db)
        {
            IQueryable<CS_SYSROLE> list = db.CS_SYSROLE.AsQueryable();
            return list;
        }

        public int Create(CS_SYSROLE entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SYSROLE.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSROLE entity = db.CS_SYSROLE.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_SYSROLE.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public int Edit(CS_SYSROLE entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SYSROLE.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }

        public CS_SYSROLE GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_SYSROLE.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSROLE entity = GetById(id);
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
