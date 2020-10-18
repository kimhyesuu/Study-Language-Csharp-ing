using Autofac;
using DemoLibrary;
using System.Reflection;
using System.Linq;

// 첫번째
namespace DependencyInjectionDemo
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            // 리플렉션을 통해 생성 할 컴포넌트를 등록합니다
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();
            
            // DemoLibrary.Utilities
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                // I인 클래스로 모으고 AS 별칭 사용
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));


            return builder.Build();
        }
    }
}
