using BusinessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _3_TierEntityFramework
{
   /// <summary>
   /// Interaction logic for RegisterDog.xaml
   /// </summary>
   public partial class RegisterDog : Window
   {
      public RegisterDog()
      {
         InitializeComponent();

      }

      private Dog _dog;

      public RegisterDog(Dog dog)
      {
         _dog = dog;
         dogid.Text = _dog.DogId.ToString();
         dogName.Text = _dog.Name;
         dogkind.Text = _dog.Kinds;
         dogemail.Text = _dog.Email;
         dogSize.Text = _dog.Size.ToString();
      }

      private void BtnClose_Click(object sender, RoutedEventArgs e)
      {
         var oneDog = new Dog()
         {
            DogId = Convert.ToInt32(dogid.Text),
            Name = dogName.Text,
            Kinds = dogkind.Text,
            Email = dogemail.Text,
            Size = Convert.ToInt32(dogSize.Text)
         };

         if (!(oneDog.DogId == 0 && oneDog.Name is null))
            return;

         var result = MessageBox.Show("저장하시겠습니까?", "정보", MessageBoxButton.OK);

         if (result == MessageBoxResult.OK)
         {
            DogService.Insert(oneDog);
         }
         else
         {
            return;
         }
      }

      private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {

      }   
   }
}
