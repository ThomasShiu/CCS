using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.INV
{
    public class cs_itemstkModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "品號")]
        public string ITEM_NO { get; set; }

        [Display(Name = "倉庫別")]
        public string WAHO_NO { get; set; }

        [Display(Name = "批號")]
        public string LOT_NO { get; set; }

        [Display(Name = "控制碼")]
        public string CTRL_NO { get; set; }

        [Display(Name = "桶號")]
        public string KEG_NO { get; set; }

        [Display(Name = "EMP_NO")]
        public string EMP_NO { get; set; }

        [Display(Name = "EMP_NM")]
        public string EMP_NM { get; set; }

        [Display(Name = "重量")]
        public int WEIGHT { get; set; }

        [Display(Name = "單位重")]
        public decimal UNIT_WT { get; set; }

        [Display(Name = "換算支數")]
        public int COUNT_QTY { get; set; }

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

        [Display(Name = "狀態 I:入庫 O:出貨")]
        public string STATUS { get; set; }
    }
}
