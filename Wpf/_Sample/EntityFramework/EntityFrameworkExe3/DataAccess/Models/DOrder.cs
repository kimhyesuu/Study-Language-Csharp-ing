using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
   [Table("Order")]
   public partial class DOrder
   {
      [Key]
      [Column("PK_OrderId")]
      public int? OrderId { get; set; }  

      [Column("OrderQuantity")]
      public int? Orderquantity { get; set; }

      [Column("Description")]
      public string Description { get; set; }

      [Column("CreatedDate")]
      public DateTime? CreatedDate { get; set; }

      public int AccountFK { get; set; }   
      public DAccountInfo DAccountInfo { get; set; }

      public int ProductFK { get; set; }
      public virtual DProductInfo DProductInfo { get; set; }    
   }
}
