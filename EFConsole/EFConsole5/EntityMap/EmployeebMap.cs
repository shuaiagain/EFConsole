using EFConsole5.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole5.EntityMap
{
    public class EmployeebMap : EntityTypeConfiguration<Employeeb>
    {
        public EmployeebMap()
        {
            Map(m => m.MapInheritedProperties());
            ToTable("Employeeb");
        }
    }
}
