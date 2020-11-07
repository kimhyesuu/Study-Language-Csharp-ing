using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
   public class Order
   {
      public int? OrderId { get; set; }
      public int? ProductId { get; set; }
      public int? AccountId { get; set; }

      public int? Orderquantity { get; set; }
      public string Description { get; set; }
      public DateTime? CreatedDate { get; set; }
   }
}
