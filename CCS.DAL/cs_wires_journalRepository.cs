using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_wires_journalRepository : Ics_wires_journalRepository, IDisposable
    {
        public IQueryable<CS_WIRES_JOURNAL> GetList(CCSEntities db)
        {
            IQueryable<CS_WIRES_JOURNAL> list = db.CS_WIRES_JOURNAL.AsQueryable();
            return list;
        }

        public int Create(CS_WIRES_JOURNAL entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIRES_JOURNAL.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIRES_JOURNAL entity = db.CS_WIRES_JOURNAL.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_WIRES_JOURNAL.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, int[] deleteCollection)
        {
            IQueryable<CS_WIRES_JOURNAL> collection = from f in db.CS_WIRES_JOURNAL
                                                      where deleteCollection.Contains(f.Id)
                                                      select f;
            foreach (var deleteItem in collection)
            {
                db.CS_WIRES_JOURNAL.Remove(deleteItem);
            }
        }

        public int Edit(CS_WIRES_JOURNAL entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIRES_JOURNAL.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }

        public CS_WIRES_JOURNAL GetById(int id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_WIRES_JOURNAL.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(int id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIRES_JOURNAL entity = GetById(id);
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
