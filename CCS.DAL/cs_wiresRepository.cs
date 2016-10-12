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
    public class cs_wiresRepository: Ics_wiresRepository, IDisposable
    {
        public IQueryable<CS_WIRES> GetList(CCSEntities db)
        {
            IQueryable<CS_WIRES> list = db.CS_WIRES.AsQueryable();
            return list;
        }

        public int Create(CS_WIRES entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIRES.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIRES entity = db.CS_WIRES.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_WIRES.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_WIRES> collection = from f in db.CS_WIRES
                                              where deleteCollection.Contains(f.Id)
                                              select f;
            foreach (var deleteItem in collection)
            {
                db.CS_WIRES.Remove(deleteItem);
            }
        }

        public int Edit(CS_WIRES entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIRES.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public CS_WIRES GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_WIRES.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIRES entity = GetById(id);
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
