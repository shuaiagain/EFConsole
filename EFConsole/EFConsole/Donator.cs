using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole
{
    public class Donator
    {
        public int DonatorId { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public DateTime DonateTime { get; set; }
    }
}
