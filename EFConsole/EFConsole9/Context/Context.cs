using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EFConsole9.View;
using EFConsole9.ViewMap;
using EFConsole9.Entity;
using EFConsole9.Initializer;

namespace EFConsole9.Context
{
    public class Context : DbContext
    {
        public Context() : base("name=EFConsole9")
        {
            Database.SetInitializer<Context>(new Initializer.Initializer());
        }

        public virtual DbSet<Donator> Donator { get; set; }

        public virtual DbSet<Province> Province { get; set; }

        public virtual DbSet<DonatorViewInfo> DonatorView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DonatorViewInfoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
