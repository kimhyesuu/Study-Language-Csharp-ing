namespace Business.Models
{
   using System;

   public class AccountInfo
   {
      public int? AccountId { get; set; }
      public string CompanyName { get; set; }
      public string CompanyManager { get; set; }
      public string PhoneNumber { get; set; }
      public string Email { get; set; }
      public string Address { get; set; }
      public string Description { get; set; }
      public DateTime? CreatedDate { get; set; }
      public DateTime? UpdateTime { get; set; }     
   }
}
