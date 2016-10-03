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
    public class cs_sysuserRepository : Ics_sysuserRepository, IDisposable
    {

        public IQueryable<CS_SYSUSER> GetList(CCSEntities db)
        {
            IQueryable<CS_SYSUSER> list = db.CS_SYSUSER.AsQueryable();
            return list;
        }

        public int Create(CS_SYSUSER entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SYSUSER.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSUSER entity = db.CS_SYSUSER.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.CS_SYSUSER.Add(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_SYSUSER> collection = from f in db.CS_SYSUSER
                                                where deleteCollection.Contains(f.Id)
                                                select f;
            foreach (var deleteItem in collection)
            {
                db.CS_SYSUSER.Remove(deleteItem);
            }
        }

        public int Edit(CS_SYSUSER entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SYSUSER.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }

        public CS_SYSUSER GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_SYSUSER.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSUSER entity = GetById(id);
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
