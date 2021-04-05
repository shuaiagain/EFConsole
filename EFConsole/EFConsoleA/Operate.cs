using EFConsoleA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EFConsoleA
{
    public class Operate
    {
        #region EF的默认并发
        #region GetDonator
        static Donator GetDonator(int id)
        {
            using (var db = new Context.Context())
            {
                return db.Donators.Find(id);
            }
        }
        #endregion

        #region UpdateDonator
        static void UpdateDonator(Donator donator)
        {
            using (var db = new Context.Context())
            {
                db.Entry(donator).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        #endregion

        #region ExampleA
        public static void ExampleA()
        {
            var don1 = GetDonator(1);
            var don2 = GetDonator(1);

            don1.Name = "风";
            UpdateDonator(don1);

            don2.Amount = 100;
            UpdateDonator(don2);
        }
        #endregion
        #endregion

        #region 设计处理字段级别并发的应用
        #region GetUpdateDonator
        static Donator GetUpdateDonator(int id, string name, decimal amount, DateTime donateDate)
        {
            return new Donator()
            {
                Id = id,
                Name = name,
                Amount = amount,
                DonateDate = donateDate
            };
        }
        #endregion

        #region UpdateDonatorEnhanced
        static void UpdateDonatorEnhanced(Donator originalDonator, Donator newDonator)
        {
            using (var db = new Context.Context())
            {
                //从数据库中检索最新的模型
                var donator = db.Donators.Find(originalDonator.Id);
                //接下来检查用户修改的每个属性
                if (originalDonator.Name != newDonator.Name)
                {
                    //将新值更新到数据库
                    donator.Name = newDonator.Name;
                }

                if (originalDonator.Amount != newDonator.Amount)
                {
                    //将新值更新到数据库
                    donator.Amount = newDonator.Amount;
                }

                //这里省略其他属性...
                db.SaveChanges();
            }
        }
        #endregion

        #region ExampleB
        public static void ExampleB()
        {
            var don1 = GetDonator(1);
            var don2 = GetDonator(1);

            var newDon1 = GetUpdateDonator(don2.Id, don1.Name, 100, don1.DonateDate);
            UpdateDonatorEnhanced(don1, newDon1);

            var newDon2 = GetUpdateDonator(don2.Id, "并发测试", don2.Amount, don2.DonateDate);
            UpdateDonatorEnhanced(don2, newDon2);
        }
        #endregion

        #endregion

        #region RowVersion
        //System.Data.Entity.Infrastructure.DbUpdateConcurrencyException: Store update, insert, or delete 
        //statement affected an unexpected number of rows(0). Entities may have been modified or deleted 
        //since entities were loaded.
        public static void ExampleC()
        {
            try
            {
                //1.用户甲获取id=1的打赏者
                var donator1 = GetDonator(1);
                //2.用户乙也获取id=1的打赏者
                var donator2 = GetDonator(1);
                //3.用户甲只更新这个实体的Name字段
                donator1.Name = "用户甲";
                UpdateDonator(donator1);
                //4.用户乙只更新这个实体的Amount字段
                donator2.Amount = 100m;
                UpdateDonator(donator2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常:{0} ", ex.Message);
            }
        }
        #endregion

        #region 事务
        public static void ExampleD()
        {
            int outputId = 1, inputId = 1;
            decimal transferAmount = 1000m;
            using (var db = new Context.Contextb())
            {
                //1 检索事务中涉及的账户
                var outputAccount = db.OutputAccounts.Find(outputId);
                var inputAccount = db.InputAccounts.Find(inputId);
                //2 从输出账户上扣除1000
                outputAccount.Balance -= transferAmount;
                //3 从输入账户上增加1000
                inputAccount.Balance += transferAmount;

                //4 提交事务
                db.SaveChanges();
            }
        }
        #endregion

        #region 事务-TransactionScope
        public static void ExampleE()
        {
            int outputId = 1, inputId = 1;
            decimal transferAmount = 2000m;
            using (var scope = new TransactionScope())
            {
                Context.Contextb db1 = new Context.Contextb();
                Context.Contextb db2 = new Context.Contextb();

                //1 检索事务中涉及的账户
                var outputAccount = db1.OutputAccounts.Find(outputId);
                var inputAccount = db2.InputAccounts.Find(inputId);

                //2 从输出账户上扣除1000
                outputAccount.Balance -= transferAmount;
                //3 从输入账户上增加1000
                inputAccount.Balance += transferAmount;

                //4 提交事务
                db1.SaveChanges();
                db2.SaveChanges();

                scope.Complete();
            }
        }
        #endregion

        #region 事务ef6-Database.BeginTransaction
        public static void ExampleF()
        {
            int outputId = 1, inputId = 1;
            decimal transferAmount = 10m;
            using (var db = new Context.Contextb())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var sql = @"Update OutputAccounts set Balance=Balance-@amountToDebit where id=@outputId";
                        db.Database.ExecuteSqlCommand(sql, new SqlParameter("@amountToDebit", transferAmount), new SqlParameter("@outputId", outputId));

                        var inputAccount = db.InputAccounts.Find(inputId);
                        inputAccount.Balance += transferAmount;
                        db.SaveChanges();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
        }
        #endregion
    }
}
