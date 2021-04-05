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
    public class Context : DbContext
    {
        public Context() : base("name=EFConsoleA")
        {
            Database.SetInitializer(new Initializer.Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DonatorMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Donator> Donators { get; set; }
    }
}
