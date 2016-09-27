using CCS.Models;
using System.ComponentModel;
using System.Linq;


namespace CCS.IDAL
{
    public interface Ics_comtRepository
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        IQueryable<CS_COMT> GetList(CCSEntities db);

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        int Create(CS_COMT entity);

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">主键ID</param>
        int Delete(string id);

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">实体</param>
        int Edit(CS_COMT entity);

        /// <summary>
        /// 获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        CS_COMT GetById(string id);

        /// <summary>
        /// 判断一个实体是否存在
        /// </summary>
        bool IsExist(string id);
    }
}
