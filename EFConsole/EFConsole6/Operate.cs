using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole6.Entity;

namespace EFConsole6
{
    public class Operate
    {
        #region ExampleN
        /// <summary>
        /// 填充种子数据
        /// </summary>
        public static void ExampleN()
        {
            using (var db = new SeedingDataContext())
            {

                var employers = db.Employers;
                foreach (var employer in employers)
                {
                    Console.WriteLine("Id={0}\tName={1}", employer.Id, employer.EmployeeName);
                }
            }

            Console.WriteLine("DB创建成功，并完成种子化！");
            Console.Read();
        }
        #endregion
    }
}
