using EFConsole4.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole4.EntityMap
{
    /// <summary>
    /// 3.创建Donator的配置伙伴类
    /// </summary>
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            
            HasMany(a => a.Companies)
                .WithMany(b => b.Persons)
                .Map(m =>
                {
                    m.MapLeftKey("PersonId");
                    m.MapRightKey("CompanyId");
                });
        }
    }
}
