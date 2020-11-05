using DataAccess.Models;
using System.Data.Entity.ModelConfiguration;

//사용안함
namespace DataAccess.DbContexts
{
   public class AccountConfigure : EntityTypeConfiguration<DAccountInfo>
   {
      
      public AccountConfigure()
      {         
         HasKey(account => account.AccountId);
         Property(account => account.CompanyName).IsOptional().HasMaxLength(20);
         Property(account => account.CompanyManager).IsOptional().HasMaxLength(15);
         Property(account => account.PhoneNumber).IsOptional().HasMaxLength(15);
         Property(account => account.Email).IsOptional().HasMaxLength(100);
         Property(account => account.Address).IsOptional().HasMaxLength(100);
         Property(account => account.Description).IsOptional().HasMaxLength(800);
         Property(account => account.CreatedDate).IsOptional();
         Property(account => account.UpdateTime).IsOptional();

         ToTable("AccountInfo");
      }
   }

   public class ProductConfigure : EntityTypeConfiguration<DProductInfo>
   {
      public ProductConfigure()
      {
         HasKey(product => product.ProductId);
         Property(product => product.ProductName).IsRequired().HasMaxLength(30);
         Property(product => product.Description).IsOptional().HasMaxLength(800);
         Property(product => product.CreatedTime).IsOptional();
         Property(product => product.UpdatedTime).IsOptional();
         ToTable("ProductInfo");
      }
   }

   public class OrderConfigure : EntityTypeConfiguration<DOrder>
   {
      public OrderConfigure()
      {
         HasKey(order => order.OrderId);
         Property(order => order.Orderquantity).IsOptional();
         Property(order => order.Description).IsOptional().HasMaxLength(800);
         Property(order => order.Orderquantity).IsOptional();
         Property(order => order.CreatedDate).IsOptional();

       //  HasRequired(x => x.DAccountInfo).WithMany(y => y.dAOrders).HasForeignKey(f=> f.AccountFK);
//HasRequired(x => x.DProductInfo).WithMany(y => y.dPOrders).HasForeignKey(f => f.ProductFK);

         ToTable("Order");
      }
   }

}
