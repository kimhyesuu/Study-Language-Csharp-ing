using DemoLibrary;

// 두번째
namespace DependencyInjectionDemo
{
    public class Application : IApplication
    {
        private IBusinessLogic _businessLogic;

        public Application(IBusinessLogic businessLogic)
        {
            this._businessLogic = businessLogic;    
        }

        public void Run()
        {
            _businessLogic.ProcessData();
        }
    }
}
