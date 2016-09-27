using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class SysExceptionRepository : IDisposable, ISysExceptionRepository
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <returns>集合</returns>
        public IQueryable<CS_SYSEXCEPTION> GetList(CCSEntities db)
        {
            IQueryable<CS_SYSEXCEPTION> list = db.CS_SYSEXCEPTION.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="entity">实体</param>
        public int Create(CS_SYSEXCEPTION entity)
        {
            using (CCSEntities db = new CCSEntities())
            {
                db.CS_SYSEXCEPTION.Add(entity);
                return db.SaveChanges();
            }

        }


        /// <summary>
        /// 根据ID获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CS_SYSEXCEPTION GetById(string id)
        {
            using (CCSEntities db = new CCSEntities())
            {
                return db.CS_SYSEXCEPTION.SingleOrDefault(a => a.Id == id);
            }
        }
        public void Dispose()
        {

        }
    }
}
