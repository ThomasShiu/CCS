using System;
using System.Collections.Generic;
using System.Linq;
using CCS.Models;
//using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models.SAL;
using Microsoft.Practices.Unity;
using CCS.Common;
using CCS.BLL.Core;

namespace CCS.BLL
{
    public class customerBLL:IcustomerBLL
    {
        CCSEntities db = new CCSEntities();

        //public ISysSampleRepository Rep { get; set; }
        //ICS_COMTRepository Rep = new CS_COMTRepository();

        [Dependency]
        public IcustomerRepository Rep { get; set; }

        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="pager">JQgrid分頁</param>
        /// <param name="queryStr">搜索條件</param>
        /// <returns>列表</returns>
        public List<customerModel> GetList(string queryStr)
        {
            IQueryable<customer> queryData = null;
            queryData = Rep.GetList(db);
            return CreateModelList(ref queryData);

           // queryData = Rep.GetList(db);

           // //排序 由大到小
           // //queryData = LinqHelper.DataSorting(queryData, pager.sort, pager.order);

           //if (queryStr != null & queryStr != "")
           // {
           //     queryData = queryData.Where(c => c.CS_NO.Contains(queryStr));
           // }
           // return CreateModelList(ref queryData);

        }
        private List<customerModel> CreateModelList( ref IQueryable<customer> queryData)
        {
   
            List<customerModel> modelList = (from r in queryData
                                            select new customerModel
                                            {
                                                CS_NO = r.CS_NO,
                                                SHORT_NM = r.SHORT_NM,
                                                ADDR_IVC = r.ADDR_IVC,
                                                CONTACTER = r.CONTACTER,
                                                TEL_NO = r.TEL_NO,
                                                FAX_NO = r.FAX_NO
                                            }).ToList();
            return modelList;
        }
        /// <summary>
        /// 創建一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Create(ref ValidationErrors errors, customerModel model)
        {
            try
            {
                customer entity = Rep.GetById(model.CS_NO);
                if (entity != null)
                {
                    errors.Add("主鍵重複");
                    return false;
                }
                entity = new customer();
                entity.CS_NO = model.CS_NO;
                entity.SHORT_NM = model.SHORT_NM;
                entity.ADDR_IVC = model.ADDR_IVC;
                entity.CONTACTER = model.CONTACTER;
                entity.TEL_NO = model.TEL_NO;
                entity.FAX_NO = model.FAX_NO;

                if (Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add("插入失敗");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 刪除一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add("刪除失敗");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 修改一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Edit(ref ValidationErrors errors, customerModel model)
        {
            try
            {
                customer entity = Rep.GetById(model.CS_NO);
                if (entity == null)
                {
                    errors.Add("主鍵重複");
                    return false;
                }

                entity.CS_NO = model.CS_NO;
                entity.SHORT_NM = model.SHORT_NM;
                entity.ADDR_IVC = model.ADDR_IVC;
                entity.CONTACTER = model.CONTACTER;
                entity.TEL_NO = model.TEL_NO;
                entity.FAX_NO = model.FAX_NO;

                if (Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add("編輯失敗");
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 判斷是否存在實體
        /// </summary>
        /// <param name="id">主鍵ID</param>
        /// <returns>是否存在</returns>
        public bool IsExists(string id)
        {
            if (db.customer.SingleOrDefault(a => a.CS_NO == id) != null)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// 根據ID獲得一個實體
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>實體</returns>
        public customer GetById(string id)
        {
            if (IsExist(id))
            {
                customer entity = Rep.GetById(id);
                customer model = new customer();

                model.CS_NO = entity.CS_NO;
                model.SHORT_NM = entity.SHORT_NM;
                model.ADDR_IVC = entity.ADDR_IVC;
                model.CONTACTER = entity.CONTACTER;
                model.TEL_NO = entity.TEL_NO;
                model.FAX_NO = entity.FAX_NO;

                return model;
            }
            else
            {
                return new customer();
            }
        }

        /// <summary>
        /// 判斷一個實體是否存在
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            return Rep.IsExist(id);
        }
    }
}
