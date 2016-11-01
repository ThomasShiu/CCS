using CCS.Common;
using CCS.Models.INV;
using CCS.Models.SAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_shipmtBLL 
    {
        List<cs_shipmtModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_shipmtModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_shipmtModel model);
        cs_shipmtModel GetById(string id);
        bool IsExist(string id);
    }
}
