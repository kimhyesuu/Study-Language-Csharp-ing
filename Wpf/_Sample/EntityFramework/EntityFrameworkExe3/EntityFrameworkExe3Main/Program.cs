using Business.Models;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
   public class AccountInfoViewModel
   {

      private IDataService<AccountInfo> _dataService { get; }

      public List<AccountInfo> AccountList
      {
         get;
         set;
      }

      public AccountInfo Account
      {
         get;
         set;
      }

      public AccountInfoViewModel()
      {
         _dataService = new AccountService();
         AccountList = new List<AccountInfo>();
         Account = new AccountInfo();       
      }

      public IEnumerable<AccountInfo> GetAllAccount()
      {
         return _dataService.GetAll();
      }
      //여기서 값이 안들어간다.
      public void AddAccount(AccountInfo accountInfo)
      {
         _dataService.Insert(accountInfo);
      }
   }

   public class Program
   {
      static void Main(string[] args)
      {
         var accountInfoViewModel = new AccountInfoViewModel();
         var list = new List<AccountInfo>();

         Console.WriteLine("거래처 정보를 넣어주세요");

         var accountInfos = new AccountInfo()
         {    
            CompanyName = "HS",
            CompanyManager = "김혜수",
            PhoneNumber = "010-2323-1115",
            Email = "juid00@naver.com",
            Address = "경기도",
            Description = "안녕하세요",
            CreatedDate = DateTime.Now
         };

         Console.WriteLine($"{accountInfos.AccountId} " +
                           $"{accountInfos.CompanyManager}");

         accountInfoViewModel.AddAccount(accountInfos);

         Console.ReadKey();

         list = accountInfoViewModel.GetAllAccount().ToList();

         foreach(var account in list)
         {
            Console.WriteLine($"{account.AccountId} " +
                           $"{account.CompanyManager}");
         }      
         Console.ReadKey();
      }
   }
}
