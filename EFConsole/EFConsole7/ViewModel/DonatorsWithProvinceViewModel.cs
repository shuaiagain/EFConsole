using EFConsole7.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole7.ViewModel
{
    public class DonatorsWithProvinceViewModel
    {
        public string Province { get; set; }
        public ICollection<Donatorb> DonatorList { get; set; }
    }
}
