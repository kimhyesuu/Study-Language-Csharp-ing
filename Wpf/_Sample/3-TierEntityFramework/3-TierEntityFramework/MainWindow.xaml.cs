using BusinessLayer;
using Model;
using System.Windows;
using System.Windows.Controls;

namespace _3_TierEntityFramework
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      DataGrid grid;

      public MainWindow()
      {
         InitializeComponent();
      }

      private void DataGrid_Loaded(object sender, RoutedEventArgs e)
      {
         grid = sender as DataGrid;
         grid.ItemsSource = DogService.GetAll();
      }

      private void AddBtn_Click(object sender, RoutedEventArgs e)
      {

         RegisterDog registerDog = new RegisterDog();
         registerDog.ShowDialog();
         grid.ItemsSource = DogService.GetAll();

      }

      private void EditBtn_Click(object sender, RoutedEventArgs e)
      {
         RegisterDog registerDog = new RegisterDog(grid.SelectedItem as Dog);
         registerDog.ShowDialog();
         grid.ItemsSource = DogService.GetAll();
      }

      private void DeleteBtn_Click(object sender, RoutedEventArgs e)
      {
         if (grid.CurrentCell == null)
            return;

         if(MessageBox.Show("Are you sure want to delete this the record?","정보",MessageBoxButton.YesNo) == MessageBoxResult.OK)
         {
            DogService.Delete(grid.SelectedItem as Dog);
         }
      }
   }


}
