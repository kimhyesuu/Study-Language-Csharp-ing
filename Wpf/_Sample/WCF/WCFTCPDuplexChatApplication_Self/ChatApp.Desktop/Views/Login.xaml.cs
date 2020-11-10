using ChatApp.Contracts;
using ChatApp.Contracts.Domain;
using ChatApp.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatApp.Desktop.Views
{
   public partial class Login : UserControl
   {
      private MainWindow _window;

      public Login()
      {
         InitializeComponent();

         _window = (MainWindow)Application.Current.MainWindow;

         if (_window != null)
         {
            _window.Width = 540;
            _window.Height = 420;
            _window.MinWidth = 540;
            _window.MinHeight = 420;
            _window.MaxHeight = 420;
            _window.MaxWidth = 540;
         }
      }

      private void LoginButton_Click(object sender, RoutedEventArgs e)
      {
         if(!string.IsNullOrEmpty(UserName.Text))
         {
            User user = new User()
            {
               TimeCreated = DateTime.UtcNow,
               Name = UserName.Text               
            };

            _window.MainView = new Main(_window,user);
            var uri = "net.tcp://localhost:8733/MessageService";
            var callback = new InstanceContext(new MessageCallBack());

            var binding = new NetTcpBinding(SecurityMode.None);

            //if (binding is null) return;

            var channel = new DuplexChannelFactory<IMessageService>(callback, binding);
            var endPoint = new EndpointAddress(uri);

            //if (endPoint is null) return;
            // System.InvalidOperationException:
            //'ChannelFactory에 제공된 InstanceContext에 
            // CallbackContractType 'ChatApp.Contracts.IMessageService'
            // 을(를) 구현하지 않는 UserObject가 포함되어 있습니다.'
            //해결

            // [ServiceContract(CallbackContract = typeof(IMessageCallBack),SessionMode = SessionMode.Required)]
            // IMessageCallback -> IMessageCallBack 변경
            try
            {
               
               var proxy = channel.CreateChannel(endPoint);

               //if (proxy != null)
               //{

               //}
               proxy?.Connect(user);
            }
            catch (Exception eeeeee)
            {

               Debug.WriteLine(eeeeee.Message);
               return;
            }

    
            _window.Main.Children.Clear();
            _window.Main.Children.Add(_window.MainView);
            
         }
      }
   }
}
