using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.MAN
{
   public  class cs_processSetModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "製程組合")]
        public string P_SET { get; set; }

        [Display(Name = "名稱")]
        public string P_SET_NM { get; set; }
    }
}
