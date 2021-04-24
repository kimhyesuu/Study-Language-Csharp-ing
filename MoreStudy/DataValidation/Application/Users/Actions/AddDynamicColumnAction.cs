namespace Application.Users.Actions
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    using Application.Helpers;

    using SmallApplicationFramework.Wpf.InteractionRequest;

    using ViewModel.Users.Notifications;

    public class AddDynamicColumnAction : TriggerActionBase<AddDynamicColumnNotification>
    {
        protected override void ExecuteAction()
        {
            var resourceDictionary = ResourceDictionaryResolver.GetResourceDictionary("Styles.xaml");

            var userRoleValueConverter = resourceDictionary["UserRoleValueConverter"] as IValueConverter;

            var checkBoxColumnStyle = resourceDictionary["CheckBoxColumnStyle"] as Style;

            var binding = new Binding
                              {
                                  Converter = userRoleValueConverter,
                                  RelativeSource =
                                      new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGridCell), 1),
                                  Path = new PropertyPath("."),
                                  Mode = BindingMode.TwoWay
                              };

            var dataGridCheckBoxColumn = new DataGridCheckBoxColumn
                                             {
                                                 Header = this.Notification.Role.Name,
                                                 Binding = binding,
                                                 IsThreeState = false,
                                                 CanUserSort = false,
                                                 ElementStyle = checkBoxColumnStyle,
                                             };

            ObjectTag.SetTag(dataGridCheckBoxColumn, this.Notification.Role);

            var userGridView = this.AssociatedObject as UserGridView;
            if (userGridView != null)
            {
                userGridView.DataGridUsers.Columns.Add(dataGridCheckBoxColumn);
            }
        }
    }
}