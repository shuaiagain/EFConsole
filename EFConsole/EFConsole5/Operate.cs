using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole5.Entity;

namespace EFConsole5
{
    public class Operate
    {
        #region TPT继承(子表共用主表的主键)
        /// <summary>
        /// TPT继承(子表共用主表的主键)
        /// </summary>
        public static void ExampleK()
        {
            using (var context = new Context())
            {

                var employee = new Employee
                {
                    Name = "farb",
                    Email = "farbguo@qq.com",
                    PhoneNumber = "12345678",
                    Salary = 1234m
                };

                var vendor = new Vendor
                {
                    Name = "tkb至简",
                    Email = "farbguo@outlook.com",
                    PhoneNumber = "78956131",
                    HourlyRate = 4567m
                };

                context.People.Add(employee);
                context.People.Add(vendor);

                context.SaveChanges();
            }
        }
        #endregion

        #region TPH(共用主表，冗余字段)
        /// <summary>
        ///  TPH(共用主表，冗余字段)
        /// </summary>
        public static void ExampleL()
        {
            using (var context = new Context())
            {

                var employee = new Employeea
                {
                    Name = "farb",
                    Email = "farbguo@qq.com",
                    PhoneNumber = "12345678",
                    Salary = 1234m
                };

                var vendor = new Vendora
                {
                    Name = "tkb至简",
                    Email = "farbguo@outlook.com",
                    PhoneNumber = "78956131",
                    HourlyRate = 4567m
                };

                context.Peoplea.Add(employee);
                context.Peoplea.Add(vendor);

                context.SaveChanges();
            }
        }
        #endregion

        #region TPH(表分开，冗余共同的字段)
        /// <summary>
        /// TPH(表分开，冗余共同的字段)
        /// </summary>
        public static void ExampleM()
        {
            using (var context = new Context())
            {

                var employee = new Employeeb
                {
                    Name = "farb",
                    Email = "farbguo@qq.com",
                    PhoneNumber = "12345678",
                    Salary = 1234m
                };

                var vendor = new Vendorb
                {
                    Name = "tkb至简",
                    Email = "farbguo@outlook.com",
                    PhoneNumber = "78956131",
                    HourlyRate = 4567m
                };

                context.Peopleb.Add(employee);
                context.Peopleb.Add(vendor);

                context.SaveChanges();
            }
        }
        #endregion
    }
}
