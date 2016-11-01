using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_wires_csRepository : Ics_wires_csRepository, IDisposable
    {
        public IQueryable<CS_WIRES_CS> GetList(CCSEntities db)
        {
            IQueryable<CS_WIRES_CS> list = db.CS_WIRES_CS.AsQueryable();
            return list;
        }

        public int Create(CS_WIRES_CS entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIRES_CS.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIRES_CS entity = db.CS_WIRES_CS.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_WIRES_CS.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_WIRES_CS> collection = from f in db.CS_WIRES_CS
                                                 where deleteCollection.Contains(f.Id)
                                                 select f;
            foreach (var deleteItem in collection)
            {
                db.CS_WIRES_CS.Remove(deleteItem);
            }
        }

        public int Edit(CS_WIRES_CS entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIRES_CS.Attach(entity);
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public CS_WIRES_CS GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_WIRES_CS.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIRES_CS entity = GetById(id);
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
