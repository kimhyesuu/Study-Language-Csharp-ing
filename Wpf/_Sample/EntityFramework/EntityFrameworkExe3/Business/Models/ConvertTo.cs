using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Models
{
   public static class ConvertTo
   {
      public static IEnumerable<AccountInfo> ClientAccounts(IEnumerable<DAccountInfo> accounts)
      {
         var clientModel = new List<AccountInfo>();
         if (accounts is null) return null;

         //model 두개를 캐스팅 할만한 기술없낭 
         foreach(var account in accounts)
         {
            clientModel.Add(new AccountInfo()
            {
               AccountId = account.AccountId,
               CompanyName = account.CompanyName,
               CompanyManager = account.CompanyManager,
               Address = account.Address,
               Description =account.Description,
               Email = account.Email,
               PhoneNumber = account.PhoneNumber,
               CreatedDate = account.CreatedDate,
               UpdateTime = account.UpdateTime              
            });
         }

         return clientModel.AsEnumerable();
      }

      // UI -> DB Model Converter
      public static DAccountInfo DomainAccount(AccountInfo account)
      {
         var domainModel = new DAccountInfo();

         if (account is null) return null;
         
         domainModel.CompanyName = account.CompanyName is null ? string.Empty : account.CompanyName;
         domainModel.CompanyManager = account.CompanyManager is null ? string.Empty : account.CompanyManager;
         domainModel.PhoneNumber = account.PhoneNumber.Replace("-", "");
         domainModel.Email = account.Email is null ? string.Empty : account.Email;
         domainModel.Address = account.Address is null ? string.Empty : account.Address;
         domainModel.Description = account.Description is null ? string.Empty : account.Description;
         domainModel.CreatedDate = account.CreatedDate is null? DateTime.Now : account.CreatedDate;
         domainModel.UpdateTime = account.UpdateTime;

         return domainModel; 
      }

      //DB -> UI
      public static AccountInfo ClientAccount(DAccountInfo account)
      {
         var clientModel = new AccountInfo();

         if (account is null) return null;

         clientModel.CompanyName = account.CompanyName is null ? string.Empty : account.CompanyName;
         clientModel.CompanyManager = account.CompanyManager is null ? string.Empty : account.CompanyManager;
         clientModel.PhoneNumber = account.PhoneNumber;
         clientModel.Email = account.Email is null ? string.Empty : account.Email;
         clientModel.Address = account.Address is null ? string.Empty : account.Address;
         clientModel.Description = account.Description is null ? string.Empty : account.Description;
         clientModel.CreatedDate = account.CreatedDate is null ? DateTime.Now : account.CreatedDate;
         clientModel.UpdateTime = account.UpdateTime;

         return clientModel;
      }  
   }
}
