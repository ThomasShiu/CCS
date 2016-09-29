using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface IcustomerRepository
    {
        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="db">資料庫上下文</param>
        /// <returns>數據清單</returns>
        IQueryable<customer> GetList(CCSEntities db);

        /// <summary>
        /// 創建一個實體
        /// </summary>
        /// <param name="entity">實體</param>
        int Create(customer entity);

        /// <summary>
        /// 刪除一個實體
        /// </summary>
        /// <param name="entity">主鍵ID</param>
        int Delete(string id);

        /// <summary>
        /// 修改一個實體
        /// </summary>
        /// <param name="entity">實體</param>
        int Edit(customer entity);

        /// <summary>
        /// 獲得一個實體
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>實體</returns>
        customer GetById(string id);

        /// <summary>
        /// 判斷一個實體是否存在
        /// </summary>
        bool IsExist(string id);

    }
}
