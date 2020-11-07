using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
   [Table("ProductInfo")]
   public partial class DProductInfo
   {
      [Key]  
      [Column("PK_ProductId")]
      public int? ProductId { get; set; }

      [Column("ProductName")]
      public string ProductName { get; set; }
     
      [Column("Description")]
      public string Description { get; set; }

      [Column("CreatedTime")]
      public DateTime? CreatedTime { get; set; }

      [Column("UpdatedTime")]
      public DateTime UpdatedTime { get; set; }

      [ForeignKey("ProductFK")]
      public virtual ICollection<DOrder> dPOrders { get; set; }
   }
}
