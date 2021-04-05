using EFConsole9.Entity;
using EFConsole9.Initializer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole9.Context
{
    public class Contextb:DbContext
    {
        public Contextb() : base("name=EFConsole9")
        {
            Database.SetInitializer<Contextb>(new Initializerb());
        }

        public virtual DbSet<Donator> Donator { get; set; }

        public virtual DbSet<Province> Province { get; set; }
    }
}
