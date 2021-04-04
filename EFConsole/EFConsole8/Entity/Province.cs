using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFConsole8.Entity
{
    public class Province
    {
        public Province()
        {
            Donators = new HashSet<Donatorb>();
        }

        public int Id { get; set; }
        [StringLength(225)]
        public string ProvinceName { get; set; }
        public virtual ICollection<Donatorb> Donators { get; set; }
    }
}
