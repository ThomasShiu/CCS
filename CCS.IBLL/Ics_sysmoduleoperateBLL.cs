using CCS.Common;
using CCS.Models.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_sysmoduleoperateBLL
    {
        List<cs_sysmoduleopertaeModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_sysmoduleopertaeModel model);
        bool Delete(ref ValidationErrors errors, string id);
        cs_sysmoduleopertaeModel GetById(string id);
        bool IsExist(string id);
    }
}
