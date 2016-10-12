using CCS.Common;
using CCS.Models.WIR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_wiresBLL
    {
        List<cs_wiresModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_wiresModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_wiresModel model);
        cs_wiresModel GetById(string id);
        bool IsExist(string id);
    }
}
