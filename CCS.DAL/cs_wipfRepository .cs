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
    public class cs_wipfRepository : Ics_wipfRepository, IDisposable
    {
        public IQueryable<CS_WIP_F> GetList(CCSEntities db)
        {
            IQueryable<CS_WIP_F> list = db.CS_WIP_F.AsQueryable();
            return list;
        }

        public int Create(CS_WIP_F entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIP_F.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIP_F entity = db.CS_WIP_F.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_WIP_F.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_WIP_F> collection = from f in db.CS_WIP_F
                                              where deleteCollection.Contains(f.Id)
                                              select f;
            foreach (var deleteItem in collection)
            {
                db.CS_WIP_F.Remove(deleteItem);
            }
        }

        public int Edit(CS_WIP_F entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_WIP_F.Attach(entity);
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public CS_WIP_F GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_WIP_F.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_WIP_F entity = GetById(id);
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
