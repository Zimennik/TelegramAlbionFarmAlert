﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelegramAlbionFarmAlert.Db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AppDataEntities : DbContext
    {
        public AppDataEntities()
            : base("name=AppDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Culture> Culture { get; set; }
        public virtual DbSet<Timer> Timer { get; set; }
        public virtual DbSet<UserSubscription> UserSubscription { get; set; }
        public virtual DbSet<Island> Island { get; set; }
    }
}
