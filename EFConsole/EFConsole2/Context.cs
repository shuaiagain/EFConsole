using EFConsole2.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole2
{
    /// <summary>
    /// 用"注解(即特性)的方式" 创建数据库表与实体的关系
    /// </summary>
    public class Context : DbContext
    {
        public Context() : base("name=EFConsole2")
        {
        }

        public DbSet<Donator> Donators { get; set; }

        public DbSet<PayWay> PayWays { get; set; }
    }
}
