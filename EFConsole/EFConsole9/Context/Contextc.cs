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
    public class Contextc:DbContext
    {
        public Contextc() : base("name=EFConsole9")
        {
            Database.SetInitializer<Contextc>(new Initializerc());
        }

        public virtual DbSet<Donator> Donator { get; set; }

        public virtual DbSet<Province> Province { get; set; }
    }
}
