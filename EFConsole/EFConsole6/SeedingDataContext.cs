using EFConsole6.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole6
{
    public class SeedingDataContext : DbContext
    {
        public SeedingDataContext():base("name=EFConsole6")
        {
            Database.SetInitializer(new SeedingDataInitializer());
        }

        public virtual DbSet<Employer> Employers { get; set; }
    }
}
