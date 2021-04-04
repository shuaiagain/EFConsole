using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EFConsole8.Entity;

namespace EFConsole8
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

          
            Donatorb dona = new Donatorb() { Name = "风", Amount = 50, DonateDate = DateTime.Parse("2016-04-07") };
            Donatorb donb = new Donatorb() { Name = "雨", Amount = 5, DonateDate = DateTime.Parse("2019-07-07") };
            Donatorb donc = new Donatorb() { Name = "雷", Amount = 12, DonateDate = DateTime.Parse("2018-05-06") };
            Donatorb dond = new Donatorb() { Name = "电", Amount = 10, DonateDate = DateTime.Parse("2017-04-01") };
            proa.Donators.Add(dona);
            proa.Donators.Add(donb);

            prob.Donators.Add(donc);
            prob.Donators.Add(dond);

            context.Provinces.Add(proa);
            context.Provinces.Add(prob);

            base.Seed(context);
        }
    }
}
