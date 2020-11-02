using BusinessLayer;
using DataAccessLayer;
using System.Windows;

namespace _3_tier
{
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void Savebtn_Click(object sender, RoutedEventArgs e)
      {
         var person = new Person();

         person.PersonId = int.Parse(personId.Text);
         person.FirstName = FirstName.Text;
         person.LastName = LastName.Text;

         var bLL = new PersonInfoBLL();
         bLL.GetPerson(person);
         MessageBox.Show("굿");
      }
   }

}
