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
        public int DonatorId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonateTime { get; set; }

        public virtual ICollection<PayWay> PayWays { get; set; }

        public Donator()
        {
            PayWays = new HashSet<PayWay>();
        }
    }
}
