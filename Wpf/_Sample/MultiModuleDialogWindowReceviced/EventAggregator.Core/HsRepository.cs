using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.Core
{
    public struct HsRepository<T>
    {
        public static List<T> Patients = new List<T>(); 


        internal void Add(T parameter)
        {
            Patients.Add(parameter);
        }

        


        //internal void Remove(string patient)
        //{
        //    Patients.Remove(patient);
        //}    
    }
}
