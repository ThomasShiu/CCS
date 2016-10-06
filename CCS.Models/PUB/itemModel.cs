using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.PUB
{
    public class itemModel
    {
        [Display(Name = "ITEM_NO")]
        public String ITEM_NO { get; set; }

        [Display(Name = "ITEM_NM")]
        public String ITEM_NM { get; set; }

        [Display(Name = "ITEM_SP")]
        public String ITEM_SP { get; set; }

        [Display(Name = "ITEM_NM_E")]
        public string ITEM_NM_E { get; set; }

        [Display(Name = "ITEM_SP_E")]
        public string ITEM_SP_E { get; set; }

        [Display(Name = "ITEM_NO_O")]
        public String ITEM_NO_O { get; set; }

        [Display(Name = "C_STA")]
        public String C_STA { get; set; }

        [Display(Name = "GRAT_NO")]
        public String GRAT_NO { get; set; }

        [Display(Name = "CLAS_NO")]
        public String CLAS_NO { get; set; }

        [Display(Name = "CLAS_NO1")]
        public String CLAS_NO1 { get; set; }

        [Display(Name = "CLAS_NO2")]
        public String CLAS_NO2 { get; set; }

        [Display(Name = "CLAS_NO3")]
        public String CLAS_NO3 { get; set; }

        [Display(Name = "CLAS_NO4")]
        public String CLAS_NO4 { get; set; }

        [Display(Name = "CLAS_NO5")]
        public String CLAS_NO5 { get; set; }

        [Display(Name = "CLAS_NO6")]
        public String CLAS_NO6 { get; set; }

        [Display(Name = "CLAS_NO7")]
        public String CLAS_NO7 { get; set; }

        [Display(Name = "CLAS_NO8")]
        public String CLAS_NO8 { get; set; }

        [Display(Name = "CLAS_NO9")]
        public String CLAS_NO9 { get; set; }

        [Display(Name = "CLAS_NO10")]
        public String CLAS_NO10 { get; set; }

        [Display(Name = "CLAS_NO11")]
        public String CLAS_NO11 { get; set; }

        [Display(Name = "CLAS_NO12")]
        public String CLAS_NO12 { get; set; }

        [Display(Name = "ACT_NO")]
        public String ACT_NO { get; set; }

        [Display(Name = "INV_TY")]
        public String INV_TY { get; set; }

        [Display(Name = "FIN_ITEM_NO")]
        public String FIN_ITEM_NO { get; set; }

        [Display(Name = "UNIT")]
        public String UNIT { get; set; }

        [Display(Name = "UNIT1")]
        public String UNIT1 { get; set; }

        [Display(Name = "UNIT2")]
        public String UNIT2 { get; set; }

        [Display(Name = "UNIT3")]
        public String UNIT3 { get; set; }

        [Display(Name = "EXCH_RATE1")]
        public decimal EXCH_RATE1 { get; set; }

        [Display(Name = "EXCH_RATE2")]
        public decimal EXCH_RATE2 { get; set; }

        [Display(Name = "EXCH_RATE3")]
        public decimal EXCH_RATE3 { get; set; }

        [Display(Name = "C_AU")]
        public String C_AU { get; set; }

        [Display(Name = "A_UNIT")]
        public String A_UNIT { get; set; }

        [Display(Name = "W_UNIT")]
        public String W_UNIT { get; set; }

        [Display(Name = "L_UNIT")]
        public String L_UNIT { get; set; }

        [Display(Name = "S_UNIT")]
        public String S_UNIT { get; set; }

        [Display(Name = "V_UNIT")]
        public String V_UNIT { get; set; }

        [Display(Name = "WEIGHT")]
        public decimal WEIGHT { get; set; }

        [Display(Name = "WEIGHT_DNN")]
        public decimal WEIGHT_DNN { get; set; }

        [Display(Name = "LENGTH")]
        public decimal LENGTH { get; set; }

        [Display(Name = "LENGTH_DNN")]
        public decimal LENGTH_DNN { get; set; }

        [Display(Name = "AREA")]
        public decimal AREA { get; set; }

        [Display(Name = "AREA_DNN")]
        public decimal AREA_DNN { get; set; }

        [Display(Name = "VOLUMN")]
        public decimal VOLUMN { get; set; }

        [Display(Name = "VOLUMN_DNN")]
        public decimal VOLUMN_DNN { get; set; }

        [Display(Name = "SAFE_QTY")]
        public decimal SAFE_QTY { get; set; }

        [Display(Name = "ROR_POT")]
        public decimal ROR_POT { get; set; }

        [Display(Name = "SUP_POT")]
        public decimal SUP_POT { get; set; }

        [Display(Name = "MIN_QTY")]
        public decimal MIN_QTY { get; set; }

        [Display(Name = "PCH_QTY")]
        public decimal PCH_QTY { get; set; }

        [Display(Name = "ISS_QTY")]
        public decimal ISS_QTY { get; set; }

        [Display(Name = "UNIT_QTY")]
        public decimal UNIT_QTY { get; set; }

        [Display(Name = "FIX_LT")]
        public int FIX_LT { get; set; }

        [Display(Name = "LEAD_TIME")]
        public int LEAD_TIME { get; set; }

        [Display(Name = "INSP_LT")]
        public int INSP_LT { get; set; }

        [Display(Name = "LOT_QTY")]
        public decimal LOT_QTY { get; set; }

        [Display(Name = "C_LT")]
        public String C_LT { get; set; }

        [Display(Name = "WAHO_NO")]
        public String WAHO_NO { get; set; }

        [Display(Name = "LOCA_NO")]
        public String LOCA_NO { get; set; }

        [Display(Name = "VD_NO")]
        public String VD_NO { get; set; }

        [Display(Name = "PLINE_NO")]
        public String PLINE_NO { get; set; }

        [Display(Name = "EMP_NO")]
        public String EMP_NO { get; set; }

        [Display(Name = "INV_EMP_NO")]
        public String INV_EMP_NO { get; set; }

        [Display(Name = "PUR_EMP_NO")]
        public String PUR_EMP_NO { get; set; }

        [Display(Name = "MOC_EMP_NO")]
        public String MOC_EMP_NO { get; set; }

        [Display(Name = "TIN_CODE")]
        public String TIN_CODE { get; set; }

        [Display(Name = "LLC_BOM")]
        public int LLC_BOM { get; set; }

        [Display(Name = "LLC_CST")]
        public int LLC_CST { get; set; }

        [Display(Name = "C_SOURCE")]
        public String C_SOURCE { get; set; }

        [Display(Name = "C_BONDED")]
        public String C_BONDED { get; set; }

        [Display(Name = "C_PHANT")]
        public String C_PHANT { get; set; }

        [Display(Name = "C_BCH")]
        public String C_BCH { get; set; }

        [Display(Name = "C_SR")]
        public String C_SR { get; set; }

        [Display(Name = "C_LOCA")]
        public String C_LOCA { get; set; }

        [Display(Name = "C_ROR")]
        public String C_ROR { get; set; }

        [Display(Name = "C_CYC")]
        public String C_CYC { get; set; }

        [Display(Name = "C_ISS")]
        public String C_ISS { get; set; }

        [Display(Name = "C_INSP")]
        public String C_INSP { get; set; }

        [Display(Name = "VLD_DAY")]
        public int VLD_DAY { get; set; }

        [Display(Name = "CHK_DAY")]
        public int CHK_DAY { get; set; }

        [Display(Name = "C_ABC")]
        public String C_ABC { get; set; }

        [Display(Name = "MTR_CST")]
        public decimal MTR_CST { get; set; }

        [Display(Name = "LAB_CST")]
        public decimal LAB_CST { get; set; }

        [Display(Name = "OVH_CST")]
        public decimal OVH_CST { get; set; }

        [Display(Name = "SBC_CST")]
        public decimal SBC_CST { get; set; }

        [Display(Name = "LAB_ADD")]
        public decimal LAB_ADD { get; set; }

        [Display(Name = "OVH_ADD")]
        public decimal OVH_ADD { get; set; }

        [Display(Name = "SBC_ADD")]
        public decimal SBC_ADD { get; set; }

        [Display(Name = "MTR_ADD")]
        public decimal MTR_ADD { get; set; }

        [Display(Name = "MTR_RT")]
        public decimal MTR_RT { get; set; }

        [Display(Name = "LAB_RT")]
        public decimal LAB_RT { get; set; }

        [Display(Name = "OVH_RT")]
        public decimal OVH_RT { get; set; }

        [Display(Name = "SBC_RT")]
        public decimal SBC_RT { get; set; }

        [Display(Name = "STD_PCHPRC")]
        public decimal STD_PCHPRC { get; set; }

        [Display(Name = "STD_SALPRC")]
        public decimal STD_SALPRC { get; set; }

        [Display(Name = "STD_SALEXP")]
        public decimal STD_SALEXP { get; set; }

        [Display(Name = "SAL_PRC")]
        public decimal SAL_PRC { get; set; }

        [Display(Name = "C_TAX")]
        public String C_TAX { get; set; }

        [Display(Name = "PACK_NO")]
        public String PACK_NO { get; set; }

        [Display(Name = "C_CTL")]
        public String C_CTL { get; set; }

        [Display(Name = "C_INV")]
        public String C_INV { get; set; }

        [Display(Name = "ITEM_DSCP")]
        public string ITEM_DSCP { get; set; }

        [Display(Name = "ITEM_DSCP1")]
        public string ITEM_DSCP1 { get; set; }

        [Display(Name = "ITEM_DSCP2")]
        public string ITEM_DSCP2 { get; set; }

        [Display(Name = "ITEM_DSCP3")]
        public string ITEM_DSCP3 { get; set; }

        [Display(Name = "REMK")]
        public string REMK { get; set; }

        [Display(Name = "IMG_NO")]
        public String IMG_NO { get; set; }

        [Display(Name = "IMG_NO1")]
        public String IMG_NO1 { get; set; }

        [Display(Name = "IMG_NO2")]
        public String IMG_NO2 { get; set; }

        [Display(Name = "IMG_NO3")]
        public String IMG_NO3 { get; set; }

        [Display(Name = "RT_ITEM_NO")]
        public String RT_ITEM_NO { get; set; }

        [Display(Name = "RT_NO")]
        public String RT_NO { get; set; }

        [Display(Name = "DOC_NO")]
        public String DOC_NO { get; set; }

        [Display(Name = "BAR_CODE")]
        public String BAR_CODE { get; set; }

        [Display(Name = "EFF_DT")]
        public DateTime EFF_DT { get; set; }

        [Display(Name = "EXP_DT")]
        public DateTime EXP_DT { get; set; }

        [Display(Name = "C_MPS")]
        public String C_MPS { get; set; }

        [Display(Name = "C_OUT")]
        public String C_OUT { get; set; }

        [Display(Name = "OUT_RT")]
        public decimal OUT_RT { get; set; }

        [Display(Name = "C_OVR")]
        public String C_OVR { get; set; }

        [Display(Name = "OVR_RT")]
        public decimal OVR_RT { get; set; }

        [Display(Name = "QM_NO")]
        public String QM_NO { get; set; }

        [Display(Name = "PINE_DAY")]
        public int PINE_DAY { get; set; }

        [Display(Name = "PURE_DAY")]
        public int PURE_DAY { get; set; }

        [Display(Name = "GD_NO")]
        public String GD_NO { get; set; }

        [Display(Name = "SIZE")]
        public String SIZE { get; set; }

        [Display(Name = "CTS_RT")]
        public decimal CTS_RT { get; set; }

        [Display(Name = "PO_TY")]
        public String PO_TY { get; set; }

        [Display(Name = "MO_TY")]
        public String MO_TY { get; set; }

        [Display(Name = "C_COST")]
        public String C_COST { get; set; }

        [Display(Name = "OWNER_USR_NO")]
        public String OWNER_USR_NO { get; set; }

        [Display(Name = "OWNER_GRP_NO")]
        public String OWNER_GRP_NO { get; set; }

        [Display(Name = "ADD_DT")]
        public DateTime ADD_DT { get; set; }

        [Display(Name = "MDY_USR_NO")]
        public String MDY_USR_NO { get; set; }

        [Display(Name = "MDY_DT")]
        public DateTime MDY_DT { get; set; }

        [Display(Name = "IP_NM")]
        public String IP_NM { get; set; }

        [Display(Name = "CP_NM")]
        public String CP_NM { get; set; }

    }
}
