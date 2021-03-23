using EFConsole3.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole3.EntityMap
{
    /// <summary>
    /// 3.创建Donator的配置伙伴类
    /// </summary>
    class DonatorMap : EntityTypeConfiguration<Donator>
    {
        public DonatorMap()
        {
            ToTable("Donator");
            Property(m => m.Name)
                .IsRequired()
                .HasColumnName("DonatorName");
        }
    }
}
