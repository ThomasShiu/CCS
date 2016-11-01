using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_shipmtRepository : Ics_shipmtRepository, IDisposable
    {
        public IQueryable<CS_SHIPMT> GetList(CCSEntities db)
        {
            IQueryable<CS_SHIPMT> list = db.CS_SHIPMT.AsQueryable();
            return list;
        }

        public int Create(CS_SHIPMT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SHIPMT.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SHIPMT entity = db.CS_SHIPMT.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_SHIPMT.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_SHIPMT> collection = from f in db.CS_SHIPMT
                                               where deleteCollection.Contains(f.Id)
                                               select f;
            foreach (var deleteItem in collection)
            {
                db.CS_SHIPMT.Remove(deleteItem);
            }
        }

        public int Edit(CS_SHIPMT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SHIPMT.Attach(entity);
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public CS_SHIPMT GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_SHIPMT.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SHIPMT entity = GetById(id);
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
