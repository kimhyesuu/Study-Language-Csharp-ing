using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
   [Table("AccountInfo")]
   public partial class DAccountInfo
   {
      [Key]
      [Column("PK_AccountId")]     
      public int? AccountId { get; set; }

      [Column("CompanyName")]
      public string CompanyName { get; set; }

      [Column("CompanyManager")]
      public string CompanyManager { get; set; }

      [Column("PhoneNumber")]
      public string PhoneNumber { get; set; }

      [Column("Email")]
      public string Email { get; set; }

      [Column("Address")]
      public string Address { get; set; }

      [Column("Description")]
      public string Description { get; set; }
      
      [Column("CreatedTime")]
      public DateTime? CreatedDate { get; set; }

      [Column("UpdateTime")]
      public DateTime? UpdateTime { get; set; }

      //널값이들어가네?
      [ForeignKey("AccountFK")]
      public virtual ICollection<DOrder> dAOrders { get; set; }
   }
}
