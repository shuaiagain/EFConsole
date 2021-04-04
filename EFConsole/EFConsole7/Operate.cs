using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole7.Entity;
using EFConsole7.ViewModel;

namespace EFConsole7
{
    public class Operate
    {
        #region ExampleO
        /// <summary>
        /// 填充种子数据
        /// </summary>
        public static void ExampleO()
        {
            //当使用LINQ to Entities时，理解何时使用IEnumerable和IQueryable很重要。
            //如果使用了IEnumerable，查询会立即执行，如果使用了IQueryable，
            //直到应用程序请求查询结果的枚举时才会执行查询，也就是查询延迟执行了，延迟到的时间点是枚举查询结果时。
            //如何决定使用IEnumerable还是IQueryable呢？使用IQueryable会让你有机会创建一个使用多条语句的复杂LINQ查询，
            //而不需要每条查询语句都对数据库执行查询。该查询只有在最终的LINQ查询要求枚举时才会执行
            using (var db = new DonatorsContext())
            {
                //1.查询语法
                var donators = from don in db.Donators
                               where don.Amount == 50m
                               select don;
                //2.方法语法
                var donators2 = db.Donators.Where(a => a.Amount == 50m);
                Console.WriteLine("Id\t姓名\t金额\t打赏日期");
                foreach (var item in donators)
                {
                    Console.WriteLine("{0}\t{1}t{2}t{3}", item.Id, item.Name, item.Amount, item.DonateDate);
                }
            }

            Console.WriteLine("Operation completed!");
            Console.Read();
        }
        #endregion

        #region ExampleP
        /// <summary>
        /// 使用导航属性，获取有关系的数据
        /// </summary>
        public static void ExampleP()
        {
            //如果实体间存在一种关系，那么这个关系是通过它们各自实体的导航属性进行暴露的。
            //在上面的例子中，省份Province实体有一个Donators集合属性用于返回该省份的所有打赏者，
            //而在打赏者Donator实体中，也有一个Province属性用于跟踪该打赏者属于哪个省份。
            //导航属性简化了从一个实体到和它相关的实体，下面我们看一下如何使用导航属性获取与其相关的实体数据
            using (var db = new DonatorsContext())
            {
                //1.查询语法
                var donators = from p in db.Provinces
                               where p.ProvinceName == "山东省"
                               from d in p.Donators
                               select d;
                //2.方法语法
                var donators2 = db.Provinces.Where(a => a.ProvinceName == "山东省").SelectMany(p => p.Donators);
                Console.WriteLine("Id\t姓名\t金额\t打赏日期");
                foreach (var item in donators)
                {
                    Console.WriteLine("{0}\t{1}t{2}t{3}", item.Id, item.Name, item.Amount, item.DonateDate);
                }
            }

            Console.WriteLine("Operation completed!");
            Console.Read();
        }
        #endregion

        #region ExampleQ
        /// <summary>
        /// 使用导航属性，获取有关系的数据
        /// </summary>
        public static void ExampleQ()
        {
            //linq相关操作：投影、分组、聚合
            using (var db = new DonatorsContext())
            {
                //投影：LINQ投影就是返回这些实体属性的子集或者返回一个包含了多个实体的某些属性的对象

                #region 投影
                var donators = from p in db.Provinces
                               select new DonatorsWithProvinceViewModel()
                               {
                                   Province = p.ProvinceName,
                                   DonatorList = p.Donators
                               };
                //2.方法语法
                var donators2 = db.Provinces.Select(p => new DonatorsWithProvinceViewModel() { Province = p.ProvinceName, DonatorList = p.Donators });
                Console.WriteLine("投影");
                #endregion

                #region 分组
                var dd = from q in db.Donatorsb
                         group q by q.Province.ProvinceName
                 into qgroup
                         select new
                         {
                             ProvinceName = qgroup.Key,
                             Donators = qgroup
                         };

                var dd2 = db.Donatorsb.GroupBy(d => d.Province.ProvinceName).Select(dgroup => new
                {
                    ProvinceName = dgroup.Key,
                    Donators = dgroup
                });
                #endregion

                #region skip
                //分页Paging，分页也是提升性能的一种方式，而不是将所有符合条件的数据一次性全部加载出来。
                //在LINQ to Entities中，实现分页的两个主要方法是：Skip和Take，这两个方法在使用前都要先进行排序，切记。

                var ee = db.Donatorsb;
                var ff = db.Donatorsb.OrderBy(d => d.Id).Skip(2);
                //遍历的时候会报错
                //The method 'Skip' is only supported for sorted input in LINQ to Entities. 
                //The method 'OrderBy' must be called before the method 'Skip'.
                var gg = db.Donatorsb.Skip(2);
                //foreach (var item in gg)
                //{
                //    Console.WriteLine("{0}", item.Name);
                //}
                #endregion

                #region take--相当于top n
                var h = db.Donatorsb;
                var i = db.Donatorsb.Take(2);
                #endregion
                Console.WriteLine("ok");

                #region 分页 
                Paging(2, 2);
                #endregion
            }

            Console.WriteLine("Operation completed!");
            Console.Read();
        }

        #endregion

        #region 分页
        public static void Paging(int pageSize, int page)
        {
            using (var context = new DonatorsContext())
            {
                var a = context.Donatorsb.OrderBy(o => o.Id).Skip((page - 1) * pageSize).Take(pageSize);
                Console.WriteLine("paging");
            }
        }
        #endregion
    }
}
