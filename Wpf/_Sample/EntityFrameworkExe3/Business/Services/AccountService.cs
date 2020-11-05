using Business.Models;
using DataAccess.UnitOfWorkss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class AccountService : IDataService<AccountInfo>
   {
      IUnitOfWork unitOfWork { get; set; }

      public AccountService()
      {
         unitOfWork = new UnitOfWork();
      }

      public IEnumerable<AccountInfo> GetAll()
      {
         //여기서 컨버터가 이루어질라나 
         // DB -> UI
         return ConvertTo.ClientAccounts(unitOfWork.Accounts.GetAll());
      }

      public AccountInfo Insert(AccountInfo parameter)
      {
         // UI -> DB
         var convert = ConvertTo.ClientAccount(unitOfWork.Accounts.Insert(ConvertTo.DomainAccount(parameter)));
         unitOfWork.Save();
         return convert;
      }

      public void Update(AccountInfo parameter)
      {
         // UI -> DB
         unitOfWork.Accounts.Update(ConvertTo.DomainAccount(parameter));
         unitOfWork.Save();
         // DB -> UI
      }

      public void Delete(AccountInfo parameter)
      {
         // UI -> DB
         unitOfWork.Accounts.Delete(ConvertTo.DomainAccount(parameter));
         unitOfWork.Save();
      }
   }
}
