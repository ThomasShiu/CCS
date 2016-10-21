using CCS.Common;
using CCS.Models.WIR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public  interface Ics_wires_journalBLL
    {
        List<cs_wires_journalModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_wires_journalModel model);
        bool Delete(ref ValidationErrors errors, int id);
        bool Delete(ref ValidationErrors errors, int[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_wires_journalModel model);
        cs_wires_journalModel GetById(int id);
        bool IsExist(int id);
    }
}
