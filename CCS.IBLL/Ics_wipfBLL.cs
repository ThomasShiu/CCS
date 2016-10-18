using CCS.Common;
using CCS.Models.MAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_wipfBLL
    {
        List<cs_wipfModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_wipfModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_wipfModel model);
        cs_wipfModel GetById(string id);
        bool IsExist(string id);
    }
}
