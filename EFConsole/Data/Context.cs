using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Context : DbContext
    {
        public Context() : base("name=EFConsoleB")
        {
        }

        public DbSet<Donator> Donators { get; set; }

        public DbSet<Province> Provinces { get; set; }
    }
}
