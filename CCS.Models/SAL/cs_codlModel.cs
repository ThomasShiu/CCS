using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.SAL
{
    public class cs_codlModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "訂單號碼")]
        public string VCH_NO { get; set; }

        [Display(Name = "序號")]
        public int VCH_SR { get; set; }

        [Display(Name = "品號")]
        public string ITEM_NO { get; set; }

        [Display(Name = "品名")]
        public string ITEM_NM { get; set; }

        [Display(Name = "規格")]
        public string ITEM_SP { get; set; }

        [Display(Name = "客戶品號")]
        public string CS_ITEM_NO { get; set; }

        [Display(Name = "單位")]
        public string UNIT { get; set; }

        [Display(Name = "數量")]
        public decimal QTY { get; set; }

        [Display(Name = "A_QTY")]
        public decimal A_QTY { get; set; }

        [Display(Name = "RCV_QTY")]
        public decimal RCV_QTY { get; set; }

        [Display(Name = "RTN_QTY")]
        public decimal RTN_QTY { get; set; }

        [Display(Name = "FREE_QTY")]
        public decimal FREE_QTY { get; set; }

        [Display(Name = "FREC_QTY")]
        public decimal FREC_QTY { get; set; }

        [Display(Name = "單價")]
        public decimal PRC { get; set; }

        [Display(Name = "金額")]
        public decimal AMT { get; set; }

        [Display(Name = "預交日期")]
        public System.DateTime PRCV_DT { get; set; }

        [Display(Name = "CO_WAHO_NO")]
        public string CO_WAHO_NO { get; set; }

        [Display(Name = "SVCH_TY")]
        public string SVCH_TY { get; set; }

        [Display(Name = "SVCH_NO")]
        public string SVCH_NO { get; set; }

        [Display(Name = "SVCH_SR")]
        public int SVCH_SR { get; set; }

        [Display(Name = "PRJ_NO")]
        public string PRJ_NO { get; set; }

        [Display(Name = "C_OUT")]
        public string C_OUT { get; set; }

        [Display(Name = "OUT_RT")]
        public decimal OUT_RT { get; set; }

        [Display(Name = "結案碼")]
        public string C_CLS { get; set; }

        [Display(Name = "備註")]
        public string REMK { get; set; }

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
