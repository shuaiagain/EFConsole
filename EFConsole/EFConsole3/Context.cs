using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole3.Entity;
using EFConsole3.EntityMap;

namespace EFConsole3
{
    /// <summary>
    /// 1.用"DbModelBuilder API(即Fluent API)的方式" 创建数据库表与实体的关系；
    /// 2.即重写OnModelCreating方法；
    /// 3.此外，使用fluent API的一个重要决定因素是我们是否使用了外部的POCO类，
    /// 即实体模型类是否来自一个类库。我们无法修改类库中类的定义，
    /// 所以不能通过数据注解来提供映射细节。这种情况，我们必须使用fluent API
    /// </summary>
    public class Context : DbContext
    {
        public Context() : base("name=EFConsole3")
        {
        }

        public DbSet<Donator> Donators { get; set; }

        public DbSet<PayWay> PayWays { get; set; }

        #region OnModelCreating（FluentApi方式配置表和实体关系）
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region 2.DbModelBuilder API
            ////映射到表Donators,DonatorId当作主键对待
            //modelBuilder.Entity<Donator>().ToTable("Donators").HasKey(m => m.DonatorId);
            ////映射到数据表中的主键名为Id而不是DonatorId
            //modelBuilder.Entity<Donator>().Property(m => m.DonatorId).HasColumnName("Id");
            ////设置Name是必须的，即不为null,默认是可为null的
            ////设置Name列为Unicode字符，实际上默认就是unicode,所以该方法可不写
            ////最大长度为10
            //modelBuilder.Entity<Donator>().Property(m => m.Name)
            //                                                    .IsRequired()
            //                                                    .IsUnicode()
            //                                                    .HasMaxLength(10); 
            #endregion

            #region 3.配置伙伴类
            modelBuilder.Configurations.Add(new DonatorMap());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
