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
    public class Initializerb : DropCreateDatabaseIfModelChanges<Context.Contextb>
    {

        protected override void Seed(Context.Contextb context)
        {

            context.OutputAccounts.Add(new OutputAccount { Name = "甲", Balance = 6000 });
            context.InputAccounts.Add(new InputAccount { Name = "已", Balance = 0 });

            base.Seed(context);
        }
    }
}
