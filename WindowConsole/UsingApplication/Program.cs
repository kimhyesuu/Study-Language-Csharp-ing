using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UsingApplication
{
    using System.Windows.Forms;

    class Program : Form
    {
        static void Main(string[] args)
        {
            Program form = new Program();

            form.Click += (s, e) =>
            {
                Console.WriteLine("goodbye");
                Application.Exit();
            };

            Console.WriteLine("Starting Window Application");
            Application.Run(form);

            Console.WriteLine("Exiting");

        }
    }
}
