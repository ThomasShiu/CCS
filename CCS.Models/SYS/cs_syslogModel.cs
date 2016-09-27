using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.SYS
{
    public class cs_syslogModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "操作人員")]
        public string Operator { get; set; }

        [Display(Name = "訊息")]
        public string Message { get; set; }

        [Display(Name = "結果")]
        public string Result { get; set; }

        [Display(Name = "類型")]
        public string Type { get; set; }

        [Display(Name = "模組")]
        public string Module { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }
    }
}
