using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsoleA.Context;
using EFConsoleA.Entity;

namespace EFConsoleA.Initializer
{
    public class Initializer : DropCreateDatabaseAlways<Context.Context>
    {

        protected override void Seed(Context.Context context)
        {
            for (int i = 0; i < 6; i++)
            {
                var item = new Donator()
                {
                    Name = "donator" + (i + 1),
                    Amount = 50 + i,
                    DonateDate = DateTime.Now,
                    RowVersion = new byte[i]
                };

                context.Donators.Add(item);
            }

            base.Seed(context);
        }
    }
}
