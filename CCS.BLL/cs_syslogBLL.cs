using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.BLL
{
    public class cs_syslogBLL: Ics_syslogBLL
    {
        [Dependency]
        public Ics_syslogRepository logRepository { get; set; }


        public List<CS_SYSLOG> GetList(ref GridPager pager, string queryStr)
        {
            CCSEntities db = new CCSEntities();
            List<CS_SYSLOG> query = null;
            IQueryable<CS_SYSLOG> list = logRepository.GetList(db);

            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr) || a.Module.Contains(queryStr));
                pager.totalRows = list.Count();
            }
            else
            {
                pager.totalRows = list.Count();
            }

            if (pager.order == "desc")
            {
                query = list.OrderByDescending(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
            else
            {
                query = list.OrderBy(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }


            return query;
        }
        public CS_SYSLOG GetById(string id)
        {
            return logRepository.GetById(id);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        public bool Delete(string id)
        {
            CCSEntities db = new CCSEntities();
            string[] ids = id.Split(',');
            try
            {
                //if (logRepository.Delete(db, ids) == 1)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
    }
}
