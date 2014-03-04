using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class MarketContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<VacuumCleaner> VacuumCleaners { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        } 

    }
    public class SimpleFileView
    {
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}