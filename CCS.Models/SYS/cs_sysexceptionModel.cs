using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.SYS
{
    public class cs_sysexceptionModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "幫助連結")]
        public string HelpLink { get; set; }

        [Display(Name = "錯誤訊息")]
        public string Message { get; set; }

        [Display(Name = "來源")]
        public string Source { get; set; }

        [Display(Name = "追蹤")]
        public string StackTrace { get; set; }

        [Display(Name = "目標頁")]
        public string TargetSite { get; set; }

        [Display(Name = "程序集")]
        public string Data { get; set; }

        [Display(Name = "發生時間")]
        public DateTime? CreateTime { get; set; }
    }
}
