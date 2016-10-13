using CCS.Common;
using CCS.Models.SAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_codlBLL
    {
        List<cs_codlModel> GetList(ref GridPager pager, string queryStr);
        //List<cs_codlModel> GetList(string queryStr);
        bool Create(ref ValidationErrors errors, cs_codlModel model);
        bool Delete(ref ValidationErrors errors, int id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, cs_codlModel model);
        cs_codlModel GetById(int id);
        bool IsExist(int id);
    }
}
