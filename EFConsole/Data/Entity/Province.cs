using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Province
    {
        public Province()
        {
            Donators = new HashSet<Donator>();
        }

        public int Id { get; set; }
        [StringLength(10)]
        public string ProvinceName { get; set; }
        public virtual ICollection<Donator> Donators { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
