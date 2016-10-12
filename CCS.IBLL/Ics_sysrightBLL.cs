using CCS.Common;
using CCS.Models;
using CCS.Models.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_sysrightBLL
    {
        List<permModel> GetPermission(string accountid, string controller);

        //更新
        int UpdateRight(cs_sysrightoperateModel model);
        //按選擇的角色及模組載入模組的許可權項
        List<SP_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId);

        List<cs_sysrightModel> GetList(ref GridPager pager, string queryStr);
        List<cs_sysrightModel> GetList(string queryStr);
        bool Create(ref ValidationErrors errors, cs_sysrightModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_sysrightModel model);
        cs_sysrightModel GetById(string id);
        bool IsExist(string id);
    }
}
