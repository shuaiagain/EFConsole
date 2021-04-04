using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EFConsole7.Entity;

namespace EFConsole7
{
    public class Initializer : DropCreateDatabaseAlways<DonatorsContext>
    {
        protected override void Seed(DonatorsContext context)
        {

            for (int i = 0; i < 6; i++)
            {
                var item = new Donator()
                {
                    Name = "donator" + (i + 1),
                    Amount = 50,
                    DonateDate = DateTime.Now
                };

                context.Donators.Add(item);
            }

            Province proa = new Province() { ProvinceName = "山东省" };
            Province prob = new Province() { ProvinceName = "河北省" };

            context.Provinces.Add(proa);
            context.Provinces.Add(prob);

            Donatorb dona = new Donatorb() { Name = "风", Amount = 50, DonateDate = DateTime.Parse("2016-04-07") };
            Donatorb donb = new Donatorb() { Name = "雨", Amount = 5, DonateDate = DateTime.Parse("2019-07-07") };
            Donatorb donc = new Donatorb() { Name = "雷", Amount = 12, DonateDate = DateTime.Parse("2018-05-06") };
            Donatorb dond = new Donatorb() { Name = "电", Amount = 10, DonateDate = DateTime.Parse("2017-04-01") };
            context.Donatorsb.Add(dona);
            context.Donatorsb.Add(donb);
            context.Donatorsb.Add(donc);
            context.Donatorsb.Add(dond);
            //INSERT dbo.Provinces VALUES(N'山东省')
            //INSERT dbo.Provinces VALUES(N'河北省')

            //INSERT dbo.Donators VALUES(N'陈志康', 50, '2016-04-07',1)
            //INSERT dbo.Donators VALUES(N'海风', 5, '2016-04-08',1)
            //INSERT dbo.Donators VALUES(N'醉、千秋', 12, '2016-04-13',1)
            //INSERT dbo.Donators VALUES(N'雪茄', 18.8, '2016-04-15',2)
            //INSERT dbo.Donators VALUES(N'王小乙', 10, '2016-04-09',2)

            base.Seed(context);
        }
    }
}
