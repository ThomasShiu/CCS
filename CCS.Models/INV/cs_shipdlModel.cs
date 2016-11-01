using CCS.Models.SYS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.INV
{
    public class cs_shipdlModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "出貨單號")]
        public string VCH_NO { get; set; }

        [Display(Name = "序號")]
        public int VCH_SR { get; set; }

        [Display(Name = "品號")]
        public string ITEM_NO { get; set; }

        [Display(Name = "品名")]
        public string ITEM_NM { get; set; }

        [Display(Name = "規格")]
        public string ITEM_SP { get; set; }

        [Display(Name = "材質")]
        public string RAWMTRL { get; set; }

        [Display(Name = "爐號")]
        public string HEAT_NO { get; set; }

        [Display(Name = "桶數")]
        public int KEG_CNT { get; set; }

        [Display(Name = "單重")]
        public decimal UNIT_WT { get; set; }

        [Display(Name = "淨重")]
        public decimal NET_WEIGHT { get; set; }

        [Display(Name = "毛重")]
        public decimal GROSS_WEIGHT { get; set; }

        [Display(Name = "換算支數")]
        public int COUNT_QTY { get; set; }

        [Display(Name = "單價")]
        public decimal PRC { get; set; }

        [Display(Name = "金額")]
        public decimal AMT { get; set; }

        [Display(Name = "結案")]
        public bool END_CODE { get; set; }

        [Display(Name = "客戶單號")]
        public string CS_ORDER_NO { get; set; }

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
