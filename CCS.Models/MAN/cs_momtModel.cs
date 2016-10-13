using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.MAN
{
    public class cs_momtModel
    {

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "工令單號")]
        public string VCH_NO { get; set; }

        
        [Display(Name = "工令日期")]
        [Required(ErrorMessage = "工令日期 欄位是必要項")]
        public DateTime VCH_DT { get; set; }

        [Display(Name = "EMP_NO")]
        public string EMP_NO { get; set; }

        [Display(Name = "EMP_NM")]
        public string EMP_NM { get; set; }

        [Display(Name = "廠別")]
        public string FA_NO { get; set; }

        [Display(Name = "訂單號")]
        public string CO_NO { get; set; }

        [Display(Name = "訂單序號")]
        public int CO_SR { get; set; }

        [Display(Name = "品號")]
        public string ITEM_NO { get; set; }


        [Display(Name = "圖號")]
        public string IMG_NO { get; set; }


        [Display(Name = "頭部記號")]
        public string HEAD_MARK { get; set; }


        [Display(Name = "線材材質")]
        public string RAWMTRL { get; set; }

        [Display(Name = "使用線徑")]
        public decimal DIAMETER { get; set; }

        [Display(Name = "爐號")]
        public string HEAT_NO { get; set; }

        [Display(Name = "鍍別")]
        public string PLATING { get; set; }


        [Display(Name = "製程代號")]
        [Required(ErrorMessage = "製程代號 欄位是必要項")]
        public string PRCS_NO { get; set; }

        [Display(Name = "預計開工")]
        [Required(ErrorMessage = "預計開工 欄位是必要項")]
        public DateTime PLAN_BDT { get; set; }

        [Display(Name = "預計完工")]
        [Required(ErrorMessage = "預計完工 欄位是必要項")]
        public DateTime PLAN_EDT { get; set; }

        [Display(Name = "預計產量")]
        public int PLAN_QTY { get; set; }

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
    }
}
