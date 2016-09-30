using CCS.IDAL;
using CCS.Models;
using CCS.Models.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class cs_sysrightRepository : Ics_sysrightRepository, IDisposable
    {
        /// <summary>
        /// 取角色模組的操作許可權，用於許可權控制
        /// </summary>
        /// <param name="accountid">acount Id</param>
        /// <param name="controller">url</param>
        /// <returns></returns>
        public List<permModel> GetPermission(string accountid, string controller)
        {

            using (CCSEntities db = new CCSEntities())
            {
                List<permModel> rights = (from r in db.SP_SYS_GetRightOperate(accountid, controller)
                                          select new permModel
                                          {
                                              KeyCode = r.KeyCode,
                                              IsValid = r.IsValid
                                          }).ToList();
                return rights;
            }
        }
        public void Dispose()
        {

        }


    }
}
