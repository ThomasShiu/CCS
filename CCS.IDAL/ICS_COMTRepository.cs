using CCS.Models;
using System.ComponentModel;
using System.Linq;


namespace CCS.IDAL
{
    public interface Ics_comtRepository
    {
        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="db">資料庫上下文</param>
        /// <returns>數據清單</returns>
        IQueryable<CS_COMT> GetList(CCSEntities db);

        /// <summary>
        /// 創建一個實體
        /// </summary>
        /// <param name="entity">實體</param>
        int Create(CS_COMT entity);

        /// <summary>
        /// 刪除一個實體
        /// </summary>
        /// <param name="entity">主鍵ID</param>
        int Delete(string id);
        void Delete(CCSEntities db, string[] deleteCollection);
        /// <summary>
        /// 修改一個實體
        /// </summary>
        /// <param name="entity">實體</param>
        int Edit(CS_COMT entity);

        /// <summary>
        /// 獲得一個實體
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>實體</returns>
        CS_COMT GetById(string id);

        /// <summary>
        /// 判斷一個實體是否存在
        /// </summary>
        bool IsExist(string id);

    }
}
