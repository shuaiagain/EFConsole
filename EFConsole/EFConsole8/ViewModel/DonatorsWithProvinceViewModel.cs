using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConsole8.Entity;

namespace EFConsole8.ViewModel
{
    public class DonatorsWithProvinceViewModel
    {
        public string Province { get; set; }
        public ICollection<Donatorb> DonatorList { get; set; }
    }
}
