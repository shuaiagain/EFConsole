using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole7.Entity;

namespace EFConsole7
{
    public class Operate
    {
        #region ExampleN
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
    }
}
