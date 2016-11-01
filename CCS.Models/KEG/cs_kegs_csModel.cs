using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.KEG
{
    public class cs_kegs_csModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "客戶")]
        public string CS_NO { get; set; }

        [Display(Name = "客戶名稱")]
        public string CS_NM { get; set; }

        [Display(Name = "鐵桶類型")]
        public string KEG_NM { get; set; }

        [Display(Name = "異動日期")]
        public DateTime TRANS_DATE { get; set; }

        [Display(Name = "異動碼")]
        public string TRANS_CODE { get; set; }

        [Display(Name = "數量")]
        public int CNT { get; set; }

        [Display(Name = "備註")]
        public string REMARK { get; set; }

        [Display(Name = "C_CLS")]
        public string C_CLS { get; set; }

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
    }
}
