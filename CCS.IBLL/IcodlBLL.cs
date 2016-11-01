using CCS.Common;
using CCS.Models.SAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface IcodlBLL
    {
        List<CODLModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, CODLModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, CODLModel model);
        CODLModel GetById(string id);
        bool IsExist(string id);
    }
}
