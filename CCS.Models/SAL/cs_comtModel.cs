using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CCS.Models.SAL
{
    public class cs_comtModel
    {
        [Display(Name = "訂單號碼")]
        public string VCH_NO { get; set; }
        public System.DateTime VCH_DT { get; set; }
        public string FA_NO { get; set; }
        public string CS_NO { get; set; }
        public string DEPM_NO { get; set; }
        public string EMP_NO { get; set; }
        public string CS_VCH_NO { get; set; }
        public string CONTACTER { get; set; }
        public string TAX_TY { get; set; }
        public Nullable<decimal> TAX_RT { get; set; }
        public string PRC_CDT { get; set; }
        public string PAY_CDT { get; set; }
        public string TO_ADDR { get; set; }
        public string TO_ADDR2 { get; set; }
        public string CURRENCY { get; set; }
        public Nullable<decimal> EXCH_RATE { get; set; }
        public string WAHO_NO { get; set; }
        public string LC_NO { get; set; }
        public string SHIP_TY { get; set; }
        public string STR_PORT { get; set; }
        public string DES_PORT { get; set; }
        public string AGT_CORP { get; set; }
        public string CLR_CORP { get; set; }
        public string INSP_CORP { get; set; }
        public string SHIP_CORP { get; set; }
        public string MARK_NO { get; set; }
        public string FL_MARK { get; set; }
        public string SL_MARK { get; set; }
        public string CONSIGNEE { get; set; }
        public string NOTIFY { get; set; }
        public string DES_PLACE { get; set; }
        public string BANK_NO { get; set; }
        public string PACK_REMK { get; set; }
        public string IVC_REMK { get; set; }
        public string REMK { get; set; }
        public Nullable<decimal> COMS_RATE { get; set; }
        public Nullable<decimal> COMS_AMT { get; set; }
        public Nullable<decimal> DPAY_RT { get; set; }
        public Nullable<decimal> DPAY_AMT { get; set; }
        public string ATTR_NO1 { get; set; }
        public string ATTR_NO2 { get; set; }
        public string ATTR_NO3 { get; set; }
        public Nullable<decimal> TAX { get; set; }
        public Nullable<int> N_PRT { get; set; }
        public string C_SIGN { get; set; }
        public string C_CFM { get; set; }
        public Nullable<System.DateTime> CFM_DT { get; set; }
        public string ITEM_NO { get; set; }
        public string CS_ITEM_NO { get; set; }
        public string UNIT { get; set; }
        public Nullable<decimal> QTY { get; set; }
        public Nullable<decimal> A_QTY { get; set; }
        public Nullable<decimal> RCV_QTY { get; set; }
        public Nullable<decimal> RTN_QTY { get; set; }
        public Nullable<decimal> FREE_QTY { get; set; }
        public Nullable<decimal> FREC_QTY { get; set; }
        public Nullable<decimal> PRC { get; set; }
        public Nullable<decimal> AMT { get; set; }
        public string PL { get; set; }
        public Nullable<System.DateTime> PRCV_DT { get; set; }
        public string CO_WAHO_NO { get; set; }
        public string SVCH_TY { get; set; }
        public string SVCH_NO { get; set; }
        public Nullable<int> SVCH_SR { get; set; }
        public string PRJ_NO { get; set; }
        public string C_OUT { get; set; }
        public Nullable<decimal> OUT_RT { get; set; }
        public string C_CLS { get; set; }
        public string EXC_INSDBID { get; set; }
        public Nullable<System.DateTime> EXC_INSDATE { get; set; }
        public string EXC_UPDDBID { get; set; }
        public Nullable<System.DateTime> EXC_UPDDATE { get; set; }
        public string EXC_SYSOWNR { get; set; }
        public string EXC_ISLOCKED { get; set; }
    }
}
