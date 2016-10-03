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
    public  class cs_comtBLL :Ics_comtBLL
    {

        CCSEntities db = new CCSEntities();

        //public ISysSampleRepository Rep { get; set; }
        //ICS_COMTRepository Rep = new CS_COMTRepository();

        [Dependency]
        public Ics_comtRepository Rep { get; set; }

        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="pager">JQgrid分頁</param>
        /// <param name="queryStr">搜索條件</param>
        /// <returns>列表</returns>
        public List<cs_comtModel> GetList(ref GridPager pager, string queryStr)
        {
            IQueryable<CS_COMT> queryData = null;
            //queryData = Rep.GetList(db);
            //return CreateModelList(ref queryData);

            queryData = Rep.GetList(db);

            //排序 由大到小
            queryData = LinqHelper.DataSorting(queryData, pager.sort, pager.order);

            //if (pager.order == "desc")
            //{
            //    switch (pager.order)
            //    {
            //        case "VCH_NO":
            //            queryData = queryData.OrderByDescending(c => c.VCH_NO);
            //            break;
            //        case "VCH_DT":
            //            queryData = queryData.OrderByDescending(c => c.VCH_DT);
            //            break;
            //        default:
            //            queryData = queryData.OrderByDescending(c => c.VCH_NO);
            //            break;
            //    }
            //}
            //else
            //{
            //    // 由小到大
            //    switch (pager.order)
            //    {
            //        case "VCH_NO":
            //            queryData = queryData.OrderBy(c => c.VCH_NO);
            //            break;
            //        case "VCH_DT":
            //            queryData = queryData.OrderBy(c => c.VCH_DT);
            //            break;
            //        default:
            //            queryData = queryData.OrderBy(c => c.VCH_NO);
            //            break;
            //    }
            //}

            if (queryStr != null & queryStr != "")
            {
                queryData = queryData.Where(c => c.VCH_NO.Contains(queryStr));
            }
            return CreateModelList(ref pager, ref queryData);

        }
        private List<cs_comtModel> CreateModelList(ref GridPager pager, ref IQueryable<CS_COMT> queryData)
        {
            pager.totalRows = queryData.Count();
            if (pager.totalRows > 0)
            {
                if (pager.page <= 1)
                {
                    queryData = queryData.Take(pager.rows);
                }
                else
                {
                    queryData = queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
                }
            }

            List<cs_comtModel> modelList = (from r in queryData
                                            select new cs_comtModel
                                            {
                                                VCH_NO = r.VCH_NO,
                                                VCH_DT = r.VCH_DT,
                                                FA_NO = r.FA_NO,
                                                CS_NO = r.CS_NO,
                                                DEPM_NO = r.DEPM_NO,
                                                EMP_NO = r.EMP_NO,
                                                CURRENCY = r.CURRENCY,
                                                C_CFM = r.C_CFM,
                                                //ITEM_NO = r.ITEM_NO,
                                                QTY = r.QTY,
                                                //UNIT = r.UNIT,
                                               // PRC = r.PRC,
                                                AMT = r.AMT,
                                                //RCV_QTY = r.RCV_QTY,
                                                //PL = r.PL
                                            }).ToList();
            return modelList;
        }
        /// <summary>
        /// 創建一個實體
        /// </summary>
        /// <param name="errors">持久的錯誤資訊</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Create(ref ValidationErrors errors, cs_comtModel model)
        {
            try
            {
                CS_COMT entity = Rep.GetById(model.VCH_NO);
                if (entity != null)
                {
                    errors.Add("主鍵重複");
                    return false;
                }
                entity = new CS_COMT();
                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.FA_NO = model.FA_NO;
                entity.CS_NO = model.CS_NO;
                entity.CURRENCY = model.CURRENCY;             
                entity.QTY = model.QTY;
                entity.AMT = model.AMT;
                entity.C_CFM = model.C_CFM;

               


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
        public bool Edit(ref ValidationErrors errors, cs_comtModel model)
        {
            try
            {
                CS_COMT entity = Rep.GetById(model.VCH_NO);
                if (entity == null)
                {
                    errors.Add("主鍵重複");
                    return false;
                }

                entity.VCH_NO = model.VCH_NO;
                entity.VCH_DT = model.VCH_DT;
                entity.CS_NO = model.CS_NO;
                entity.CURRENCY = model.CURRENCY;
                entity.C_CFM = model.C_CFM;
             
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
            if (db.CS_COMT.SingleOrDefault(a => a.VCH_NO == id) != null)
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
        public cs_comtModel GetById(string id)
        {
            if (IsExist(id))
            {
                CS_COMT entity = Rep.GetById(id);
                cs_comtModel model = new cs_comtModel();

                model.VCH_NO = entity.VCH_NO;
                model.VCH_DT = entity.VCH_DT;
                model.CS_NO = entity.CS_NO;
                model.CURRENCY = entity.CURRENCY;
                model.C_CFM = entity.C_CFM;
           
                return model;
            }
            else
            {
                return new cs_comtModel();
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
