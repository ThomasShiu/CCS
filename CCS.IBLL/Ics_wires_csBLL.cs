using CCS.Common;
using CCS.Models.WIR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_wires_csBLL
    {
        List<cs_wires_csModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_wires_csModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_wires_csModel model);
        cs_wires_csModel GetById(string id);
        bool IsExist(string id);
    }
}
