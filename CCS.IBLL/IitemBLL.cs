using CCS.Common;
using CCS.Models.PUB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface IitemBLL
    {
        List<itemModel> GetList(ref GridPager pager, string queryStr);
        List<itemModel> GetList(string queryStr);
        bool Create(ref ValidationErrors errors, itemModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, itemModel model);
        itemModel GetById(string id);
        bool IsExist(string id);
    }
}
