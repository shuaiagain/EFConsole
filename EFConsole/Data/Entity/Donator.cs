using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Donator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonateDate { get; set; }
        //新增字段
        public Province Province { get; set; }

        public int ProvinceId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
