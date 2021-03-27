using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole4.Entity
{
    public class DonatorType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Donator> Donators { get; set; }
    }
}
