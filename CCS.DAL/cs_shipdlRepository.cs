using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public  class cs_shipdlRepository : Ics_shipdlRepository, IDisposable
    {
        public IQueryable<CS_SHIPDL> GetList(CCSEntities db)
        {
            IQueryable<CS_SHIPDL> list = db.CS_SHIPDL.AsQueryable();
            return list;
        }

        public int Create(CS_SHIPDL entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SHIPDL.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SHIPDL entity = db.CS_SHIPDL.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_SHIPDL.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_SHIPDL> collection = from f in db.CS_SHIPDL
                                               where deleteCollection.Contains(f.Id)
                                               select f;
            foreach (var deleteItem in collection)
            {
                db.CS_SHIPDL.Remove(deleteItem);
            }
        }

        public int Edit(CS_SHIPDL entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SHIPDL.Attach(entity);
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public CS_SHIPDL GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_SHIPDL.SingleOrDefault(a => a.Id == id);
            }
        }
        public CS_SHIPDL GetByNo(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_SHIPDL.SingleOrDefault(a => a.VCH_NO == id);
            }
        }
        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SHIPDL entity = GetById(id);
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
