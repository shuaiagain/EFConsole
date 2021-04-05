using EFConsoleA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleA.EntityMap
{
    class DonatorMap : EntityTypeConfiguration<Donator>
    {
        public DonatorMap()
        {
            Property(d => d.RowVersion)
                .IsRowVersion();
        }
    }
}
