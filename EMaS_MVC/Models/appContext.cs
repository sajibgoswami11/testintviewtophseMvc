using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;

namespace EMaS_MVC.Models
{
    public partial class appContext: DbContext
    {
        public readonly static string _Connection = "Data Source='" + Path.Combine(Directory.GetCurrentDirectory(), @"app.db") + "' ";
        
        public appContext(): base("DefaultConnection")
        {
            Database.SetInitializer<appContext>(null);
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("ERP_CM_SYSTEM_USERS");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}