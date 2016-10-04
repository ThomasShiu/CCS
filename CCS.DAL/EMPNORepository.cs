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
    public class EMPNORepository : IEMPNORepository, IDisposable
    {

        public IQueryable<EMPNO> GetList(CCSEntities db)
        {
            IQueryable<EMPNO> list = db.EMPNO.AsQueryable();
            return list;
        }

        public int Create(EMPNO entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.EMPNO.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                EMPNO entity = db.EMPNO.SingleOrDefault(a => a.EMP_NO == id);
                if (entity != null)
                {

                    db.EMPNO.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<EMPNO> collection = from f in db.EMPNO
                                           where deleteCollection.Contains(f.EMP_NO)
                                           select f;
            foreach (var deleteItem in collection)
            {
                db.EMPNO.Remove(deleteItem);
            }
        }

        public int Edit(EMPNO entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.EMPNO.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }

        public EMPNO GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.EMPNO.SingleOrDefault(a => a.EMP_NO == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                EMPNO entity = GetById(id);
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
