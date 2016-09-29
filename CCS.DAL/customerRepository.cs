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
    public class customerRepository: IcustomerRepository, IDisposable
    {
        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="db">資料庫上下文</param>
        /// <returns>數據清單</returns>
        public IQueryable<customer> GetList(CCSEntities db)
        {
            IQueryable<customer> list = db.customer.AsQueryable();
            return list;
        }
        /// <summary>
        /// 創建一個實體
        /// </summary>
        /// <param name="db">資料庫上下文</param>
        /// <param name="entity">實體</param>
        public int Create(customer entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.customer.Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 刪除一個實體
        /// </summary>
        /// <param name="db">資料庫上下文</param>
        /// <param name="entity">主鍵ID</param>
        public int Delete(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                customer entity = db.customer.SingleOrDefault(a => a.CS_NO == id);
                if (entity != null)
                {

                    db.customer.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 修改一個實體
        /// </summary>
        /// <param name="db">資料庫上下文</param>
        /// <param name="entity">實體</param>
        public int Edit(customer entity)
        {
            using (CCSEntities db = new CCSEntities())
            {


                db.customer.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 獲得一個實體
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>實體</returns>
        public customer GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.customer.SingleOrDefault(a => a.CS_NO == id);
            }
        }
        /// <summary>
        /// 判斷一個實體是否存在
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                customer entity = GetById(id);
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
