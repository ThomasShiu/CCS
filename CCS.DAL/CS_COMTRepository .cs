using CCS.Models;
using System;
using System.Linq;
using System.Data.Entity;
using CCS.IDAL;

namespace CCS.DAL
{
    public  class CS_COMTRepository : Ics_comtRepository, IDisposable
    {
        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="db">資料庫上下文</param>
        /// <returns>數據清單</returns>
        public IQueryable<CS_COMT> GetList(CCSEntities db)
        {
            IQueryable<CS_COMT> list = db.CS_COMT.AsQueryable();
            return list;
        }
        /// <summary>
        /// 創建一個實體
        /// </summary>
        /// <param name="db">資料庫上下文</param>
        /// <param name="entity">實體</param>
        public int Create(CS_COMT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_COMT.Add(entity);
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
                CS_COMT entity = db.CS_COMT.SingleOrDefault(a => a.VCH_NO == id);
                if (entity != null)
                {

                    db.CS_COMT.Remove(entity);
                }
                return db.SaveChanges();
            }
        }
        public void Delete(CCSEntities db, string[] deleteCollection)
        {
            IQueryable<CS_COMT> collection = from f in db.CS_COMT
                                             where deleteCollection.Contains(f.VCH_NO)
                                             select f;
            foreach (var deleteItem in collection)
            {
                db.CS_COMT.Remove(deleteItem);
            }
        }

        /// <summary>
        /// 修改一個實體
        /// </summary>
        /// <param name="db">資料庫上下文</param>
        /// <param name="entity">實體</param>
        public int Edit(CS_COMT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {


                db.CS_COMT.Attach(entity);
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
        public CS_COMT GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_COMT.SingleOrDefault(a => a.VCH_NO == id);
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
                CS_COMT entity = GetById(id);
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
