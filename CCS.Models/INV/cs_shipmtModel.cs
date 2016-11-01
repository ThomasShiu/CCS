using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.INV
{
    public class cs_shipmtModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "出貨單號")]
        public string VCH_NO { get; set; }

        [Display(Name = "出貨日期")]
        public DateTime VCH_DT { get; set; }

        [Display(Name = "客戶編號")]
        public string CS_NO { get; set; }

        [Display(Name = "客戶名稱")]
        public string CS_NM { get; set; }

        [Display(Name = "送貨地址")]
        public string TO_ADDR { get; set; }

        [Display(Name = "聯絡方式")]
        public string CONTACT { get; set; }

        [Display(Name = "結案")]
        public bool END_CODE { get; set; }

        [Display(Name = "備註")]
        public string REMK { get; set; }

        [Display(Name = "EXC_INSDBID")]
        public string EXC_INSDBID { get; set; }

        [Display(Name = "EXC_INSDATE")]
        public DateTime EXC_INSDATE { get; set; }

        [Display(Name = "EXC_UPDDBID")]
        public string EXC_UPDDBID { get; set; }

        [Display(Name = "EXC_UPDDATE")]
        public DateTime EXC_UPDDATE { get; set; }

        [Display(Name = "EXC_SYSOWNR")]
        public string EXC_SYSOWNR { get; set; }

        [Display(Name = "EXC_ISLOCKED")]
        public string EXC_ISLOCKED { get; set; }

        [Display(Name = "EXC_COMPANY")]
        public string EXC_COMPANY { get; set; }

        [Display(Name = "STATUS")]
        public string STATUS { get; set; }
    }
}
