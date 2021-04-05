using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFConsoleA.Entity
{
    [Table("InputAccounts")]
    public class InputAccount
    {
        public int Id { get; set; }
        [StringLength(8)]
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
