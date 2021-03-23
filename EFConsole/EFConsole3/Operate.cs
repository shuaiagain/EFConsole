using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole3.Entity;

namespace EFConsole3
{
    class Operate
    {
        #region 创建数据库
        /// <summary>
        /// 创建数据库
        /// </summary>
        public static void ExampleA()
        {
            using (var context = new Context())
            {
                context.Database.CreateIfNotExists();
            }

            Console.WriteLine("DB has created!");
            Console.Read();
        }
        #endregion

        #region 插入操作
        /// <summary>
        /// 插入数据
        /// </summary>
        public static void ExampleB()
        {
            using (var context = new Context())
            {
                context.Database.CreateIfNotExists();
                List<Donator> donators = new List<Donator>()
                {
                     new Donator
                    {
                      Name   = "陈志康",
                      Amount = 50,
                      DonateTime = new DateTime(2016, 4, 7)
                    },
                    new Donator
                    {
                        Name = "海风",
                        Amount = 5,
                        DonateTime = new DateTime(2016, 4, 8)
                    },
                    new Donator
                    {
                        Name = "醉千秋",
                        Amount = 18.8m,
                        DonateTime = new DateTime(2016, 4, 15)
                    }
                };

                context.Donators.AddRange(donators);
                context.SaveChanges();
            }
        }
        #endregion

        #region 查询操作
        /// <summary>
        /// 查询操作
        ///  EF中很重要的一个概念： 延迟查询。
        ///  但是此时还没有真正查询数据库，只有当LINQ的查询结果被访问或者枚举时才会将查询命令发送到数据库。
        /// </summary>
        public static void ExampleC()
        {
            using (var context = new Context())
            {
                var donators = context.Donators;
                foreach (var item in donators)
                {
                    Console.WriteLine("name：{0}", item.Name);
                }
            }
        }
        #endregion

        #region 修改操作
        /// <summary>
        /// 修改操作
        /// </summary>
        public static void ExampleD()
        {
            using (var context = new Context())
            {
                var donators = context.Donators;
                if (donators.Any())
                {
                    var firstOne = donators.First(a => a.Name == "醉千秋");
                    firstOne.Name = "醉、千秋";

                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region 删除操作
        /// <summary>
        /// 删除操作
        /// </summary>
        public static void ExampleE()
        {
            using (var context = new Context())
            {
                var donators = context.Donators.Single(a => a.Name == "待打赏");
                if (donators != null)
                {
                    context.Donators.Remove(donators);
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region 查询新增的表PayWays
        /// <summary>
        /// 查询新增的表
        /// </summary>
        public static void ExampleF()
        {
            //System.InvalidOperationException: The model backing the 'Context' context has changed since the database was created. 
            //Consider using Code First Migrations to update the database(http://go.microsoft.com/fwlink/?LinkId=238269).
            using (var context = new Context())
            {
                var payWays = context.PayWays;
                foreach (var item in payWays)
                {

                }
            }
        }
        #endregion
    }
}
