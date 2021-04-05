using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EFConsole9.Entity;

namespace EFConsole9.Initializer
{
    public class Initializer : DropCreateDatabaseAlways<Context.Context>
    {
        protected override void Seed(Context.Context context)
        {
            string drop = @" DROP TABLE DonatorView ";
            context.Database.ExecuteSqlCommand(drop);

            string createView = @"
                                CREATE VIEW [dbo].[DonatorView]
                                AS
                                SELECT 
	                                don.Id AS DonatorId,
	                                don.Name AS DonatorName,
	                                don.Amount AS Amount,
	                                don.DonateDate AS DonateDate,
	                                pro.ProvinceName AS ProvinceName
                                 FROM dbo.Donator don
                                 INNER JOIN dbo.Province pro ON pro.Id = don.ProvinceId ";

            context.Database.ExecuteSqlCommand(createView);

            Province proa = new Province() { ProvinceName = "山东省" };
            Province prob = new Province() { ProvinceName = "河北省" };
            for (int i = 0; i < 6; i++)
            {
                var item = new Donator()
                {
                    Name = "donator" + (i + 1),
                    Amount = 50,
                    DonateDate = DateTime.Now
                };

                proa.Donators.Add(item);
                prob.Donators.Add(item);
            }

            context.Province.Add(proa);
            context.Province.Add(prob);

            base.Seed(context);
        }
    }
}
