using EFConsole5.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole5.EntityMap
{
    public class VendorbMap : EntityTypeConfiguration<Vendorb>
    {
        public VendorbMap()
        {
            Map(m => m.MapInheritedProperties());
            ToTable("Vendorb");
        }
    }
}
