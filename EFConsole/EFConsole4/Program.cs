using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole4
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new Initializer());
            //Operate.ExampleG();
            //Operate.ExampleH();
            //Operate.ExampleI();
            Operate.ExampleJ();
        }
    }
}
