using CCS.Common;
using CCS.Models.MAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_momtBLL
    {
        List<cs_momtModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_momtModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_momtModel model);
        cs_momtModel GetById(string id);
        bool IsExist(string id);
    }
}
