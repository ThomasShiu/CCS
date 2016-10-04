using CCS.Common;
using CCS.Models;
using CCS.Models.SAL;
using System.Collections.Generic;

namespace CCS.IBLL
{
    public interface Ics_comtBLL
    {
        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="pager">JQgrid分頁</param>
        /// <param name="queryStr">搜索條件</param>
        /// <returns>列表</returns>
        List<cs_comtModel> GetList(ref GridPager pager, string queryStr);
        //List<CS_COMT> GetList(string queryStr);

        /// <summary>
        /// 創建一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        bool Create(ref ValidationErrors errors, cs_comtModel model);

        /// <summary>
        /// 刪除一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);

        /// <summary>
        /// 修改一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        bool Edit(ref ValidationErrors errors, cs_comtModel model);

        /// <summary>
        /// 根據ID獲得一個Model實體
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Model實體</returns>
        cs_comtModel GetById(string id);

        /// <summary>
        /// 判斷是否存在實體
        /// </summary>
        /// <param name="id">主鍵ID</param>
        /// <returns>是否存在</returns>
        bool IsExist(string id);

    }
}
