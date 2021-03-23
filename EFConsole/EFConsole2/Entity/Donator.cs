using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFConsole2.Entity
{
    [Table("Donator")]
    public class Donator
    {
        [Key]
        [Column("Id")]
        public int DonatorId { get; set; }

        [StringLength(10, MinimumLength = 2)]
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public DateTime DonateTime { get; set; }
    }
}
