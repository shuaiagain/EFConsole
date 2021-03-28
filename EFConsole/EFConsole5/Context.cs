using EFConsole5.Entity;
using EFConsole5.EntityMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole5
{
    public class Context : DbContext
    {
        #region Context
        public Context() : base("name=EFConsole5")
        {
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new VendorbMap());
            //modelBuilder.Configurations.Add(new EmployeebMap());
            modelBuilder.Entity<Vendorb>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Vendorb");
            });

            modelBuilder.Entity<Employeeb>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Employeeb");
            });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Persona> Peoplea { get; set; }

        public virtual DbSet<Personb> Peopleb { get; set; }

    }
}
