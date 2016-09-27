using CCS.Common;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_actionlogBLL
    {
        List<CS_ACTIONLOG> GetList(ref GridPager pager, string queryStr);
        CS_ACTIONLOG GetById(string id);

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        bool Delete(int? id);
    }
}
