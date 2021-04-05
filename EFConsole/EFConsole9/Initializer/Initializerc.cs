using EFConsole9.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole9.Initializer
{
    public class Initializerc : DropCreateDatabaseAlways<Context.Contextc>
    {
        protected override void Seed(Context.Contextc context)
        {
            string createProcedure = @"
                               CREATE PROCEDURE SelectDonatorsPro
                                @provinceName AS VARCHAR(20)
                                AS 
                                BEGIN
                                 SELECT ProvinceName,
		                                Name,Amount,
		                                DonateDate 
                                 FROM dbo.Donator don
                                 INNER JOIN dbo.Province pro ON pro.Id = don.ProvinceId
                                 WHERE pro.ProvinceName = @provinceName
                                END ";

            context.Database.ExecuteSqlCommand(createProcedure);

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

                if (i <= 2)
                    proa.Donators.Add(item);
                else
                    prob.Donators.Add(item);
            }

            context.Province.Add(proa);
            context.Province.Add(prob);

        }
    }
}
