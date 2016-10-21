using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.WIR
{
    public class cs_wire_reciptModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }


        [Display(Name = "製令單號")]
        public string MO_VCH_NO { get; set; }

        [Display(Name = "品號")]
        public string ITEM_NO { get; set; }

        [Display(Name = "品名")]
        public string ITEM_NM { get; set; }

        [Display(Name = "線材卷號")]
        public string WIRE_ID { get; set; }

        [Display(Name = "材質")]
        public string RAWMTRL { get; set; }

        [Display(Name = "線徑")]
        public decimal DIAMETER { get; set; }

        [Display(Name = "爐號")]
        public string HEAT_NO { get; set; }


        [Display(Name = "領用日期")]
        public DateTime REC_DATE { get; set; }


        [Display(Name = "領用人員")]
        public string REC_EMP { get; set; }

        [Display(Name = "領用重量")]
        [Required(ErrorMessage ="請輸入領用重量")]
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
