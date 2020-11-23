using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;
using System.Windows;

namespace Behavior.Behaviors
{
   public class BehaviorContainer
   {
      public Behavior Value { get; set; }
   }

   public class BehaviorsMediator
   {
      public static readonly DependencyProperty BehaviorContainerProperty =
            DependencyProperty.RegisterAttached(
                 "BehaviorContainer",
                 typeof(BehaviorContainer),
                 typeof(BehaviorsMediator),
                 new UIPropertyMetadata(null, OnPropertyBehaviorContainerChanged));

      public static BehaviorContainer GetBehaviorContainer(DependencyObject obj)
      {
         return (BehaviorContainer)obj.GetValue(BehaviorContainerProperty);
      }

      public static void SetBehaviorContainer(DependencyObject obj, Behaviors value)
      {
         obj.SetValue(BehaviorContainerProperty, value);
      }

      private static void OnPropertyBehaviorContainerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         var behaviorContainer = e.NewValue as BehaviorContainer;
         if (behaviorContainer?.Value == null)
         {
            return;
         }

         var behavior = behaviorContainer.Value;
         var behaviors = Interaction.GetBehaviors(d);
         behaviors.Add(behavior);
      }
   }
}
