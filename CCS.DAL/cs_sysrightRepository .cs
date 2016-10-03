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

        public int UpdateRight(cs_sysrightoperateModel model)
        {
            //轉換
            CS_SYSRIGHTOPERATE rightOperate = new CS_SYSRIGHTOPERATE();
            rightOperate.Id = model.Id;
            rightOperate.RightId = model.RightId;
            rightOperate.KeyCode = model.KeyCode;
            rightOperate.IsValid = model.IsValid;
            //判斷rightOperate是否存在，如果存在就更新rightOperate,否則就添加一條
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSRIGHTOPERATE right = db.CS_SYSRIGHTOPERATE.Where(a => a.Id == rightOperate.Id).FirstOrDefault();
                if (right != null)
                {
                    right.IsValid = rightOperate.IsValid;
                }
                else
                {
                    db.CS_SYSRIGHTOPERATE.Add(rightOperate);
                }
                if (db.SaveChanges() > 0)
                {
                    //更新角色--模組的有效標誌RightFlag
                    var sysRight = (from r in db.CS_SYSRIGHT
                                    where r.Id == rightOperate.RightId
                                    select r).First();
                    db.SP_Sys_UpdateSysRightRightFlag(sysRight.ModuleId, sysRight.RoleId);
                    return 1;
                }
            }
            return 0;
        }
        //按選擇的角色及模組載入模組的許可權項
        public List<SP_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            List<SP_Sys_GetRightByRoleAndModule_Result> result = null;
            using (CCSEntities db = new CCSEntities())
            {
                result = db.SP_Sys_GetRightByRoleAndModule(roleId, moduleId).ToList();
            }
            return result;
        }


        public void Dispose()
        {

        }


    }
}
