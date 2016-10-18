using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_wireReciptRepository : Ics_wireReciptRepository, IDisposable
    {
        public IQueryable<CS_WIRE_RECIPIENT> GetList(CCSEntities db)
        {
            IQueryable<CS_WIRE_RECIPIENT> list = db.CS_WIRE_RECIPIENT.AsQueryable();
            return list;
        }

        public int Create(CS_WIRE_RECIPIENT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIRE_RECIPIENT.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIRE_RECIPIENT entity = db.CS_WIRE_RECIPIENT.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_WIRE_RECIPIENT.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_WIRE_RECIPIENT> collection = from f in db.CS_WIRE_RECIPIENT
                                                       where deleteCollection.Contains(f.Id)
                                                       select f;
            foreach (var deleteItem in collection)
            {
                db.CS_WIRE_RECIPIENT.Remove(deleteItem);
            }
        }

        public int Edit(CS_WIRE_RECIPIENT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIRE_RECIPIENT.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public CS_WIRE_RECIPIENT GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_WIRE_RECIPIENT.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIRE_RECIPIENT entity = GetById(id);
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
