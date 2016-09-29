using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.SYS
{
    public class cs_sysmoduleopertaeModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }
        [Display(Name = "操作名稱")]
        public string Name { get; set; }
        [Display(Name = "操作碼")]
        public string KeyCode { get; set; }
        [Display(Name = "所屬模組")]
        public string ModuleId { get; set; }
        [Display(Name = "是否驗證")]
        public bool IsValid { get; set; }
        [Required(ErrorMessage = "{0}必須填寫")]
        [Display(Name = "排序號")]
        public int Sort { get; set; }


    }
}
