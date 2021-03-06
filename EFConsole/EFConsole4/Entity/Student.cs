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
    public class Student
    {

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public string CollegeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
