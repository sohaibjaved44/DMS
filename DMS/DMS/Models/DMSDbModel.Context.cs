﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DMSDbEntities : DbContext
    {
        public DMSDbEntities()
            : base("name=DMSDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CTGRY_TBL> CTGRY_TBL { get; set; }
        public virtual DbSet<DCMNT_TBL> DCMNT_TBL { get; set; }
        public virtual DbSet<DEPT_TBL> DEPT_TBL { get; set; }
        public virtual DbSet<PYMT_TBL> PYMT_TBL { get; set; }
        public virtual DbSet<ROLE_TBL> ROLE_TBL { get; set; }
        public virtual DbSet<USER_TBL> USER_TBL { get; set; }
        public virtual DbSet<STRG_LOC_TBL> STRG_LOC_TBL { get; set; }
        public virtual DbSet<PLAN_TBL> PLAN_TBL { get; set; }
        public virtual DbSet<PLCY_TBL> PLCY_TBL { get; set; }
        public virtual DbSet<PRDCT_TYPE> PRDCT_TYPE { get; set; }
        public virtual DbSet<DCMT_TYPE> DCMT_TYPE { get; set; }
        public virtual DbSet<EXTN_TBL> EXTN_TBL { get; set; }
    }
}
