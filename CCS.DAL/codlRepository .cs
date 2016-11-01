using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class codlRepository : IcodlRepository, IDisposable
    {
        public IQueryable<V_CODL> GetList(CCSEntities db)
        {
            IQueryable<V_CODL> list = db.V_CODL.AsQueryable();
            return list;
        }

        public int Create(V_CODL entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.V_CODL.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                V_CODL entity = db.V_CODL.SingleOrDefault(a => a.ID == id);
                if (entity != null)
                {

                    db.V_CODL.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<V_CODL> collection = from f in db.V_CODL
                                               where deleteCollection.Contains(f.ID)
                                               select f;
            foreach (var deleteItem in collection)
            {
                db.V_CODL.Remove(deleteItem);
            }
        }

        public int Edit(V_CODL entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.V_CODL.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public V_CODL GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.V_CODL.SingleOrDefault(a => a.ID == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                V_CODL entity = GetById(id);
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
