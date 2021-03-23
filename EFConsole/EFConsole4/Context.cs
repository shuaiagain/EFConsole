using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole4.Entity;
using EFConsole4.EntityMap;

namespace EFConsole4
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
        public Context() : base("name=EFConsole4")
        {
        }

        public DbSet<Donator> Donators { get; set; }

        public DbSet<PayWay> PayWays { get; set; }

        #region OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DonatorMap());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
