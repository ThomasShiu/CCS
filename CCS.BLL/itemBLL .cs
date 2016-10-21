using CCS.BLL.Core;
using CCS.Common;
using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using CCS.Models.PUB;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CCS.BLL
{
    public class itemBLL:BaseBLL, IitemBLL
    {
        [Dependency]
        public IitemRepository m_Rep { get; set; }

        public List<itemModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<ITEM> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.ITEM_NO.Contains(queryStr) || a.ITEM_NM.Contains(queryStr) || a.ITEM_SP.Contains(queryStr) && a.ITEM_NO.StartsWith("6"));
            }
            else
            {
                queryData = m_Rep.GetList(db).Where(a => a.ITEM_NO.StartsWith("6"));  // 只列出成品
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        public List<itemModel> GetList(string queryStr)
        {

            IQueryable<ITEM> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.ITEM_NO.Contains(queryStr) || a.ITEM_NM.Contains(queryStr) || a.ITEM_SP.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            //pager.totalRows = queryData.Count();
            //queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }

        private List<itemModel> CreateModelList(ref IQueryable<ITEM> queryData)
        {

            List<itemModel> modelList = (from r in queryData
                                         select new itemModel
                                         {
                                             ITEM_NO = r.ITEM_NO,
                                             ITEM_NM = r.ITEM_NM,
                                             ITEM_SP = r.ITEM_SP,
                                             ITEM_NM_E = r.ITEM_NM_E,
                                             ITEM_SP_E = r.ITEM_SP_E,
                                             ITEM_NO_O = r.ITEM_NO_O
                                           
                                         }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, itemModel model)
        {
            try
            {
                ITEM entity = m_Rep.GetById(model.ITEM_NO);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new ITEM();
                entity.ITEM_NO = model.ITEM_NO;
                entity.ITEM_NM = model.ITEM_NM;
                entity.ITEM_SP = model.ITEM_SP;
                entity.ITEM_NM_E = model.ITEM_NM_E;
                entity.ITEM_SP_E = model.ITEM_SP_E;
                entity.ITEM_NO_O = model.ITEM_NO_O;
                entity.C_STA = model.C_STA;
                entity.GRAT_NO = model.GRAT_NO;
                entity.CLAS_NO = model.CLAS_NO;
                entity.CLAS_NO1 = model.CLAS_NO1;
                entity.CLAS_NO2 = model.CLAS_NO2;
                entity.CLAS_NO3 = model.CLAS_NO3;
                entity.CLAS_NO4 = model.CLAS_NO4;
                entity.CLAS_NO5 = model.CLAS_NO5;
                entity.CLAS_NO6 = model.CLAS_NO6;
                entity.CLAS_NO7 = model.CLAS_NO7;
                entity.CLAS_NO8 = model.CLAS_NO8;
                entity.CLAS_NO9 = model.CLAS_NO9;
                entity.CLAS_NO10 = model.CLAS_NO10;
                entity.CLAS_NO11 = model.CLAS_NO11;
                entity.CLAS_NO12 = model.CLAS_NO12;
                entity.ACT_NO = model.ACT_NO;
                entity.INV_TY = model.INV_TY;
                entity.FIN_ITEM_NO = model.FIN_ITEM_NO;
                entity.UNIT = model.UNIT;
                entity.UNIT1 = model.UNIT1;
                entity.UNIT2 = model.UNIT2;
                entity.UNIT3 = model.UNIT3;
                entity.EXCH_RATE1 = model.EXCH_RATE1;
                entity.EXCH_RATE2 = model.EXCH_RATE2;
                entity.EXCH_RATE3 = model.EXCH_RATE3;
                entity.C_AU = model.C_AU;
                entity.A_UNIT = model.A_UNIT;
                entity.W_UNIT = model.W_UNIT;
                entity.L_UNIT = model.L_UNIT;
                entity.S_UNIT = model.S_UNIT;
                entity.V_UNIT = model.V_UNIT;
                entity.WEIGHT = model.WEIGHT;
                entity.WEIGHT_DNN = model.WEIGHT_DNN;
                entity.LENGTH = model.LENGTH;
                entity.LENGTH_DNN = model.LENGTH_DNN;
                entity.AREA = model.AREA;
                entity.AREA_DNN = model.AREA_DNN;
                entity.VOLUMN = model.VOLUMN;
                entity.VOLUMN_DNN = model.VOLUMN_DNN;
                entity.SAFE_QTY = model.SAFE_QTY;
                entity.ROR_POT = model.ROR_POT;
                entity.SUP_POT = model.SUP_POT;
                entity.MIN_QTY = model.MIN_QTY;
                entity.PCH_QTY = model.PCH_QTY;
                entity.ISS_QTY = model.ISS_QTY;
                entity.UNIT_QTY = model.UNIT_QTY;
                entity.FIX_LT = model.FIX_LT;
                entity.LEAD_TIME = model.LEAD_TIME;
                entity.INSP_LT = model.INSP_LT;
                entity.LOT_QTY = model.LOT_QTY;
                entity.C_LT = model.C_LT;
                entity.WAHO_NO = model.WAHO_NO;
                entity.LOCA_NO = model.LOCA_NO;
                entity.VD_NO = model.VD_NO;
                entity.PLINE_NO = model.PLINE_NO;
                entity.EMP_NO = model.EMP_NO;
                entity.INV_EMP_NO = model.INV_EMP_NO;
                entity.PUR_EMP_NO = model.PUR_EMP_NO;
                entity.MOC_EMP_NO = model.MOC_EMP_NO;
                entity.TIN_CODE = model.TIN_CODE;
                entity.LLC_BOM = model.LLC_BOM;
                entity.LLC_CST = model.LLC_CST;
                entity.C_SOURCE = model.C_SOURCE;
                entity.C_BONDED = model.C_BONDED;
                entity.C_PHANT = model.C_PHANT;
                entity.C_BCH = model.C_BCH;
                entity.C_SR = model.C_SR;
                entity.C_LOCA = model.C_LOCA;
                entity.C_ROR = model.C_ROR;
                entity.C_CYC = model.C_CYC;
                entity.C_ISS = model.C_ISS;
                entity.C_INSP = model.C_INSP;
                entity.VLD_DAY = model.VLD_DAY;
                entity.CHK_DAY = model.CHK_DAY;
                entity.C_ABC = model.C_ABC;
                entity.MTR_CST = model.MTR_CST;
                entity.LAB_CST = model.LAB_CST;
                entity.OVH_CST = model.OVH_CST;
                entity.SBC_CST = model.SBC_CST;
                entity.LAB_ADD = model.LAB_ADD;
                entity.OVH_ADD = model.OVH_ADD;
                entity.SBC_ADD = model.SBC_ADD;
                entity.MTR_ADD = model.MTR_ADD;
                entity.MTR_RT = model.MTR_RT;
                entity.LAB_RT = model.LAB_RT;
                entity.OVH_RT = model.OVH_RT;
                entity.SBC_RT = model.SBC_RT;
                entity.STD_PCHPRC = model.STD_PCHPRC;
                entity.STD_SALPRC = model.STD_SALPRC;
                entity.STD_SALEXP = model.STD_SALEXP;
                entity.SAL_PRC = model.SAL_PRC;
                entity.C_TAX = model.C_TAX;
                entity.PACK_NO = model.PACK_NO;
                entity.C_CTL = model.C_CTL;
                entity.C_INV = model.C_INV;
                entity.ITEM_DSCP = model.ITEM_DSCP;
                entity.ITEM_DSCP1 = model.ITEM_DSCP1;
                entity.ITEM_DSCP2 = model.ITEM_DSCP2;
                entity.ITEM_DSCP3 = model.ITEM_DSCP3;
                entity.REMK = model.REMK;
                entity.IMG_NO = model.IMG_NO;
                entity.IMG_NO1 = model.IMG_NO1;
                entity.IMG_NO2 = model.IMG_NO2;
                entity.IMG_NO3 = model.IMG_NO3;
                entity.RT_ITEM_NO = model.RT_ITEM_NO;
                entity.RT_NO = model.RT_NO;
                entity.DOC_NO = model.DOC_NO;
                entity.BAR_CODE = model.BAR_CODE;
                entity.EFF_DT = model.EFF_DT;
                entity.EXP_DT = model.EXP_DT;
                entity.C_MPS = model.C_MPS;
                entity.C_OUT = model.C_OUT;
                entity.OUT_RT = model.OUT_RT;
                entity.C_OVR = model.C_OVR;
                entity.OVR_RT = model.OVR_RT;
                entity.QM_NO = model.QM_NO;
                entity.PINE_DAY = model.PINE_DAY;
                entity.PURE_DAY = model.PURE_DAY;
                entity.GD_NO = model.GD_NO;
                entity.SIZE = model.SIZE;
                entity.CTS_RT = model.CTS_RT;
                entity.PO_TY = model.PO_TY;
                entity.MO_TY = model.MO_TY;
                entity.C_COST = model.C_COST;
                entity.OWNER_USR_NO = model.OWNER_USR_NO;
                entity.OWNER_GRP_NO = model.OWNER_GRP_NO;
                entity.ADD_DT = model.ADD_DT;
                entity.MDY_USR_NO = model.MDY_USR_NO;
                entity.MDY_DT = model.MDY_DT;
                entity.IP_NM = model.IP_NM;
                entity.CP_NM = model.CP_NM;
                if (m_Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
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

        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
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

        public bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        m_Rep.Delete(db, deleteCollection);
                        if (db.SaveChanges() == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
        public bool Edit(ref ValidationErrors errors, itemModel model)
        {
            try
            {
                ITEM entity = m_Rep.GetById(model.ITEM_NO);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.ITEM_NO = model.ITEM_NO;
                entity.ITEM_NM = model.ITEM_NM;
                entity.ITEM_SP = model.ITEM_SP;
                entity.ITEM_NM_E = model.ITEM_NM_E;
                entity.ITEM_SP_E = model.ITEM_SP_E;
                entity.ITEM_NO_O = model.ITEM_NO_O;
                entity.C_STA = model.C_STA;
                entity.GRAT_NO = model.GRAT_NO;
                entity.CLAS_NO = model.CLAS_NO;
                entity.CLAS_NO1 = model.CLAS_NO1;
                entity.CLAS_NO2 = model.CLAS_NO2;
                entity.CLAS_NO3 = model.CLAS_NO3;
                entity.CLAS_NO4 = model.CLAS_NO4;
                entity.CLAS_NO5 = model.CLAS_NO5;
                entity.CLAS_NO6 = model.CLAS_NO6;
                entity.CLAS_NO7 = model.CLAS_NO7;
                entity.CLAS_NO8 = model.CLAS_NO8;
                entity.CLAS_NO9 = model.CLAS_NO9;
                entity.CLAS_NO10 = model.CLAS_NO10;
                entity.CLAS_NO11 = model.CLAS_NO11;
                entity.CLAS_NO12 = model.CLAS_NO12;
                entity.ACT_NO = model.ACT_NO;
                entity.INV_TY = model.INV_TY;
                entity.FIN_ITEM_NO = model.FIN_ITEM_NO;
                entity.UNIT = model.UNIT;
                entity.UNIT1 = model.UNIT1;
                entity.UNIT2 = model.UNIT2;
                entity.UNIT3 = model.UNIT3;
                entity.EXCH_RATE1 = model.EXCH_RATE1;
                entity.EXCH_RATE2 = model.EXCH_RATE2;
                entity.EXCH_RATE3 = model.EXCH_RATE3;
                entity.C_AU = model.C_AU;
                entity.A_UNIT = model.A_UNIT;
                entity.W_UNIT = model.W_UNIT;
                entity.L_UNIT = model.L_UNIT;
                entity.S_UNIT = model.S_UNIT;
                entity.V_UNIT = model.V_UNIT;
                entity.WEIGHT = model.WEIGHT;
                entity.WEIGHT_DNN = model.WEIGHT_DNN;
                entity.LENGTH = model.LENGTH;
                entity.LENGTH_DNN = model.LENGTH_DNN;
                entity.AREA = model.AREA;
                entity.AREA_DNN = model.AREA_DNN;
                entity.VOLUMN = model.VOLUMN;
                entity.VOLUMN_DNN = model.VOLUMN_DNN;
                entity.SAFE_QTY = model.SAFE_QTY;
                entity.ROR_POT = model.ROR_POT;
                entity.SUP_POT = model.SUP_POT;
                entity.MIN_QTY = model.MIN_QTY;
                entity.PCH_QTY = model.PCH_QTY;
                entity.ISS_QTY = model.ISS_QTY;
                entity.UNIT_QTY = model.UNIT_QTY;
                entity.FIX_LT = model.FIX_LT;
                entity.LEAD_TIME = model.LEAD_TIME;
                entity.INSP_LT = model.INSP_LT;
                entity.LOT_QTY = model.LOT_QTY;
                entity.C_LT = model.C_LT;
                entity.WAHO_NO = model.WAHO_NO;
                entity.LOCA_NO = model.LOCA_NO;
                entity.VD_NO = model.VD_NO;
                entity.PLINE_NO = model.PLINE_NO;
                entity.EMP_NO = model.EMP_NO;
                entity.INV_EMP_NO = model.INV_EMP_NO;
                entity.PUR_EMP_NO = model.PUR_EMP_NO;
                entity.MOC_EMP_NO = model.MOC_EMP_NO;
                entity.TIN_CODE = model.TIN_CODE;
                entity.LLC_BOM = model.LLC_BOM;
                entity.LLC_CST = model.LLC_CST;
                entity.C_SOURCE = model.C_SOURCE;
                entity.C_BONDED = model.C_BONDED;
                entity.C_PHANT = model.C_PHANT;
                entity.C_BCH = model.C_BCH;
                entity.C_SR = model.C_SR;
                entity.C_LOCA = model.C_LOCA;
                entity.C_ROR = model.C_ROR;
                entity.C_CYC = model.C_CYC;
                entity.C_ISS = model.C_ISS;
                entity.C_INSP = model.C_INSP;
                entity.VLD_DAY = model.VLD_DAY;
                entity.CHK_DAY = model.CHK_DAY;
                entity.C_ABC = model.C_ABC;
                entity.MTR_CST = model.MTR_CST;
                entity.LAB_CST = model.LAB_CST;
                entity.OVH_CST = model.OVH_CST;
                entity.SBC_CST = model.SBC_CST;
                entity.LAB_ADD = model.LAB_ADD;
                entity.OVH_ADD = model.OVH_ADD;
                entity.SBC_ADD = model.SBC_ADD;
                entity.MTR_ADD = model.MTR_ADD;
                entity.MTR_RT = model.MTR_RT;
                entity.LAB_RT = model.LAB_RT;
                entity.OVH_RT = model.OVH_RT;
                entity.SBC_RT = model.SBC_RT;
                entity.STD_PCHPRC = model.STD_PCHPRC;
                entity.STD_SALPRC = model.STD_SALPRC;
                entity.STD_SALEXP = model.STD_SALEXP;
                entity.SAL_PRC = model.SAL_PRC;
                entity.C_TAX = model.C_TAX;
                entity.PACK_NO = model.PACK_NO;
                entity.C_CTL = model.C_CTL;
                entity.C_INV = model.C_INV;
                entity.ITEM_DSCP = model.ITEM_DSCP;
                entity.ITEM_DSCP1 = model.ITEM_DSCP1;
                entity.ITEM_DSCP2 = model.ITEM_DSCP2;
                entity.ITEM_DSCP3 = model.ITEM_DSCP3;
                entity.REMK = model.REMK;
                entity.IMG_NO = model.IMG_NO;
                entity.IMG_NO1 = model.IMG_NO1;
                entity.IMG_NO2 = model.IMG_NO2;
                entity.IMG_NO3 = model.IMG_NO3;
                entity.RT_ITEM_NO = model.RT_ITEM_NO;
                entity.RT_NO = model.RT_NO;
                entity.DOC_NO = model.DOC_NO;
                entity.BAR_CODE = model.BAR_CODE;
                entity.EFF_DT = model.EFF_DT;
                entity.EXP_DT = model.EXP_DT;
                entity.C_MPS = model.C_MPS;
                entity.C_OUT = model.C_OUT;
                entity.OUT_RT = model.OUT_RT;
                entity.C_OVR = model.C_OVR;
                entity.OVR_RT = model.OVR_RT;
                entity.QM_NO = model.QM_NO;
                entity.PINE_DAY = model.PINE_DAY;
                entity.PURE_DAY = model.PURE_DAY;
                entity.GD_NO = model.GD_NO;
                entity.SIZE = model.SIZE;
                entity.CTS_RT = model.CTS_RT;
                entity.PO_TY = model.PO_TY;
                entity.MO_TY = model.MO_TY;
                entity.C_COST = model.C_COST;
                entity.OWNER_USR_NO = model.OWNER_USR_NO;
                entity.OWNER_GRP_NO = model.OWNER_GRP_NO;
                entity.ADD_DT = model.ADD_DT;
                entity.MDY_USR_NO = model.MDY_USR_NO;
                entity.MDY_DT = model.MDY_DT;
                entity.IP_NM = model.IP_NM;
                entity.CP_NM = model.CP_NM;

                if (m_Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.EditFail);
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

        public bool IsExists(string id)
        {
            if (db.ITEM.SingleOrDefault(a => a.ITEM_NO == id) != null)
            {
                return true;
            }
            return false;
        }

        public itemModel GetById(string id)
        {
            if (IsExist(id))
            {
                ITEM entity = m_Rep.GetById(id);
                itemModel model = new itemModel();
                model.ITEM_NO = entity.ITEM_NO;
                model.ITEM_NM = entity.ITEM_NM;
                model.ITEM_SP = entity.ITEM_SP;
                model.ITEM_NM_E = entity.ITEM_NM_E;
                model.ITEM_SP_E = entity.ITEM_SP_E;
                model.ITEM_NO_O = entity.ITEM_NO_O;
                model.C_STA = entity.C_STA;
                model.GRAT_NO = entity.GRAT_NO;
                model.CLAS_NO = entity.CLAS_NO;
                model.CLAS_NO1 = entity.CLAS_NO1;
                model.CLAS_NO2 = entity.CLAS_NO2;
                model.CLAS_NO3 = entity.CLAS_NO3;
                model.CLAS_NO4 = entity.CLAS_NO4;
                model.CLAS_NO5 = entity.CLAS_NO5;
                model.CLAS_NO6 = entity.CLAS_NO6;
                model.CLAS_NO7 = entity.CLAS_NO7;
                model.CLAS_NO8 = entity.CLAS_NO8;
                model.CLAS_NO9 = entity.CLAS_NO9;
                model.CLAS_NO10 = entity.CLAS_NO10;
                model.CLAS_NO11 = entity.CLAS_NO11;
                model.CLAS_NO12 = entity.CLAS_NO12;
                model.ACT_NO = entity.ACT_NO;
                model.INV_TY = entity.INV_TY;
                model.FIN_ITEM_NO = entity.FIN_ITEM_NO;
                model.UNIT = entity.UNIT;
                model.UNIT1 = entity.UNIT1;
                model.UNIT2 = entity.UNIT2;
                model.UNIT3 = entity.UNIT3;
                model.EXCH_RATE1 = entity.EXCH_RATE1.Value;
                model.EXCH_RATE2 = entity.EXCH_RATE2.Value;
                model.EXCH_RATE3 = entity.EXCH_RATE3.Value;
                model.C_AU = entity.C_AU;
                model.A_UNIT = entity.A_UNIT;
                model.W_UNIT = entity.W_UNIT;
                model.L_UNIT = entity.L_UNIT;
                model.S_UNIT = entity.S_UNIT;
                model.V_UNIT = entity.V_UNIT;
                model.WEIGHT = entity.WEIGHT.Value;
                model.WEIGHT_DNN = entity.WEIGHT_DNN.Value;
                model.LENGTH = entity.LENGTH.Value;
                model.LENGTH_DNN = entity.LENGTH_DNN.Value;
                model.AREA = entity.AREA.Value;
                model.AREA_DNN = entity.AREA_DNN.Value;
                model.VOLUMN = entity.VOLUMN.Value;
                model.VOLUMN_DNN = entity.VOLUMN_DNN.Value;
                model.SAFE_QTY = entity.SAFE_QTY.Value;
                model.ROR_POT = entity.ROR_POT.Value;
                model.SUP_POT = entity.SUP_POT.Value;
                model.MIN_QTY = entity.MIN_QTY.Value;
                model.PCH_QTY = entity.PCH_QTY.Value;
                model.ISS_QTY = entity.ISS_QTY.Value;
                model.UNIT_QTY = entity.UNIT_QTY.Value;
                model.FIX_LT = entity.FIX_LT.Value;
                model.LEAD_TIME = entity.LEAD_TIME.Value;
                model.INSP_LT = entity.INSP_LT.Value;
                model.LOT_QTY = entity.LOT_QTY.Value;
                model.C_LT = entity.C_LT;
                model.WAHO_NO = entity.WAHO_NO;
                model.LOCA_NO = entity.LOCA_NO;
                model.VD_NO = entity.VD_NO;
                model.PLINE_NO = entity.PLINE_NO;
                model.EMP_NO = entity.EMP_NO;
                model.INV_EMP_NO = entity.INV_EMP_NO;
                model.PUR_EMP_NO = entity.PUR_EMP_NO;
                model.MOC_EMP_NO = entity.MOC_EMP_NO;
                model.TIN_CODE = entity.TIN_CODE;
                model.LLC_BOM = entity.LLC_BOM.Value;
                model.LLC_CST = entity.LLC_CST.Value;
                model.C_SOURCE = entity.C_SOURCE;
                model.C_BONDED = entity.C_BONDED;
                model.C_PHANT = entity.C_PHANT;
                model.C_BCH = entity.C_BCH;
                model.C_SR = entity.C_SR;
                model.C_LOCA = entity.C_LOCA;
                model.C_ROR = entity.C_ROR;
                model.C_CYC = entity.C_CYC;
                model.C_ISS = entity.C_ISS;
                model.C_INSP = entity.C_INSP;
                model.VLD_DAY = entity.VLD_DAY.Value;
                model.CHK_DAY = entity.CHK_DAY.Value;
                model.C_ABC = entity.C_ABC;
                model.MTR_CST = entity.MTR_CST.Value;
                model.LAB_CST = entity.LAB_CST.Value;
                model.OVH_CST = entity.OVH_CST.Value;
                model.SBC_CST = entity.SBC_CST.Value;
                model.LAB_ADD = entity.LAB_ADD.Value;
                model.OVH_ADD = entity.OVH_ADD.Value;
                model.SBC_ADD = entity.SBC_ADD.Value;
                model.MTR_ADD = entity.MTR_ADD.Value;
                model.MTR_RT = entity.MTR_RT.Value;
                model.LAB_RT = entity.LAB_RT.Value;
                model.OVH_RT = entity.OVH_RT.Value;
                model.SBC_RT = entity.SBC_RT.Value;
                model.STD_PCHPRC = entity.STD_PCHPRC.Value;
                model.STD_SALPRC = entity.STD_SALPRC.Value;
                model.STD_SALEXP = entity.STD_SALEXP.Value;
                model.SAL_PRC = entity.SAL_PRC.Value;
                model.C_TAX = entity.C_TAX;
                model.PACK_NO = entity.PACK_NO;
                model.C_CTL = entity.C_CTL;
                model.C_INV = entity.C_INV;
                model.ITEM_DSCP = entity.ITEM_DSCP;
                model.ITEM_DSCP1 = entity.ITEM_DSCP1;
                model.ITEM_DSCP2 = entity.ITEM_DSCP2;
                model.ITEM_DSCP3 = entity.ITEM_DSCP3;
                model.REMK = entity.REMK;
                model.IMG_NO = entity.IMG_NO;
                model.IMG_NO1 = entity.IMG_NO1;
                model.IMG_NO2 = entity.IMG_NO2;
                model.IMG_NO3 = entity.IMG_NO3;
                model.RT_ITEM_NO = entity.RT_ITEM_NO;
                model.RT_NO = entity.RT_NO;
                model.DOC_NO = entity.DOC_NO;
                model.BAR_CODE = entity.BAR_CODE;
                model.EFF_DT = entity.EFF_DT.Value;
                model.EXP_DT = entity.EXP_DT.Value;
                model.C_MPS = entity.C_MPS;
                model.C_OUT = entity.C_OUT;
                model.OUT_RT = entity.OUT_RT.Value;
                model.C_OVR = entity.C_OVR;
                model.OVR_RT = entity.OVR_RT.Value;
                model.QM_NO = entity.QM_NO;
                model.PINE_DAY = entity.PINE_DAY.Value;
                model.PURE_DAY = entity.PURE_DAY.Value;
                model.GD_NO = entity.GD_NO;
                model.SIZE = entity.SIZE;
                model.CTS_RT = entity.CTS_RT.Value;
                model.PO_TY = entity.PO_TY;
                model.MO_TY = entity.MO_TY;
                model.C_COST = entity.C_COST;
                model.OWNER_USR_NO = entity.OWNER_USR_NO;
                model.OWNER_GRP_NO = entity.OWNER_GRP_NO;
                model.ADD_DT = entity.ADD_DT.Value;
                model.MDY_USR_NO = entity.MDY_USR_NO;
                model.MDY_DT = entity.MDY_DT.Value;
                model.IP_NM = entity.IP_NM;
                model.CP_NM = entity.CP_NM;
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
