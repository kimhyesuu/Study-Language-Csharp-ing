using System.Windows.Controls;

namespace ChatApp.Desktop.Views
{
   /// <summary>
   /// Interaction logic for ChatLayout.xaml
   /// </summary>
   public partial class ChatLayout : UserControl
   {
      public ChatLayout()
      {
         InitializeComponent();
      }

      public Label MessageTitle
      {
         get => Title;
         set => Title = value;
      }

      public Button SendMessageButton
      {
         get => SendButton;
         set => SendButton = value;
      }

      public ScrollViewer ConetentScrollViewer
      {
         get => ContentScroller;
         set => ContentScroller = value;
      }

      public TextBox MessageContainer
      {
         get => MessageContent;
         set => MessageContent = value;
      }

      public ItemsControl MessageDisplay
      {
         get => MessageTemplete;
         set => MessageTemplete = value;
      }
   }
}
