using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.WIR
{
    public class cs_wires_journalModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "WIRE_ID")]
        public string WIRE_ID { get; set; }

        [Display(Name = "異動碼 I:進貨  O:使用 R:損耗")]
        public string TRANS_CODE { get; set; }

        [Display(Name = "TRANS_DATE")]
        public DateTime TRANS_DATE { get; set; }

        [Display(Name = "WEIGHT")]
        public int WEIGHT { get; set; }


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
