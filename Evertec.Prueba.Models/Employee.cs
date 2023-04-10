using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Prueba.Models
{
    public  class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Photo { get; set; }
        public int MaritalStatus { get; set; }
        public bool HasSiblings { get; set; }

    }
}
