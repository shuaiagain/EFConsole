using EFConsoleA.Entity;
using EFConsoleA.EntityMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleA.Context
{
    public class Contextb : DbContext
    {
        public Contextb() : base("name=EFConsoleA")
        {
            Database.SetInitializer(new Initializer.Initializerb());
        }

        public DbSet<InputAccount> InputAccounts { get; set; }

        public DbSet<OutputAccount> OutputAccounts { get; set; }
    }
}
