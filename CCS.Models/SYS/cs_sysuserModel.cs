
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CCS.Models.SYS
{
    public class cs_sysuserModel
    {

        [Display(Name = "Id")]
        public string Id { get; set; }


        [Display(Name = "UserName")]
        public string UserName { get; set; }


        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "TrueName")]
        public string TrueName { get; set; }

    
        [Display(Name = "Card")]
        public string Card { get; set; }


        [Display(Name = "身份證")]
        public string MobileNumber { get; set; }


        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }


        [Display(Name = "QQ")]
        public string QQ { get; set; }


        [Display(Name = "EmailAddress")]
        public string EmailAddress { get; set; }

  
        [Display(Name = "OtherContact")]
        public string OtherContact { get; set; }


        [Display(Name = "Province")]
        public string Province { get; set; }

  
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Village")]
        public string Village { get; set; }


        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "State")]
        public bool State { get; set; }

        [Display(Name = "CreateTime")]
        //public string CreateTime { get; set; }
        public DateTime CreateTime { get; set; }


        [Display(Name = "CreatePerson")]
        public string CreatePerson { get; set; }


        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Display(Name = "JoinDate")]
        public DateTime JoinDate { get; set; }


        [Display(Name = "婚姻")]
        public string Marital { get; set; }

        [Display(Name = "黨派")]
        public string Political { get; set; }


        [Display(Name = "民族")]
        public string Nationality { get; set; }

        [Display(Name = "籍貫")]
        public string Native { get; set; }


        [Display(Name = "畢業學校")]
        public string School { get; set; }

 
        [Display(Name = "就讀專業")]
        public string Professional { get; set; }

 
        [Display(Name = "學歷")]
        public string Degree { get; set; }


        [Display(Name = "部門")]
        public string DepId { get; set; }

  
        [Display(Name = "職位")]
        public string PosId { get; set; }


        [Display(Name = "個人簡介")]
        public string Expertise { get; set; }


        [Display(Name = "在職狀況")]
        public string JobState { get; set; }

   
        [Display(Name = "照片")]
        public string Photo { get; set; }

  
        [Display(Name = "附件")]
        public string Attach { get; set; }

    }
}