using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFConsole5.Entity
{
    [Table("Vendors")]
    public class Vendor : Person
    {
        public decimal HourlyRate { get; set; }
    }
}