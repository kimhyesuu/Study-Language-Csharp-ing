using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnityContainer
{
   using Microsoft.Practices.Unity;

   class Program
   {
      static void Main(string[] args)
      {
         var container = new UnityContainer();

         container.RegisterType<IISayHelloWorld, Hello>();

         var test = container.Resolve<IISayHelloWorld>();

         test.ShowMessage("Hello World");

         Console.ReadKey();

      }
   }

   public interface IISayHelloWorld
   {
      void ShowMessage(string message);
   }

   public class Hello : IISayHelloWorld
   {
      public void ShowMessage(string message)
      {
         Console.WriteLine(message);
      }
   }

   public class Hello2 : IISayHelloWorld
   {
      private const string msg = "First :";

      public void ShowMessage(string message)
      {
         Console.WriteLine(msg + message);
      }
   }

}
