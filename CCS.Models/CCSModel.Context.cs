﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CCSEntities : DbContext
    {
        public CCSEntities()
            : base("name=CCSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CS_COMT> CS_COMT { get; set; }
        public virtual DbSet<CS_SYSMODULE> CS_SYSMODULE { get; set; }
        public virtual DbSet<CS_SYSLOG> CS_SYSLOG { get; set; }
        public virtual DbSet<CS_SYSEXCEPTION> CS_SYSEXCEPTION { get; set; }
        public virtual DbSet<CS_ACTIONLOG> CS_ACTIONLOG { get; set; }
    }
}
