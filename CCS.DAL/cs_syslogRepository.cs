using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_syslogRepository : Ics_syslogRepository, IDisposable
    {
        /// <summary>
        /// 獲取資料
        /// </summary>
        /// <param name="db">資料庫</param>
        /// <returns>集合</returns>
        public IQueryable<CS_SYSLOG> GetList(CCSEntities db)
        {
            IQueryable<CS_SYSLOG> list = db.CS_SYSLOG.AsQueryable();
            return list;
        }
        /// <summary>
        /// 創建一個對象
        /// </summary>
        /// <param name="db">資料庫</param>
        /// <param name="entity">實體</param>
        public int Create(CS_SYSLOG entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SYSLOG.Add(entity);
                return db.SaveChanges();
            }

        }

        /// <summary>
        /// 刪除對象集合
        /// </summary>
        /// <param name="db">資料庫</param>
        /// <param name="deleteCollection">集合</param>
        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_SYSLOG> collection = from f in db.CS_SYSLOG
                                               where deleteCollection.Contains(f.Id)
                                            select f;
            foreach (var deleteItem in collection)
            {
                db.CS_SYSLOG.Remove(deleteItem);
            }
        }
        /// <summary>
        /// 根據ID獲取一個實體
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public CS_SYSLOG GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_SYSLOG.SingleOrDefault(a => a.Id == id);
            }
        }
        public void Dispose()
        {

        }
    }
}
