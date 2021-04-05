using EFConsole9.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole9.EntityMap
{
    public class DonatorMap : EntityTypeConfiguration<Donator>
    {
        public DonatorMap()
        {
            HasRequired(a => a.Province)
                .WithMany(a => a.Donators)
                .HasForeignKey(a => a.ProvinceId);
        }
    }
}
