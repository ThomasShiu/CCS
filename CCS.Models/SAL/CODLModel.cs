using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.SAL
{
    public class CODLModel
    {
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Display(Name = "VCH_TY")]
        public string VCH_TY { get; set; }

        [Display(Name = "VCH_NO")]
        public string VCH_NO { get; set; }

        [Display(Name = "VCH_SR")]
        public int VCH_SR { get; set; }

        [Display(Name = "ITEM_NO")]
        public string ITEM_NO { get; set; }

        [Display(Name = "ITEM_NM")]
        public string ITEM_NM { get; set; }

        [Display(Name = "ITEM_SP")]
        public string ITEM_SP { get; set; }

        [Display(Name = "CS_ITEM_NO")]
        public string CS_ITEM_NO { get; set; }

        [Display(Name = "UNIT")]
        public string UNIT { get; set; }

        [Display(Name = "QTY")]
        public decimal QTY { get; set; }

        [Display(Name = "PRC")]
        public decimal PRC { get; set; }

        [Display(Name = "AMT")]
        public decimal AMT { get; set; }

        [Display(Name = "PRCV_DT")]
        public DateTime PRCV_DT { get; set; }

        [Display(Name = "RCV_QTY")]
        public decimal RCV_QTY { get; set; }

        [Display(Name = "CO_WAHO_NO")]
        public string CO_WAHO_NO { get; set; }

        [Display(Name = "WAHO_NM")]
        public string WAHO_NM { get; set; }

        [Display(Name = "C_OUT")]
        public string C_OUT { get; set; }

        [Display(Name = "OUT_RT")]
        public decimal OUT_RT { get; set; }

        [Display(Name = "C_CLS")]
        public string C_CLS { get; set; }

        [Display(Name = "REMK")]
        public string REMK { get; set; }

        [Display(Name = "CS_NO")]
        public string CS_NO { get; set; }

        [Display(Name = "C_CFM")]
        public string C_CFM { get; set; }
    }
}
