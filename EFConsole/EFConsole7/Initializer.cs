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

            base.Seed(context);
        }
    }
}
