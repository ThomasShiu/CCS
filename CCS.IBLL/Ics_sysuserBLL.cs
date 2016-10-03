using CCS.Common;
using CCS.Models.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_sysuserBLL
    {
        List<permModel> GetPermission(string accountid, string controller);

        List<cs_sysuserModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_sysuserModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_sysuserModel model);
        cs_sysuserModel GetById(string id);
        bool IsExist(string id);
    }
}
