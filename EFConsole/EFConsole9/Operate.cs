using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole9;
using EFConsole9.Entity;
using EFConsole9.View;
using EFConsole9.ViewModel;

namespace EFConsole9
{
    public class Operate
    {
        #region 视图查询方式1
        public static void Example2()
        {

            using (var db = new Context.Context())
            {
                var donators = db.DonatorView;
                foreach (var donator in donators)
                {
                    Console.WriteLine(donator.ProvinceName + "\t" + donator.DonatorId + "\t" + donator.DonatorName + "\t" + donator.Amount + "\t" + donator.DonateDate);
                }
            }
        }
        #endregion

        #region 视图查询2
        public static void Example3()
        {
            using (var db2 = new Context.Contextb())
            {
                var sql = @"SELECT DonatorId ,DonatorName ,Amount ,DonateDate ,ProvinceName from dbo.DonatorView where ProvinceName={0}";
                var donatorsViaCommand = db2.Database.SqlQuery<DonatorViewInfo>(sql, "河北省");
                foreach (var donator in donatorsViaCommand)
                {
                    Console.WriteLine(donator.ProvinceName + "\t" + donator.DonatorId + "\t" + donator.DonatorName + "\t" + donator.Amount + "\t" + donator.DonateDate);
                }
            }
        }
        #endregion

        #region 存储过程查询
        public static void Example4()
        {
            using (var db2 = new Context.Contextc())
            {
                var sql = @" SelectDonatorsPro {0} ";
                var donatorsViaCommand = db2.Database.SqlQuery<DonatorFromStoreProcedure>(sql, "河北省");
                foreach (var donator in donatorsViaCommand)
                {
                    Console.WriteLine(donator.ProvinceName + "\t" + donator.Amount + "\t" + donator.DonateDate);
                }
            }
        }
        #endregion

        #region 异步查询
        public static void Example5()
        {
            Task<IEnumerable<Donator>> aa = GetDonatorsAsync();
            List<Donator> bb = aa.Result as List<Donator>;
            foreach (var item in bb)
            {

            }
        }

        static async Task<IEnumerable<Donator>> GetDonatorsAsync()
        {
            using (var db = new Context.Contextc())
            {
                return await db.Donator.ToListAsync();
            }
        }

        #endregion

    }
}
