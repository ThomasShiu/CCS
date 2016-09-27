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
        /// 获取列表
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        public IQueryable<CS_COMT> GetList(CCSEntities db)
        {
            IQueryable<CS_COMT> list = db.CS_COMT.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">实体</param>
        public int Create(CS_COMT entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_COMT.Add(entity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">主键ID</param>
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

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">实体</param>
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
        /// 获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public CS_COMT GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_COMT.SingleOrDefault(a => a.VCH_NO == id);
            }
        }
        /// <summary>
        /// 判断一个实体是否存在
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
