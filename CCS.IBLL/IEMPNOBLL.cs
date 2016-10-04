using CCS.Common;
using CCS.Models.PUB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface IEMPNOBLL
    {
        List<empnoModel> GetList(string queryStr);
        List<empnoModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, empnoModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, empnoModel model);
        empnoModel GetById(string id);
        bool IsExist(string id);
    }
}
