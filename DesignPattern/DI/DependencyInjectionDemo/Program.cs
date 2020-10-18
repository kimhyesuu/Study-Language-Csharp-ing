using Autofac;
using System;

namespace DependencyInjectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            // BeginLifetimeScope:  Begin a new nested scope.Component 
            //                      instances created via the new scope will
            //                      be disposed along with it.
            using (var scope = container.BeginLifetimeScope())
            {
                //내가 만든 문맥에서 서비스 검색
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
                Console.ReadKey();
        }
    }
}
