using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.SYS;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.BLL
{
    public class cs_sysrightBLL : BaseBLL, Ics_sysrightBLL
    {

        [Dependency]
        public Ics_sysrightRepository SysRightRepository { get; set; }
        public List<permModel> GetPermission(string accountid, string controllor)
        {
            return SysRightRepository.GetPermission(accountid, controllor);
        }

        public List<SP_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            return SysRightRepository.GetRightByRoleAndModule(roleId, moduleId);
        }

        public int UpdateRight(cs_sysrightoperateModel model)
        {
            return SysRightRepository.UpdateRight(model);
        }
    }
}
