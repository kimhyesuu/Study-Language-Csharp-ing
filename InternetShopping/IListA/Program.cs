using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IListA
{
    //     The main difference between List and IList 
    //    in C# is that List is a class that represents a list of objects
    //    which can be accessed by index 
    //    while IList is an interface that represents 
    //    a collection of objects which can be accessed by index. 
    //    The IList interface implemented from two interfaces 
    //    and they are ICollection and IEnumerable.

    //     List and IList are used to denote a set of objects.
    //    They can store objects of integers, strings, etc.
    //    There are methods to insert, remove elements, 
    //    search and sort elements of a List or IList.
    //    The major difference between List and IList is 
    //    that List is a concrete class and IList is an interface. 
    //    Overall, List is a concrete type 
    //    that implements the IList interface.




    class Program
    {
        static void Main(string[] args)
        {
            IList<string> ilist = new List<string>();
            ilist.Add("Mark");
            ilist.Add("John");
            IList<string> list = new ObservableCollection<string>();
            ilist.Add("Mark");
            ilist.Add("John");
            foreach (string lst in ilist)
            {
                Console.WriteLine(lst);
            }
            foreach (string lst in list)
            {
                Console.WriteLine(lst);
            }
            Console.ReadLine();

            //IList<string> ilist = new IList<string>();
            ////This will throw error as we cannot create instance for an IList as it is an interface.
            //ilist.Add("Mark");
            //ilist.Add("John");
            //foreach (string list in ilist)
            //{
            //    Console.WriteLine(list);
            //}
        }
    }
}
