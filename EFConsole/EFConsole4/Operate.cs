using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole4.Entity;

namespace EFConsole4
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

        #region 一对多关系
        public static void ExampleG()
        {
            using (var context = new Context())
            {
                var donator = new Donator()
                {
                    Name = "",
                    Amount = 6,
                    DonateTime = DateTime.Parse("2021-03-23")
                };

                donator.PayWays.Add(new PayWay() { Name = "支付宝" });
                donator.PayWays.Add(new PayWay() { Name = "微信" });

                context.Donators.Add(donator);
                context.SaveChanges();
            }
        }
        #endregion

        #region 一对多关系2
        public static void ExampleH()
        {
            using (var context = new Context())
            {
                var donatorType = new DonatorType()
                {
                    Name = "博客园园友",
                    Donators = new List<Donator>()
                    {
                        new Donator()
                        { Amount=6,Name="键盘里的鼠标",DonateTime=DateTime.Parse("2021-03-27"),
                            PayWays=new List<PayWay>{ new PayWay() { Name="支付宝"}, new PayWay() { Name = "微信" } }
                        }
                    }
                };

                var donatorType2 = new DonatorType()
                {
                    Name = "非博客园园友",
                    Donators = new List<Donator>()
                    {
                        new Donator()
                        { Amount=10,Name="待赞助",DonateTime=DateTime.Parse("2021-03-27"),
                            PayWays=new List<PayWay>{ new PayWay() { Name="支付宝"}, new PayWay() { Name = "微信" } }
                        }
                    }
                };

                context.DonatorTypes.Add(donatorType);
                context.DonatorTypes.Add(donatorType2);

                context.SaveChanges();
            }
        }
        #endregion

        #region 一对一的关系
        public static void ExampleI()
        {
            using (var context = new Context())
            {

                var student = new Student()
                {
                    CollegeName = "XX大学",
                    EnrollmentDate = DateTime.Parse("2011-11-11"),
                    Person = new Person()
                    {
                        Name = "Ferb"
                    }
                };

                context.Students.Add(student);
                context.SaveChanges();
            }
        }
        #endregion

        #region 多对多的关系
        public static void ExampleJ()
        {
            using (var context = new Context())
            {
                var person = new Person()
                {
                    Name = "比尔盖茨"
                };

                var person2 = new Person()
                {
                    Name = "乔布斯"
                };

                context.Person.Add(person);
                context.Person.Add(person2);

                var company = new Company()
                {
                    CompanyName = "微软"
                };

                company.Persons.Add(person);
                company.Persons.Add(person2);

                context.Companies.Add(company);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
