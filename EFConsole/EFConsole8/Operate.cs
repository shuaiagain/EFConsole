using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole8.Entity;
using EFConsole8.ViewModel;

namespace EFConsole8
{
    public class Operate
    {
        #region 预加载
        public static void ExampleS()
        {
            using (var context = new DonatorsContext())
            {
                var a = context.Donatorsb.Include("Province");
                //var b = context.Donatorsb.Include(pp => pp.Province);

                Console.WriteLine("预加载");
            }
        }
        #endregion

        #region 新增-更新-删除
        public static void ExampleT()
        {
            #region 新增方法1
            var province = new Province() { ProvinceName = "浙江省" };
            province.Donators.Add(new Donatorb
            {
                Name = "星空",
                Amount = 50m,
                DonateDate = DateTime.Parse("2011-5-30")
            });

            province.Donators.Add(new Donatorb
            {
                Name = "蓝天",
                Amount = 25m,
                DonateDate = DateTime.Parse("2011-5-25")
            });

            //我们在初始化上下文之前就创建了对象，这个表明了EF会追踪当时上下文中为attached或者added状态的实体
            using (var context = new DonatorsContext())
            {
                context.Provinces.Add(province);
                context.SaveChanges();

                Console.WriteLine("新增");
            }
            #endregion

            #region 新增方法2
            var pro2 = new Province() { ProvinceName = "广东省" };
            pro2.Donators.Add(new Donatorb()
            {
                Name = "白云",
                Amount = 30,
                DonateDate = DateTime.Parse("2012-04-25")
            });

            //Added 添加了一个新的实体。该状态会导致一个插入操作。
            //Deleted 将一个实体标记为删除。设置该状态时，该实体会从DbSet中移除。该状态会导致删除操作。
            //Detached DbContext不再追踪该实体。
            //Modified 自从DbContext开始追踪该实体，该实体的一个或多个属性已经更改了。该状态会导致更新操作。
            //Unchanged 自从DbContext开始追踪该实体以来，它的任何属性都没有改变。
            using (var context2 = new DonatorsContext())
            {
                context2.Entry(pro2).State = EntityState.Added;
                context2.SaveChanges();
            }
            #endregion

            #region 更新
            //当EF知道自从实体首次附加到DbContext之后发生了改变，那么就会触发一个更新查询。
            //自从查询数据时 起，EF就会开始追踪每个属性的改变，当最终调用SaveChanges时，
            //只有改变的属性会包括在更新SQL操作中。当想要在数据库中找到一个要更新的实体时，
            //我们可以使用where方法来实现，也可以使用DbSet上的Find方法，该方法需要一个或多个参数，该参数对应于表中的主键。
            //下面的例子中，我们使用拥有唯一ID的列作为主键，因此我们只需要传一个参数。
            //如果你使用了复合主键（包含了不止一列，常见于连接表），就需要传入每列的值，并且主键列的顺序要准确。
            using (var context3 = new DonatorsContext())
            {
                var don = context3.Donatorsb.Find(5);
                don.Name = don.Name + "1";

                context3.SaveChanges();
                Console.WriteLine("更新");
            }
            #endregion

            #region 更新2
            var pro4 = new Province() { Id = 1, ProvinceName = "山东省更新" };
            pro4.Donators.Add(new Donatorb
            {
                Name = "流水",//再改回来
                Id = 3,
                Amount = 12.00m,
                DonateDate = DateTime.Parse("2012-4-13 0:00:00"),
            });

            using (var db4 = new DonatorsContext())
            {
                db4.Entry(pro4).State = EntityState.Modified;

                foreach (var donator in pro4.Donators)
                {
                    db4.Entry(donator).State = EntityState.Modified;
                }
                db4.SaveChanges();
            }
            #endregion

            #region AsNoTracking-减少跟踪的开销
            //一旦实体被附加到上下文，EF就会追踪实体的状态，这么做是值得的。
            //因此，如果你查询了数据，那么上下文就开始追踪你的实体。如果你在写一个web应用，
            //那么该追踪就变成了一个查询操作的不必要开销，原因是只要web请求完成了获取数据，
            //那么就会dispose上下文，并销毁追踪。EF有一种方法来减少这个开销：
            using (var db5 = new DonatorsContext())
            {
                //预加载
                var pros = db5.Provinces.Include(prov => prov.Donators);
                foreach (var item in pros)
                {
                    Console.WriteLine("省份实体的追踪状态：{0} ", db5.Entry(item).State);
                    foreach (var subItem in item.Donators)
                    {
                        Console.WriteLine("打赏者实体的追踪状态：{0} ", db5.Entry(subItem).State);
                    }
                }

                Console.WriteLine("#######");
                //使用AsNoTracking()方法设置不再追踪该实体
                var pros2 = db5.Provinces.Include(prov2 => prov2.Donators).AsNoTracking();
                foreach (var item in pros2)
                {
                    Console.WriteLine("省份实体的追踪状态：{0} ", db5.Entry(item).State);
                    foreach (var subItem in item.Donators)
                    {
                        Console.WriteLine("打赏者实体的追踪状态：{0} ", db5.Entry(subItem).State);
                    }
                }

            }
            #endregion

            #region Attach-将实体附加到上下文中，实体主键有值则状态State=Unchanged,无值则为Added
            //如果在web应用中想更新用户修改的属性怎么做？假设你在web客户端必须跟踪发生的变化并且拿到了变化的东西，
            //那么还可以使用另一种方法来完成更新操作，那就是使用DbSet的Attach方法。
            //该方法本质上是将实体的状态设置为Unchanged，并开始跟踪该实体。
            //附加一个实体后，一次只能设置一个更改的属性，你必须提前就知道哪个属性已经改变了。
            var don2 = new Donatorb()
            {
                Id = 4,
                Name = "电5",
                DonateDate = DateTime.Parse("2013-03-02"),
                Amount = 30
            };
            using (var db6 = new DonatorsContext())
            {
                //默认情况下，开始跟踪给定实体的给定实体和可访问的条目 Unchanged ，
                //但对于使用不同状态的情况，请参阅下面的情况。
                //通常，在调用之前不会执行数据库交互 SaveChanges() 。
                //将执行对导航属性的递归搜索以查找上下文尚未跟踪的可访问实体。 找到的所有实体将由上下文跟踪。
                //对于包含生成的键的实体类型，如果实体设置了其主键值，则会在状态中跟踪该实体 Unchanged 。 
                //如果未设置主键值，则会在状态中跟踪 Added 。 这有助于确保只插入新的实体。 
                //如果 primary key 属性设置为属性类型的 CLR 默认值以外的任何值，则会将该实体视为具有其主键值。
                //对于没有生成键的实体类型，状态集始终为 Unchanged 。
                //State仅用于设置单个实体的状态。
                db6.Donatorsb.Attach(don2);
                don2.Name = "电2";
                //这句可以作为第二种方法替换上面一句代码
                db6.Entry(don2).State = EntityState.Modified;
                db6.SaveChanges();
                Console.WriteLine("attach");
            }
            #endregion

            #region 删除1-todo-有问题，会报错
            using (var db7 = new DonatorsContext())
            {
                PrintAllDonators(db7);
                Console.WriteLine("删除后的数据如下：");

                //todo 删除会报错
                var toDelete = db7.Provinces.Find(1);
                //toDelete.Donators.ToList().ForEach(don => db7.Donatorsb.Remove(don));

                //db7.Provinces.Remove(toDelete);
                db7.SaveChanges();
                //PrintAllDonators(db7);
            }
            #endregion

            #region 删除2-todo-删除也报错
            //方法2：通过设置实体状态删除
            var toDeleteProvince = new Province { Id = 20 };//id=1的省份是山东省，对应三个打赏者
            toDeleteProvince.Donators.Add(new Donatorb
            {
                Id = 20
            });
            toDeleteProvince.Donators.Add(new Donatorb
            {
                Id = 21
            });
            toDeleteProvince.Donators.Add(new Donatorb
            {
                Id = 22
            });

            using (var db8 = new DonatorsContext())
            {
                //db8.Provinces.Attach(toDeleteProvince);
                //foreach (var donator in toDeleteProvince.Donators.ToList())
                //{
                //    db8.Entry(donator).State = EntityState.Deleted;
                //}
                //db8.Entry(toDeleteProvince).State = EntityState.Deleted;//删除完子实体再删除父实体
                db8.SaveChanges();
                Console.WriteLine("删除之后的数据如下：\r\n");
            }
            #endregion

            #region 使用内存in-memory数据
            using (var db9 = new DonatorsContext())
            {
                var pro9 = db9.Provinces.ToList();
                var query = db9.Provinces.Find(3);

                Console.WriteLine("local-data");
            }
            #endregion

            #region ChangeTracker对象
            using (var dba = new DonatorsContext())
            {
                var proa = dba.Provinces.ToList();

                foreach (var entityEntry in dba.ChangeTracker.Entries<Province>())
                {
                    Console.WriteLine(entityEntry.State);
                    Console.WriteLine(entityEntry.Entity.ProvinceName);
                }
            } 
            #endregion
        }
        #endregion

        #region 输出所有的打赏者
        private static void PrintAllDonators(DonatorsContext db)
        {
            var provinces = db.Provinces.ToList();
            foreach (var province in provinces)
            {
                Console.WriteLine("{0}的打赏者如下：", province.ProvinceName);
                foreach (var donator in province.Donators)
                {
                    Console.WriteLine("{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}", donator.Id, donator.Name, donator.Amount,
                        donator.DonateDate.ToShortDateString());
                }
            }
        }
        #endregion
    }
}
