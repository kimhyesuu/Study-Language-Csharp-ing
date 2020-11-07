using System;

namespace Business.Models
{
   public class ProductInfo
   {
      public int? ProductId { get; set; }
      public string ProductName { get; set; }
      public string Description { get; set; }
      public DateTime? CreatedTime { get; set; }
      public DateTime UpdatedTime { get; set; }
   }
}
