using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class comtRepository : IcomtRepository, IDisposable
    {
        public IQueryable<V_COMT> GetList(CCSEntities db)
        {
            IQueryable<V_COMT> list = db.V_COMT.AsQueryable();
            return list;
        }

        public int Create(V_COMT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.V_COMT.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                V_COMT entity = db.V_COMT.SingleOrDefault(a => a.ID == id);
                if (entity != null)
                {

                    db.V_COMT.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<V_COMT> collection = from f in db.V_COMT
                                            where deleteCollection.Contains(f.VCH_NO)
                                          select f;
            foreach (var deleteItem in collection)
            {
                db.V_COMT.Remove(deleteItem);
            }
        }

        public int Edit(V_COMT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.V_COMT.Attach(entity);
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public V_COMT GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.V_COMT.SingleOrDefault(a => a.ID == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                V_COMT entity = GetById(id);
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
