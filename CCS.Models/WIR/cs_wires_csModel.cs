using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.WIR
{
    public class cs_wires_csModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "材質")]
        public string RAWMTRL { get; set; }

        [Display(Name = "線徑")]
        public decimal DIAMETER { get; set; }

        [Display(Name = "原線徑")]
        public decimal ORG_DIAMETER { get; set; }

        [Display(Name = "爐號")]
        public string HEAT_NO { get; set; }

        [Display(Name = "重量")]
        public int WEIGHT { get; set; }

        [Display(Name = "線架重")]
        public int STAND_WEIGTH { get; set; }

        [Display(Name = "廠牌")]
        public string MARK_NM { get; set; }

        [Display(Name = "加工廠商")]
        public string PROCESS_FACTORY { get; set; }

        [Display(Name = "客戶編號")]
        public string CS_NO { get; set; }

        [Display(Name = "客戶名稱")]
        public string CS_NM { get; set; }

        [Display(Name = "異動日")]
        public DateTime TRANS_DATE { get; set; }

        [Display(Name = "異動碼")]
        public string TRANS_CODE { get; set; }

        [Display(Name = "備註")]
        public string REMARK { get; set; }

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
