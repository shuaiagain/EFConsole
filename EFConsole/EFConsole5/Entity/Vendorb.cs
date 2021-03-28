using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFConsole5.Entity
{
    public class Vendorb : Personb
    {
        public decimal HourlyRate { get; set; }
    }
}