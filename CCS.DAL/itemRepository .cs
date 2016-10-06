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
    public class itemRepository : IitemRepository, IDisposable
    {
        public IQueryable<ITEM> GetList(CCSEntities db)
        {
            IQueryable<ITEM> list = db.ITEM.AsQueryable();
            return list;
        }

        public int Create(ITEM entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.ITEM.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                ITEM entity = db.ITEM.SingleOrDefault(a => a.ITEM_NO == id);
                if (entity != null)
                {

                    db.ITEM.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<ITEM> collection = from f in db.ITEM
                                          where deleteCollection.Contains(f.ITEM_NO)
                                          select f;
            foreach (var deleteItem in collection)
            {
                db.ITEM.Remove(deleteItem);
            }
        }

        public int Edit(ITEM entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.ITEM.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);

                return db.SaveChanges();
            }
        }

        public ITEM GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.ITEM.SingleOrDefault(a => a.ITEM_NO == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                ITEM entity = GetById(id);
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
