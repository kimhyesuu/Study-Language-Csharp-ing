using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class PersonInfoBLL
   {

      public void GetPerson(Person person)
      {
         PersonDAL DAL = new PersonDAL();
         DAL.add(person);
      }

   }
}
