using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFConsole9.Entity
{
    [Table("Province")]
    public class Province
    {
        public Province()
        {
            Donators = new HashSet<Donator>();
        }

        public int Id { get; set; }
        [StringLength(225)]
        public string ProvinceName { get; set; }
        public virtual ICollection<Donator> Donators { get; set; }
    }
}
