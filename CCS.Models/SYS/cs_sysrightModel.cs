using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.SYS
{
    public class cs_sysrightModel
    {

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "模組Id")]
        public string ModuleId { get; set; }

        [Display(Name = "角色Id")]
        public string RoleId { get; set; }

        [Display(Name = "授權")]
        public bool Rightflag { get; set; }
    }
}
