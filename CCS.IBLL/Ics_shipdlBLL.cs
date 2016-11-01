using CCS.Common;
using CCS.Models.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_shipdlBLL
    {
        List<cs_shipdlModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_shipdlModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_shipdlModel model);
        cs_shipdlModel GetById(string id);
        cs_shipdlModel GetByNo(string id);
        bool IsExist(string id);
    }
}
