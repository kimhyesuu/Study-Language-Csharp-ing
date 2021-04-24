namespace Application.Helpers
{
    using System.Windows;

    /// <remarks>
    /// http://stackoverflow.com/questions/11535894/tag-property-in-wpf-datagrid-column
    /// </remarks>
    public static class ObjectTag
    {
        public static readonly DependencyProperty TagProperty = DependencyProperty.RegisterAttached(
            "Tag", typeof(object), typeof(ObjectTag), new FrameworkPropertyMetadata(null));

        public static object GetTag(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(TagProperty);
        }

        public static void SetTag(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(TagProperty, value);
        }
    }
}