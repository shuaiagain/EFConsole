using EFConsole2.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole2
{
    public class Context : DbContext
    {
        public Context() : base("name=EFConsole2")
        {
        }

        public DbSet<Donator> Donators { get; set; }

        public DbSet<PayWay> PayWays { get; set; }
    }
}
