using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.SYS
{
    public class cs_sysroleModel
    {
        public string Id { get; set; }

        [Display(Name = "角色名稱")]
        public string Name { get; set; }

        [Display(Name = "說明")]
        public string Description { get; set; }
        [Display(Name = "創建時間")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "創建人")]
        public string CreatePerson { get; set; }
        [Display(Name = "擁有的用戶")]
        public string UserName { get; set; }//擁有的用戶

        public string Flag { get; set; }//用戶分配角色

    }
}
