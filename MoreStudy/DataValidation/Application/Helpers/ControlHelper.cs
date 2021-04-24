namespace Application.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public static class ControlHelper
    {
        /// <summary>
        /// Finds the visual children.
        /// </summary>
        /// <typeparam name="T">The type of control that is to be found.</typeparam>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The list of requested visual children instances.</returns>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            if (dependencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        /// <summary>
        /// Finds the visual parent.
        /// </summary>
        /// <typeparam name="T">The requested visual parent type.</typeparam>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The visual parent of the given type if found, otherwise null.</returns>
        /// <exception cref="System.ArgumentException">Cannot Walk Parent Tree of  + object.GetType().ToString()</exception>
        public static T FindVisualParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            if (dependencyObject == null)
            {
                return null;
            }

            T correctlyTyped = dependencyObject as T;
            if (correctlyTyped != null)
            {
                return correctlyTyped;
            }

            if (dependencyObject is Visual)
            {
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            else
            {
                FrameworkContentElement fce = dependencyObject as FrameworkContentElement;
                if (fce != null)
                {
                    dependencyObject = fce.Parent;
                }
                else
                {
                    throw new ArgumentException("Cannot Walk Parent Tree of " + dependencyObject.GetType().ToString());
                }
            }

            return FindVisualParent<T>(dependencyObject);
        }

        /// <summary>
        /// Get the UI Element that is in the container at the point specified
        /// </summary>
        public static UIElement GetUiElement(ItemsControl container, Point position)
        {
            var elementAtPosition = container.InputHitTest(position) as UIElement;

            // Move up the UI tree until you find the actual UIElement that is the Item of the container
            if (elementAtPosition != null)
            {
                while (elementAtPosition != null)
                {
                    object testUiElement = container.ItemContainerGenerator.ItemFromContainer(elementAtPosition);
                    if (testUiElement != DependencyProperty.UnsetValue)
                    {
                        // If found the UIElement
                        return elementAtPosition;
                    }

                    elementAtPosition = VisualTreeHelper.GetParent(elementAtPosition) as UIElement;
                }
            }

            return null;
        }

        /// <summary>
        /// Determines if the relative position is above the UIElement in the coordinate
        /// </summary>
        public static bool IsPositionAboveElement(UIElement i, Point relativePosition)
        {
            // If above
            if (relativePosition.Y < ((FrameworkElement)i).ActualHeight / 2)
            {
                return true;
            }

            return false;
        }
    }
}