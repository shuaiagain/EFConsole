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
    public class Person
    {
        public Person()
        {
            Companies = new HashSet<Company>();
        }

        public int PersonId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual Student Student { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
