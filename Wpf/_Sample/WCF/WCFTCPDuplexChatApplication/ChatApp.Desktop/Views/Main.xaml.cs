using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using ChatApp.Contracts.Domain;
using ChatApp.Desktop.ViewModels;

namespace ChatApp.Desktop.Views
{
   /// <summary>
   /// Interaction logic for Main.xaml
   /// </summary>
   public partial class Main : UserControl
   {
      private MainWindow _window;
      private User user;
      private ObservableCollection<Message> _message;
      private readonly SolidColorBrush[] userBackground = new SolidColorBrush[4];
      private User _user;

      public Main(MainWindow window, User user)
      {
         InitializeComponent();
         this.DataContext = new MessageViewModel();
         _window = window;
         this.user = user;
         _window.Width = 540;
         _window.Height = 400;
         _window.Background = new SolidColorBrush();
         userBackground[0] = new SolidColorBrush(Color.FromArgb(223,108,41,239));
         userBackground[0] = new SolidColorBrush(Color.FromArgb(223, 239, 41, 210));
         userBackground[0] = new SolidColorBrush(Color.FromArgb(233, 73, 44, 130));
         userBackground[0] = new SolidColorBrush(Color.FromArgb(223, 115, 36, 103));


      }

      private void Grid_Loaded(object sender, System.Windows.RoutedEventArgs e)
      {
         Timer timer = new Timer(obj =>
         {
            _window.MainView.Dispatcher.Invoke(() =>
            {

            });
         },null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1)
         );
      }
   }
}
