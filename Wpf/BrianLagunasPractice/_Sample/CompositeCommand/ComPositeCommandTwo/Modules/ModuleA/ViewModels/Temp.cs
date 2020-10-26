using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModuleA.ViewModels
{
//    public static class GlobalCommands
//    {
//        public static CompositeCommand ShowFinanceFormCommand = new CompositeCommand();
//    }

//    public class FinanceViewModel
//    {
//        public FinanceViewModel()
//        {
//            GlobalCommands.ShowFinanceFormCommand.RegisterCommand(this.ShowFinancePopupCommand);
//        }
//    }
 
//    public class EmployeeViewModel
//    {

//        public EmployeeViewModel()
//        {
//            this.EmployeeShowFinanceFormCommand = GlobalCommands.ShowFinanceFormCommand;
//        }
//    }


//    public class ShowFinanceFormEvent : PubSubEvent<object>
//    {
//    }

//    public class EmployeeViewModel2
//    {
//        private readonly IEventAggregator eventAggregator;

//        public EmployeeViewModel2(IEventAggregator eventAggregator)
//        {
//            this.ShowFormCommand = new DelegateCommand(RaiseShowFormEvent);
//            this.eventAggregator = eventAggregator;
//        }

//        public ICommand ShowFormCommand { get; }

//        private void RaiseShowFormEvent()
//        {
//            // Notify any listeners that the button has been pressed
//            this.eventAggregator.GetEvent<ShowFinanceFormEvent>().Publish(null);
//        }
//    }

//    public class FinanceViewModel2
//    {
//        public FinanceViewModel2(IEventAggregator eventAggregator)
//        {
//            // subscribe to button click events
//            eventAggregator.GetEvent<ShowFinanceFormEvent>().Subscribe(this.ShowForm);

//            this.ShowFinanceFormRequest = new InteractionRequest<INotification>();
//        }

//        public InteractionRequest<INotification> ShowFinanceFormRequest { get; }

//        private void ShowForm(object src)
//        {
//            // Logic goes here to show the form... e.g.
//            this.ShowFinanceFormRequest.Raise(
//                new Notification { Content = "Wow it worked", Title = "Finance form title" });
//        }


////        <Button Content = "Options" Command="{Binding OpenConnectionOptionsCommand}">
////    <i:Interaction.Triggers>
////        <prism:InteractionRequestTrigger SourceObject = "{Binding OptionSettingConfirmationRequest, Mode=OneWay}" >
////            < prism:PopupWindowAction>
////                <prism:PopupWindowAction.WindowContent>
////                    <views:CustomPopupView />
////                </prism:PopupWindowAction.WindowContent>
////            </prism:PopupWindowAction>
////        </prism:InteractionRequestTrigger>
////    </i:Interaction.Triggers>
////</Button>
    }

}
