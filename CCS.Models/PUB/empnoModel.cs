using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Models.PUB
{
    public class empnoModel
    {
        [Display(Name = "員工編號")]
        public string EMP_NO { get; set; }

        [Display(Name = "姓名")]
        public string EMP_NM { get; set; }

        [Display(Name = "部門編號")]
        public string DEPM_NO { get; set; }

        [Display(Name = "電話")]
        public string TEL_NO { get; set; }

        [Display(Name = "TEL_NO2")]
        public string TEL_NO2 { get; set; }

        [Display(Name = "E_MAIL")]
        public string E_MAIL { get; set; }

        [Display(Name = "C_INV")]
        public string C_INV { get; set; }

        [Display(Name = "C_PUR")]
        public string C_PUR { get; set; }

        [Display(Name = "C_COP")]
        public string C_COP { get; set; }

        [Display(Name = "C_PPS")]
        public string C_PPS { get; set; }

        [Display(Name = "C_AST")]
        public string C_AST { get; set; }

        [Display(Name = "C_ACT")]
        public string C_ACT { get; set; }

        [Display(Name = "C_SFC")]
        public string C_SFC { get; set; }

        [Display(Name = "C_QMS")]
        public string C_QMS { get; set; }

        [Display(Name = "C_BOM")]
        public string C_BOM { get; set; }

        [Display(Name = "C_MOC")]
        public string C_MOC { get; set; }
    }
}
