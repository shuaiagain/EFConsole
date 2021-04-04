using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EFConsole7.Entity;

namespace EFConsole7
{
    public class Initializerb : DropCreateDatabaseAlways<DonatorsContext>
    {
    }
}
