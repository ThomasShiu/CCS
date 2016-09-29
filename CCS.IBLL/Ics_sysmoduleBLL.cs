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
    public interface Ics_sysmoduleBLL
    {
        //List<CS_SYSMODULE> GetMenuByPersonId(string moduleId);
        List<CS_SYSMODULE> GetMenuByPersonId(string personId, string moduleId);

        List<cs_sysmoduleModel> GetList(string parentId);
        List<CS_SYSMODULE> GetModuleBySystem(string parentId);
        bool Create(ref ValidationErrors errors, cs_sysmoduleModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Edit(ref ValidationErrors errors, cs_sysmoduleModel model);
        cs_sysmoduleModel GetById(string id);
        bool IsExist(string id);
    }
}
