using CCS.Common;
using CCS.Models.KEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_kegs_csBLL
    {
        List<cs_kegs_csModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_kegs_csModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_kegs_csModel model);
        cs_kegs_csModel GetById(string id);
        bool IsExist(string id);
    }
}
