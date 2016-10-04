
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


        [Display(Name = "帳號")]
        public string UserName { get; set; }


        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "姓名")]
        public string TrueName { get; set; }

    
        [Display(Name = "Card")]
        public string Card { get; set; }


        [Display(Name = "身份證")]
        public string MobileNumber { get; set; }


        [Display(Name = "電話")]
        public string PhoneNumber { get; set; }


        [Display(Name = "QQ")]
        public string QQ { get; set; }


        [Display(Name = "電子郵件")]
        public string EmailAddress { get; set; }

  
        [Display(Name = "其它連絡方式")]
        public string OtherContact { get; set; }


        [Display(Name = "Province")]
        public string Province { get; set; }

  
        [Display(Name = "縣市")]
        public string City { get; set; }

        [Display(Name = "Village")]
        public string Village { get; set; }


        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "狀態")]
        public bool State { get; set; }

        [Display(Name = "建立日期")]
        //public string CreateTime { get; set; }
        public DateTime CreateTime { get; set; }


        [Display(Name = "建立人員")]
        public string CreatePerson { get; set; }


        [Display(Name = "性別")]
        public string Sex { get; set; }

        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        [Display(Name = "到職日期")]
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