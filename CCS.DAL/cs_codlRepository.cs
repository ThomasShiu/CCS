using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_codlRepository : Ics_codlRepository, IDisposable
    {
        public IQueryable<CS_CODL> GetList(CCSEntities db)
        {
            IQueryable<CS_CODL> list = db.CS_CODL.AsQueryable();
            return list;
        }

        public int Create(CS_CODL entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_CODL.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_CODL entity = db.CS_CODL.SingleOrDefault(a => a.ID == id);
                if (entity != null)
                {

                    db.CS_CODL.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_CODL> collection = from f in db.CS_CODL
                                             where deleteCollection.Contains(f.VCH_NO)
                                             select f;
            foreach (var deleteItem in collection)
            {
                db.CS_CODL.Remove(deleteItem);
            }
        }

        public int Edit(CS_CODL entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                //db.CS_CODL.Attach(entity);
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }

        public CS_CODL GetById(int id)
        {
            using (CCSEntities db = new CCSEntities())
            {
               
                return db.CS_CODL.SingleOrDefault(a => a.ID == id);
            }
        }

        public CS_CODL GetByNOSN(string v_no,int v_sn)
        {
            using (CCSEntities db = new CCSEntities())
            {
                var cs_codl = db.CS_CODL.Where(a => a.VCH_NO == v_no & a.VCH_SR == v_sn).SingleOrDefault();
                return cs_codl;
                //return db.CS_CODL.SingleOrDefault(a => a.ID == id);
            }
        }

        public bool IsExist(int id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_CODL entity = GetById(id);
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
