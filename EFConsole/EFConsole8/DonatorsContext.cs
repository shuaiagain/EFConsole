using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole8.Entity;

namespace EFConsole8
{
    public class DonatorsContext : DbContext
    {
        public DonatorsContext() : base("name=DonatorsConn")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new Initializer());
        }

        public virtual DbSet<Donator> Donators { get; set; }

        public virtual DbSet<Donatorb> Donatorsb { get; set; }

        public virtual DbSet<Province> Provinces { get; set; }
    }
}
