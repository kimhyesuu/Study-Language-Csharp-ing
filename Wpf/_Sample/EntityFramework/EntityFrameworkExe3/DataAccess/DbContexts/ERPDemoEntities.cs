using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DataAccess.Models;

namespace DataAccess.DbContexts
{
   public class ERPDemoEntities : DbContext
   {
      public ERPDemoEntities() : base("name=ERPDemoEntities")
      {
         //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ERPDemoEntities>());
      }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        // base.OnModelCreating(modelBuilder);
         //modelBuilder.HasDefaultSchema("dbo");

         //modelBuilder.Configurations.Add(new AccountConfigure());
         //modelBuilder.Configurations.Add(new ProductConfigure());
         //modelBuilder.Configurations.Add(new OrderConfigure());
      }

      public DbSet<DAccountInfo> dAccountInfo { get; set; }

      public DbSet<DOrder> dOrder { get; set; }

      public DbSet<DProductInfo> dProductInfo { get; set; }
   }
}
