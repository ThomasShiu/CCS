using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CCS.Models.SAL
{
    public class cs_comtModel
    {

        [Display(Name = "訂單號碼")]
        public string VCH_NO { get; set; }

        [Display(Name = "訂單日期")]
        public DateTime VCH_DT { get; set; }

        [Display(Name = "廠區")]
        public string FA_NO { get; set; }

        [Display(Name = "客戶編號")]
        public string CS_NO { get; set; }

        [Display(Name = "客戶名稱")]
        public string CS_NM { get; set; }

        [Display(Name = "接單部門")]
        public string DEPM_NO { get; set; }

        [Display(Name = "業務代號")]
        public string EMP_NO { get; set; }

        [Display(Name = "業務人員")]
        public string EMP_NAME { get; set; }

        [Display(Name = "客戶單號")]
        public string CS_VCH_NO { get; set; }

        [Display(Name = "連絡人")]
        public string CONTACTER { get; set; }

        [Display(Name = "課稅別")]
        public string TAX_TY { get; set; }

        [Display(Name = "稅率")]
        public decimal TAX_RT { get; set; }

        [Display(Name = "PRC_CDT")]
        public string PRC_CDT { get; set; }

        [Display(Name = "付款條件")]
        public string PAY_CDT { get; set; }

        [Display(Name = "送貨地址")]
        public string TO_ADDR { get; set; }

        [Display(Name = "TO_ADDR2")]
        public string TO_ADDR2 { get; set; }

        [Display(Name = "電話")]
        public string TEL_NO { get; set; }

        [Display(Name = "傳真")]
        public string FAX_NO { get; set; }
        [Display(Name = "幣別")]
        public string CURRENCY { get; set; }

        [Display(Name = "匯率")]
        public decimal EXCH_RATE { get; set; }

        [Display(Name = "出貨倉別")]
        public string WAHO_NO { get; set; }

        [Display(Name = "LC_NO")]
        public string LC_NO { get; set; }

        [Display(Name = "運輸方式")]
        public string SHIP_TY { get; set; }

        [Display(Name = "STR_PORT")]
        public string STR_PORT { get; set; }

        [Display(Name = "DES_PORT")]
        public string DES_PORT { get; set; }

        [Display(Name = "AGT_CORP")]
        public string AGT_CORP { get; set; }

        [Display(Name = "CLR_CORP")]
        public string CLR_CORP { get; set; }

        [Display(Name = "INSP_CORP")]
        public string INSP_CORP { get; set; }

        [Display(Name = "運輸公司")]
        public string SHIP_CORP { get; set; }

        [Display(Name = "MARK_NO")]
        public string MARK_NO { get; set; }

        [Display(Name = "FL_MARK")]
        public string FL_MARK { get; set; }

        [Display(Name = "SL_MARK")]
        public string SL_MARK { get; set; }

        [Display(Name = "CONSIGNEE")]
        public string CONSIGNEE { get; set; }

        [Display(Name = "NOTIFY")]
        public string NOTIFY { get; set; }

        [Display(Name = "DES_PLACE")]
        public string DES_PLACE { get; set; }

        [Display(Name = "BANK_NO")]
        public string BANK_NO { get; set; }

        [Display(Name = "PACK_REMK")]
        public string PACK_REMK { get; set; }

        [Display(Name = "IVC_REMK")]
        public string IVC_REMK { get; set; }

        [Display(Name = "備註")]
        public string REMK { get; set; }

        [Display(Name = "ATTR_NO1")]
        public string ATTR_NO1 { get; set; }

        [Display(Name = "ATTR_NO2")]
        public string ATTR_NO2 { get; set; }

        [Display(Name = "ATTR_NO3")]
        public string ATTR_NO3 { get; set; }

        [Display(Name = "N_PRT")]
        public int N_PRT { get; set; }

        [Display(Name = "C_SIGN")]
        public string C_SIGN { get; set; }

        [Display(Name = "C_CFM")]
        public string C_CFM { get; set; }

        [Display(Name = "CFM_DT")]
        public DateTime CFM_DT { get; set; }

        [Display(Name = "聯絡人")]
        public string OWNER_USR_NO { get; set; }

        [Display(Name = "OWNER_GRP_NO")]
        public string OWNER_GRP_NO { get; set; }

        [Display(Name = "ADD_DT")]
        public DateTime ADD_DT { get; set; }

        [Display(Name = "CFM_USR_NO")]
        public string CFM_USR_NO { get; set; }

        [Display(Name = "MDY_USR_NO")]
        public string MDY_USR_NO { get; set; }

        [Display(Name = "MDY_DT")]
        public DateTime MDY_DT { get; set; }

        
        [Display(Name = "IP_NM")]
        public string IP_NM { get; set; }

        [Display(Name = "CP_NM")]
        public string CP_NM { get; set; }
    }
}
