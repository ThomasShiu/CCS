//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CS_SHIPDL
    {
        public string Id { get; set; }
        public string VCH_NO { get; set; }
        public int VCH_SR { get; set; }
        public string ITEM_NO { get; set; }
        public string ITEM_NM { get; set; }
        public string ITEM_SP { get; set; }
        public string RAWMTRL { get; set; }
        public string HEAT_NO { get; set; }
        public Nullable<int> KEG_CNT { get; set; }
        public Nullable<decimal> UNIT_WT { get; set; }
        public Nullable<decimal> NET_WEIGHT { get; set; }
        public Nullable<decimal> GROSS_WEIGHT { get; set; }
        public Nullable<int> COUNT_QTY { get; set; }
        public Nullable<decimal> PRC { get; set; }
        public Nullable<decimal> AMT { get; set; }
        public bool END_CODE { get; set; }
        public string REMK { get; set; }
        public string EXC_INSDBID { get; set; }
        public Nullable<System.DateTime> EXC_INSDATE { get; set; }
        public string EXC_UPDDBID { get; set; }
        public Nullable<System.DateTime> EXC_UPDDATE { get; set; }
        public string EXC_SYSOWNR { get; set; }
        public string EXC_ISLOCKED { get; set; }
        public string EXC_COMPANY { get; set; }
        public string STATUS { get; set; }
        public string CS_ORDER_NO { get; set; }
    }
}