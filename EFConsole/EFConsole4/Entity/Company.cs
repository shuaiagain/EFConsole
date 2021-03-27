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
    public class Company
    {
        public Company()
        {
            Persons = new HashSet<Person>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
