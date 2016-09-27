using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_actionlogRepository: Ics_actionlogRepository, IDisposable
    {
        /// <summary>
        /// 獲取資料
        /// </summary>
        /// <param name="db">資料庫</param>
        /// <returns>集合</returns>
        public IQueryable<CS_ACTIONLOG> GetList(CCSEntities db)
        {
            IQueryable<CS_ACTIONLOG> list = db.CS_ACTIONLOG.AsQueryable();
            return list;
        }
        /// <summary>
        /// 創建一個對象
        /// </summary>
        /// <param name="db">資料庫</param>
        /// <param name="entity">實體</param>
        public int Create(CS_ACTIONLOG entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_ACTIONLOG.Add(entity);
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
            IQueryable<CS_ACTIONLOG> collection = from f in db.CS_ACTIONLOG
                                                  //where deleteCollection.Contains(f.LogId)
                                               select f;
            foreach (var deleteItem in collection)
            {
                db.CS_ACTIONLOG.Remove(deleteItem);
            }
        }
        /// <summary>
        /// 根據ID獲取一個實體
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public CS_ACTIONLOG GetById(int? id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_ACTIONLOG.SingleOrDefault(a => a.LogId == id);
            }
        }
        public void Dispose()
        {

        }
    }
}
