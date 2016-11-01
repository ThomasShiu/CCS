using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.SAL
{
    public class COMTModel
    {
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Display(Name = "VCH_TY")]
        public string VCH_TY { get; set; }

        [Display(Name = "VCH_NO")]
        public string VCH_NO { get; set; }

        [Display(Name = "VCH_DT")]
        public DateTime VCH_DT { get; set; }

        [Display(Name = "CS_NO")]
        public string CS_NO { get; set; }

        [Display(Name = "FULL_NM")]
        public string FULL_NM { get; set; }

        [Display(Name = "DEPM_NO")]
        public string DEPM_NO { get; set; }

        [Display(Name = "DEPM_NM")]
        public string DEPM_NM { get; set; }

        [Display(Name = "EMP_NO")]
        public string EMP_NO { get; set; }

        [Display(Name = "EMP_NM")]
        public string EMP_NM { get; set; }

        [Display(Name = "TAX_TY")]
        public string TAX_TY { get; set; }

        [Display(Name = "TAX_RT")]
        public decimal TAX_RT { get; set; }

        [Display(Name = "PAY_CDT")]
        public string PAY_CDT { get; set; }

        [Display(Name = "PAY_CDT_NM")]
        public string PAY_CDT_NM { get; set; }

        [Display(Name = "CS_VCH_NO")]
        public string CS_VCH_NO { get; set; }

        [Display(Name = "CONTACTER")]
        public string CONTACTER { get; set; }

        [Display(Name = "TO_ADDR")]
        public string TO_ADDR { get; set; }

        [Display(Name = "CURRENCY")]
        public string CURRENCY { get; set; }

        [Display(Name = "EXCH_RATE")]
        public decimal EXCH_RATE { get; set; }

        [Display(Name = "WAHO_NO")]
        public string WAHO_NO { get; set; }

        [Display(Name = "WAHO_NM")]
        public string WAHO_NM { get; set; }

        [Display(Name = "AMT")]
        public decimal AMT { get; set; }

        [Display(Name = "TAX")]
        public decimal TAX { get; set; }

        [Display(Name = "QTY")]
        public decimal QTY { get; set; }

        [Display(Name = "N_PRT")]
        public int N_PRT { get; set; }

        [Display(Name = "C_SIGN")]
        public string C_SIGN { get; set; }

        [Display(Name = "C_CFM")]
        public string C_CFM { get; set; }

        [Display(Name = "CFM_DT")]
        public DateTime CFM_DT { get; set; }


    }
}
