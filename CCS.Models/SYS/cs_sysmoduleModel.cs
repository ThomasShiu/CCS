using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.SYS
{
    public class cs_sysmoduleModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }
        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Display(Name = "別名")]
        public string EnglishName { get; set; }
        [Display(Name = "上級ID")]
        public string ParentId { get; set; }
        [Display(Name = "連結")]
        public string Url { get; set; }
        [Display(Name = "圖示")]
        public string Iconic { get; set; }
        [Display(Name = "排序號")]
        public int? Sort { get; set; }
        [Display(Name = "說明")]
        public string Remark { get; set; }
        [Display(Name = "狀態")]
        public bool Enable { get; set; }
        [Display(Name = "創建人")]
        public string CreatePerson { get; set; }
        [Display(Name = "創建時間")]
        public DateTime? CreateTime { get; set; }
        [Display(Name = "是否最後一項")]
        public bool IsLast { get; set; }

        public string state { get; set; }//treegrid


    }
}
