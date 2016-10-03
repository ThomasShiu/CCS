using CCS.Common;
using CCS.Models.SYS;
using System.Collections.Generic;


namespace CCS.IBLL
{
    public interface Ics_sysroleBLL
    {
        List<cs_sysroleModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_sysroleModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Edit(ref ValidationErrors errors, cs_sysroleModel model);
        cs_sysroleModel GetById(string id);
        bool IsExist(string id);
    }
}
