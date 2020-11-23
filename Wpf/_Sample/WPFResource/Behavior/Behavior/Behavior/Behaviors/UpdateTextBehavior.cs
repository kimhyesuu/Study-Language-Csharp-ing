using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Behavior.Behaviors
{
   public class UpdateTextBehavior : Behavior<TextBox>
   {
      public Key AcceptKey { get; set; }

      protected override void OnAttached()
      {
         base.OnAttached();

         this.AssociatedObject.KeyDown += this.TextBoxOnKeyDown;
      }

      private void TextBoxOnKeyDown(object sender, KeyEventArgs e)
      {
         if (e.Key != this.AcceptKey)
         {
            return;
         }

         var binding = this.AssociatedObject.GetBindingExpression(TextBox.TextProperty);
         binding?.UpdateSource();

         this.AssociatedObject.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
      }

      protected override void OnDetaching()
      {
         this.AssociatedObject.KeyDown -= this.TextBoxOnKeyDown;

         base.OnDetaching();
      }
   }
}
