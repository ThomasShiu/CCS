using CCS.Common;
using CCS.Models;
using CCS.Models.PUB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface IcustomerBLL
    {
        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="pager">JQgrid分頁</param>
        /// <param name="queryStr">搜索條件</param>
        /// <returns>列表</returns>
        List<customerModel> GetList(string queryStr);
        //List<CS_COMT> GetList(string queryStr);

        /// <summary>
        /// 創建一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        bool Create(ref ValidationErrors errors, customerModel model);

        /// <summary>
        /// 刪除一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        bool Delete(ref ValidationErrors errors, string id);


        /// <summary>
        /// 修改一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        bool Edit(ref ValidationErrors errors, customerModel model);

        /// <summary>
        /// 根據ID獲得一個Model實體
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Model實體</returns>
        customer GetById(string id);

        /// <summary>
        /// 判斷是否存在實體
        /// </summary>
        /// <param name="id">主鍵ID</param>
        /// <returns>是否存在</returns>
        bool IsExist(string id);
    }
}
