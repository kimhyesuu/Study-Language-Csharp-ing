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

            //인터페이스에 상속된 클래스가 누구인지 명확하게 나타내기 위해서 만들어진 겁니다...
            container.RegisterType<IISayHelloWorld, Hello3>();

            //Resolve는 이것을 해결하는 역할 
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

    public class Hello3 : IISayHelloWorld
    {
        string msg = "김혜수가 불러줘요 ";

        public void ShowMessage(string message)
        {
            Console.WriteLine(msg + message);
        }
    }

}
