using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_itemstkRepository: Ics_itemstkRepository, IDisposable
    {
        public IQueryable<CS_ITEMSTK> GetList(CCSEntities db)
        {
            IQueryable<CS_ITEMSTK> list = db.CS_ITEMSTK.AsQueryable();
            return list;
        }

        public int Create(CS_ITEMSTK entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_ITEMSTK.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_ITEMSTK entity = db.CS_ITEMSTK.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_ITEMSTK.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_ITEMSTK> collection = from f in db.CS_ITEMSTK
                                                where deleteCollection.Contains(f.Id)
                                                select f;
            foreach (var deleteItem in collection)
            {
                db.CS_ITEMSTK.Remove(deleteItem);
            }
        }

        public int Edit(CS_ITEMSTK entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_ITEMSTK.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }

        public CS_ITEMSTK GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_ITEMSTK.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_ITEMSTK entity = GetById(id);
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
