using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFConsole4.Entity
{
    public class Donator
    {
        public Donator()
        {
            PayWays = new HashSet<PayWay>();
        }

        public int DonatorId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonateTime { get; set; }

        /// <summary>
        /// virtual关键字允许我们使用 "懒加载" 来加载数据
        /// 也就是说当你尝试访问Donator的PayWays属性时，EF会动态地从数据库加载PayWays对象到该集合中
        /// </summary>
        public virtual ICollection<PayWay> PayWays { get; set; }

        public int? DonatorTypeId { get; set; }

        public virtual DonatorType DonatorType { get; set; }

    }
}
