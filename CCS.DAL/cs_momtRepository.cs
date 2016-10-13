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
    public  class cs_momtRepository : Ics_momtRepository, IDisposable
    {
        public IQueryable<CS_MOMT> GetList(CCSEntities db)
        {
            IQueryable<CS_MOMT> list = db.CS_MOMT.AsQueryable();
            return list;
        }

        public int Create(CS_MOMT entity)
        {

            using (CCSEntities db = new CCSEntities())
            {
                db.CS_MOMT.Add(entity);
                return db.SaveChanges();
            }
       
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_MOMT entity = db.CS_MOMT.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_MOMT.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_MOMT> collection = from f in db.CS_MOMT
                                             where deleteCollection.Contains(f.Id)
                                             select f;
            foreach (var deleteItem in collection)
            {
                db.CS_MOMT.Remove(deleteItem);
            }
        }

        public int Edit(CS_MOMT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_MOMT.Attach(entity);
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public CS_MOMT GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_MOMT.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_MOMT entity = GetById(id);
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
