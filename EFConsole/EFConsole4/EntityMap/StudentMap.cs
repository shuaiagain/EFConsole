﻿using EFConsole4.Entity;
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
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            HasRequired(a => a.Person)
                .WithOptional(p => p.Student);
            HasKey(s => s.PersonId);

            Property(m => m.CollegeName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
