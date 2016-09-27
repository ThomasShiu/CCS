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
    public class SysExceptionBLL : ISysExceptionBLL
    {
        [Dependency]
        public ISysExceptionRepository exceptionRepository { get; set; }


        public List<CS_SYSEXCEPTION> GetList(ref GridPager pager, string queryStr)
        {
            CCSEntities db = new CCSEntities();
            List<CS_SYSEXCEPTION> query = null;
            IQueryable<CS_SYSEXCEPTION> list = exceptionRepository.GetList(db);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr));
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
        public CS_SYSEXCEPTION GetById(string id)
        {
            return exceptionRepository.GetById(id);
        }
    }
}
