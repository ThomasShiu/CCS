﻿using System;
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
        public DateTime VCH_DT { get; set; }


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


        [Display(Name = "鍍別")]
        public string PLATING { get; set; }


        [Display(Name = "製程代號")]
        public string PRCS_NO { get; set; }

        [Display(Name = "預計開工")]
        public DateTime PLAN_BDT { get; set; }

        [Display(Name = "預計完工")]
        public DateTime PLAN_EDT { get; set; }

        [Display(Name = "預計產量")]
        public int PLAN_QTY { get; set; }

        [Display(Name = "備註")]
        public string REMK { get; set; }


        [Display(Name = "OWNER_USR_NO")]
        public string OWNER_USR_NO { get; set; }


        [Display(Name = "OWNER_GRP_NO")]
        public string OWNER_GRP_NO { get; set; }

        [Display(Name = "ADD_DT")]
        public DateTime ADD_DT { get; set; }


        [Display(Name = "CFM_USR_NO")]
        public string CFM_USR_NO { get; set; }


        [Display(Name = "MDY_USR_NO")]
        public string MDY_USR_NO { get; set; }

        [Display(Name = "MDY_DT")]
        public DateTime MDY_DT { get; set; }


        [Display(Name = "IP_NM")]
        public string IP_NM { get; set; }


        [Display(Name = "CP_NM")]
        public string CP_NM { get; set; }
    }
}
