using CCS.Common;
using CCS.Models.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_itemstkBLL
    {
        List<cs_itemstkModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, cs_itemstkModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_itemstkModel model);
        cs_itemstkModel GetById(string id);
        bool IsExist(string id);
    }
}
