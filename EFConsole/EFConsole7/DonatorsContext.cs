using EFConsole7.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole7
{
    public class DonatorsContext : DbContext
    {
        public DonatorsContext() : base("name=DonatorsConn")
        {
            Database.SetInitializer(new Initializer());
        }

        public virtual DbSet<Donator> Donators { get; set; }
    }
}
