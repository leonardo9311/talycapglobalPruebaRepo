using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talycapglobalPrueba.Core.Entities
{
    public class Author : BaseEntity
    {
        public int IdBook { get; set; }
     
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
    }
}
