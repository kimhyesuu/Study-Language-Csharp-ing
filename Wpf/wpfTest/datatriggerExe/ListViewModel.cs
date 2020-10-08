using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datatriggerExe
{
   public enum Warnings
   {
      Safe, 
      Caution,
      Danger,
      Lethal
   }

   public class ListViewModel
   {
      public ObservableCollection<Warnings> GetWarnings { get; private set; }

      public ListViewModel()
      {
         GetWarnings = new ObservableCollection<Warnings>
         {
            Warnings.Safe,
            Warnings.Caution,
            Warnings.Danger,
            Warnings.Lethal
         };
      }
   }
}
