using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement
{
    public class HsRepository<T>
    {
        public static List<T> Patients = new List<T>();

        public HsRepository()
        {

        }

        internal void Add(T parameter)
        {
            Patients.Add(parameter);
        }
    }
}
