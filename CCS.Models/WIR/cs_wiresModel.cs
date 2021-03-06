﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.WIR
{
    public class cs_wiresModel
    {

        [Display(Name = "Id")]
        public string Id { get; set; }
 
        [Display(Name = "卷號")]
        public string WIRE_ID { get; set; }

        [Display(Name = "客戶卷號")]
        public string CS_WIRE_ID { get; set; }

        [Display(Name = "入庫日期")]
        public DateTime STOCK_DATE { get; set; }

        [Display(Name = "材質")]
        public string RAWMTRL { get; set; }

        [Display(Name = "線徑")]
        public decimal DIAMETER { get; set; }

        [Display(Name = "原線徑")]
        public Nullable<decimal> ORG_DIAMETER { get; set; }

        [Display(Name = "爐號")]
        public string HEAT_NO { get; set; }

        [Display(Name = "線重")]
        public int WEIGHT { get; set; }

        [Display(Name = "線架重")]
        public Nullable<int> STAND_WEIGTH { get; set; }

        [Display(Name = "球化料")]
        public bool ANNEAL { get; set; }

   
        [Display(Name = "廠牌")]
        public string MARK { get; set; }

    
        [Display(Name = "廠牌名稱")]
        public string MARK_NM { get; set; }


        [Display(Name = "加工廠")]
        public string PROCESS_FACTORY { get; set; }

        [Display(Name = "原料種類")]
        public Nullable<int> TYPE { get; set; }

  
        [Display(Name = "原料種類")]
        public string TYPE_NM { get; set; }

        [Display(Name = "歸屬客戶")]
        public string CS_NO { get; set; }

        [Display(Name = "客戶名稱")]
        public string CS_NM { get; set; }

        [Display(Name = "備註")]
        public string REMARK { get; set; }

        [Display(Name = "結案碼")]
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
